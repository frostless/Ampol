using System;
using Ampol_API.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Ampol_API.Data
{
    public class DataContext
    {
        private readonly IList<Product> _products = new List<Product>()
        {
            new Product("PRD01", "Vortext95", "Fuel", 1.2M),
            new Product("PRD02", "Vortext98", "Fuel", 1.3M),
            new Product("PRD03", "Diesel", "Fuel", 1.1M),
            new Product("PRD04", "Twix 55g", "Shop", 2.3M),
            new Product("PRD5", "Mars 72g", "Shop", 5.1M),
            new Product("PRD06", "SNICKERS 72G", "Shop", 3.4M),
            new Product("PRD07", "Bounty 3 63g", "Shop", 6.9M),
            new Product("PRD08", "Snickers 50g", "Shop", 4.0M)
        };

        private readonly IList<PointsPromotion> _pointsPromotion = new List<PointsPromotion>()
        {
            new PointsPromotion("PPD01", "New Year Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200130", "yyyyMMdd", CultureInfo.InvariantCulture),  "Any", 2),
            new PointsPromotion("PPD02", "Fuel Promo", DateTime.ParseExact("20200205", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), "Fuel", 3),
            new PointsPromotion("PPD03", "Shop Promo", DateTime.ParseExact("20200301", "yyyyMMdd", CultureInfo.InvariantCulture),DateTime.ParseExact("20200302", "yyyyMMdd", CultureInfo.InvariantCulture), "Shop", 4)
        };

        private readonly IList<DiscountPromotion> _discountPromotion = new List<DiscountPromotion>()
        {
            new DiscountPromotion("DP001", "Fuel Discount Promo", DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200215", "yyyyMMdd", CultureInfo.InvariantCulture), 0.2M),
            new DiscountPromotion("DP002", "Happy Promo", DateTime.ParseExact("20200301", "yyyyMMdd", CultureInfo.InvariantCulture), DateTime.ParseExact("20200320", "yyyyMMdd", CultureInfo.InvariantCulture), 0.15M)
        };

        private readonly IList<DiscountPromotionProduct> _discountPromotionProducts = new List<DiscountPromotionProduct>()
        {
            new DiscountPromotionProduct("DP001", "PRD02"),
            new DiscountPromotionProduct("DP002", "PRD02")
        };

        public IList<Product> GetProducts()
        {
            return _products;
        }

        public IList<PointsPromotion> GetPointsPromotion()
        {
            return _pointsPromotion;
        }

        public IList<DiscountPromotion> GetDiscountPromotion()
        {
            return _discountPromotion;
        }

        public IList<DiscountPromotionProduct> GetDiscountPromotionProducts()
        {
            return _discountPromotionProducts;
        }
    }
}
