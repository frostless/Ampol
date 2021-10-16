using Ampol_API.Models;

namespace Ampol_API.Services
{
    public interface ICounterService
    {
        public Receipt Checkout(Purchase purchase);
        public int GetPromitionPoints(Basket basket);
        public decimal GetPromitionDiscount(Basket basket);
    }
}
