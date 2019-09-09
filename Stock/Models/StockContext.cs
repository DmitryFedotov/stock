using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stock.Models
{
    public class StockContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ProductArrivals> ProductArrivals { get; set; }
    }
}