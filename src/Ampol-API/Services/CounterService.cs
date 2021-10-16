using Ampol_API.Models;

namespace Ampol_API.Services
{
    public class CounterService : ICounterService
    {
        public Receipt Checkout(Purchase purchase)
        {
            decimal totalAmount = 0;
            decimal totalDiscounts = 0;
            int totalPoints = 0;

           foreach (var basket in purchase.Baskets)
            {
                totalAmount += basket.TotalPrice;
                totalPoints += GetPromitionPoints(basket);
                totalDiscounts += GetPromitionDiscount(basket);
            }

            return new Receipt(purchase.CustomerId, purchase.LoyaltyCard, purchase.TransactionDate, totalAmount, totalDiscounts, totalPoints);
        }

        public int GetPromitionPoints(Basket basket)
        {
            return 0;
        }

        public decimal GetPromitionDiscount(Basket basket)
        {
            return 0;
        }
    }
}
