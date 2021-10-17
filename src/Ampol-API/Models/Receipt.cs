using System;

namespace Ampol_API.Models
{
    public class Receipt
    {
        public string CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        // This is TotalAmount minus DiscountApplied
        public decimal GrandTotal { get; set; }
        public int PointsEarned { get; set; }

        public Receipt()
        {

        }

        public Receipt(string customerId, string loyaltyCard, DateTime transactionDate, decimal totalAmount, decimal discountApplied, int pointsEarned)
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
