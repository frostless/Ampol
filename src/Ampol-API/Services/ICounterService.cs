using System;
using Ampol_API.Models;

namespace Ampol_API.Services
{
    public interface ICounterService
    {
        public Receipt Checkout(Purchase purchase);
        public int GetPromotionPoints(Basket basket, DateTime date);
        public decimal GetPromotionDiscount(Basket basket, DateTime date);
    }
}
