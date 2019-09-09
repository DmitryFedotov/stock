using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Services
{
    public class ProductService
    {

        private StockContext db = new StockContext();

        public bool create(Product product, int shipperId)
        {
            bool result = false;
            try
            {
                var shipper = db.Shippers.Where(c => c.Id == shipperId).FirstOrDefault();
                product.Shipper = shipper;
                db.Products.Add(product);         
                db.SaveChanges();
                movement(product, shipper,"Приход товара.");
                result = true;             
            }
            catch
            {

            }

            return result;
        }

        public bool update(Product product)
        {
            bool result = false;
            try
            {
                var changedProduct = db.Products.Where(arg => arg.Id == product.Id).FirstOrDefault();
                var shipper = db.Shippers.Where(arg => arg.Id == product.ShipperId).FirstOrDefault();
                int currAmount = changedProduct.Amount;
                db.Entry(changedProduct).CurrentValues.SetValues(product);
                db.SaveChanges();

                if (currAmount > product.Amount)
                {
                    
                    product.Amount = currAmount - product.Amount;
                    movement(product, shipper, "Расход товара.");
                    
                }
                else
                {
                    if (currAmount == product.Amount)
                        movement(product, shipper, "Обновление товара.");
                    else
                    {
                        product.Amount = product.Amount - currAmount;
                        movement(product, shipper, "Приход товара.");
                    }
                }

                result = true;
            }
            catch
            {

            }

            return result;
        }

        public bool delete(Product product)
        {
            bool result = false;
            if (product != null)
            {
                try
                {
                    var shipper = db.Shippers.Where(arg => arg.Id == product.ShipperId).FirstOrDefault();
                    movement(product, shipper,"Расход товара.");
                    db.Products.Remove(product);
                    db.SaveChanges();
                    result = true;
                }
                catch
                {

                }
            }

            return result;
        }

        public Product getProductById(int id)
        {
            return db.Products.Where(arg => arg.Id == id).FirstOrDefault();
        }

        private void movement(Product product, Shipper shipper, string str)
        {
            ProductArrivals productArrivals = new ProductArrivals();
            productArrivals.Date = DateTime.Now;
            productArrivals.ProductName = product.Name;
            productArrivals.ProductAmount = product.Amount;
            productArrivals.ProductUnit = product.Unit;
            productArrivals.ProductPriceForOne = product.PriceForOne;
            productArrivals.ShipperName = shipper.Name;
            productArrivals.TransactionInformation = str;

            db.ProductArrivals.Add(productArrivals);
            db.SaveChanges();
        }

        public bool isUnique(Product product, int shipperId)
        {
            bool result = true;
            var unique = db.Products.Where(p => p.Name == product.Name && p.ShipperId == shipperId).FirstOrDefault();
            if (unique != null)
                result = false;

            return result;
        }

    }
}