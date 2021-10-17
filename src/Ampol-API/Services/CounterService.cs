using System;
using System.Linq;
using Ampol_API.Data;
using Ampol_API.Models;

namespace Ampol_API.Services
{
    public class CounterService : ICounterService
    {
        private readonly DataContext _dataContext;

        public CounterService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Receipt Checkout(Purchase purchase)
        {
            decimal totalAmount = 0;
            decimal totalDiscounts = 0;
            int totalPoints = 0;

            foreach (var basket in purchase.Baskets)
            {
                totalAmount += basket.TotalPrice;
                totalPoints += GetPromotionPoints(basket, purchase.TransactionDate);
                totalDiscounts += GetPromotionDiscount(basket, purchase.TransactionDate);
            }

            return new Receipt(purchase.CustomerId, purchase.LoyaltyCard, purchase.TransactionDate, totalAmount, totalDiscounts, totalPoints);
        }

        public int GetPromotionPoints(Basket basket, DateTime date)
        {
            var products = _dataContext.GetProducts();
            var pointsPromotion = _dataContext.GetPointsPromotion();

            var product = products.FirstOrDefault(p => p.Id == basket.ProductId);

            if (product == default)
            {
                // Search miss, no points given
                return 0;
            }

            var matchPromotion = pointsPromotion.Where(pp => pp.Category == "Any" || pp.Category == product.Category)
                                                .Where(pp => pp.StartDate <= date && pp.EndDate >= date)
                                                 // Only one points promo can run so take the highest by default
                                                 .OrderByDescending(pp => pp.PointsPerDollar)
                                                 .FirstOrDefault();

            if (matchPromotion == default)
            {
                // Search miss, no points given
                return 0;
            }

            return matchPromotion.PointsPerDollar * (int)Math.Ceiling(basket.TotalPrice);
        }

        public decimal GetPromotionDiscount(Basket basket, DateTime date)
        {
            var discountPromotion = _dataContext.GetDiscountPromotion();
            var discountPromotionProducts = _dataContext.GetDiscountPromotionProducts();

            var matchPromotionProducts = discountPromotionProducts.Where(dpp => dpp.ProductId == basket.ProductId).ToList();

            if (matchPromotionProducts?.Count == 0)
            {
                // Search miss, no points given
                return 0;
            }

            var matchPromotion = discountPromotion.Where(dp => matchPromotionProducts.Any(mpp => mpp.DiscountPromotionId == dp.Id))
                                                  .Where(dp => dp.StartDate <= date && dp.EndDate >= date)
                                                   // Only one points promo can run so take the highest by default
                                                  .OrderByDescending(dp => dp.Percentage)
                                                  .FirstOrDefault();

            if (matchPromotion == default)
            {
                // Search miss, no points given
                return 0;
            }


            return matchPromotion.Percentage * basket.TotalPrice;
        }
    }
}
