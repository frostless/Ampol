using System;

namespace Ampol_API.Entities
{
    public class PointsPromotion
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Could reference Category table through a foreign key in prod
        public string Category { get; set; }
        public int PointsPerDollar { get; set; }

        // This is to make it easy to fake the hardcode data, should not be in prod
        public PointsPromotion(string id, string name, DateTime startDate, DateTime endDate, string category, int pointsPerDollar)
        {
            Id = id;
            Name = name;
            Category = category;
            StartDate = startDate;
            EndDate = endDate;
            Category = category;
            PointsPerDollar = pointsPerDollar;
        }
    }
}
