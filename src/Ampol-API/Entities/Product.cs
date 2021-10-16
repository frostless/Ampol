using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ampol_API.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        // Could reference Category table through a foreign key in prod
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }


        // This is to make it easy to fake the hardcode data, should not be in prod
        public Product(string id, string name, string category, decimal unitPrice)
        {
            Id = id;
            Name = name;
            Category = category;
            UnitPrice = unitPrice;
        }
    }
}
