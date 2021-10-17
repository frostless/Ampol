using System;
using System.Collections.Generic;

namespace Ampol_API.Models
{
    public class Purchase
    {
        public string CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
    }

    public class Basket
    {
        public string ProductId { get; set; }
        // Here we assume the passed-in price and quantity is genuine but it should be checked against db in prod
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
