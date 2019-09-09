using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Models
{
    public class ProductArrivals
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ProductName {get;set;}
        public string ProductUnit { get; set; }
        public int ProductAmount { get; set; }
        public float ProductPriceForOne { get; set; }
        public string ShipperName { get; set; }
        public string TransactionInformation { get; set; }
    }
}