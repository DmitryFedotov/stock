using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Stock.Controllers
{
    public class HomeController : Controller
    {
        private StockContext db = new StockContext();

        public ActionResult Index()
        {
            var products = db.Products.Include(x => x.Shipper);
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Shippers()
        {
            var shippers = db.Shippers;
            ViewBag.Shippers = shippers;
            return View();
        }

        public ActionResult ProductArrivals()
        {
            var productArrivals = db.ProductArrivals;
            ViewBag.ProductArrivals = productArrivals;
            return View();
        }
    }
}