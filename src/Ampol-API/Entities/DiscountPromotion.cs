using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ampol_API.Entities
{
    public class DiscountPromotion
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Percentage { get; set; }

        // This is to make it easy to fake the hardcode data, should not be in prod
        public DiscountPromotion(string id, string name, DateTime startDate, DateTime endDate, decimal percentage)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Percentage = percentage;
        }
    }
}
