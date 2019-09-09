using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Services
{
    public class ShipperService
    {
        private StockContext db = new StockContext();

        public bool create(Shipper shipper)
        {
            bool result = false;
            try
            {              
                db.Shippers.Add(shipper);
                db.SaveChanges();             
                result = true;
            }
            catch
            {

            }

            return result;
        }

        public bool update(Shipper shipper)
        {
            bool result = false;
            try
            {
                var changedShipper = db.Shippers.Where(arg => arg.Id == shipper.Id).FirstOrDefault();             
                db.Entry(changedShipper).CurrentValues.SetValues(shipper);
                db.SaveChanges();             
                result = true;
            }
            catch
            {

            }

            return result;
        }

        public bool delete(Shipper shipper)
        {
            bool result = false;
            if (shipper != null)
            {
                try
                {                  
                    db.Shippers.Remove(shipper);
                    db.SaveChanges();
                    result = true;
                }
                catch
                {

                }
            }

            return result;
        }

        public Shipper getShipperById(int id)
        {
            return db.Shippers.Where(arg => arg.Id == id).FirstOrDefault();
        }

        public bool isUnique(Shipper shipper)
        {
            bool result = true;
            var unique = db.Shippers.Where(p => p.Name == shipper.Name).FirstOrDefault();
            if (unique != null)
                result = false;

            return result;
        }
    }
}