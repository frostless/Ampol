using System.Collections.Generic;

namespace Ampol_API.Models
{
    public class Purchase
    {
        public string CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public string TransactionDate { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
    }

    public class Basket
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
