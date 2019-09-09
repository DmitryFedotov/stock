using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public float PriceForOne { get; set; }

        public int? ShipperId { get; set; }
        public Shipper Shipper { get; set; }
    }
}