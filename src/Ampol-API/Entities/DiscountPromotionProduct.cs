using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ampol_API.Entities
{
    public class DiscountPromotionProduct
    {
        // Could reference DiscountPromotion table through a foreign key in prod
        public string DiscountPromotionId { get; set; }
        // Could reference Product table through a foreign key in prod
        public string ProductId { get; set; }

        // This is to make it easy to fake the hardcode data, should not be in prod
        public DiscountPromotionProduct(string discountPromotionId, string producId)
        {
            DiscountPromotionId = discountPromotionId;
            ProductId = producId;
        }
    }
}
