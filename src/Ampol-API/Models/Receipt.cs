using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ampol_API.Models
{
    public class Receipt
    {
        public string CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public string TransactionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        // This is TotalAmount minus DiscountApplied
        public decimal GrandTotal { get; set; }
        public int PointsEarned { get; set; }

        public Receipt(string customerId, string loyaltyCard, string transactionDate, decimal totalAmount, decimal discountApplied, int pointsEarned)
        {
            CustomerId = customerId;
            LoyaltyCard = loyaltyCard;
            TransactionDate = transactionDate;
            TotalAmount = totalAmount;
            DiscountApplied = discountApplied;
            GrandTotal = totalAmount - discountApplied;
            PointsEarned = pointsEarned;
        }
    }
}
