using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Models
{
    public class Shipper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Information { get; set; }

        public ICollection<Product> Products { get; set; }
        public Shipper()
        {
            Products = new List<Product>();
        }
    }
}