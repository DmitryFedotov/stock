using Stock.Models;
using Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock.Controllers
{
    public class ShippersController : Controller
    {
        private StockContext db = new StockContext();
        private ShipperService shipperService = new ShipperService();

        [HttpGet]
        public ActionResult AddShipper()
        {        
            return View();
        }

        [HttpPost]
        public ActionResult AddShipper(Shipper shipper)
        {
            try
            {
                if (shipper.Name.Length != 0 && shipper.Address.Length != 0 && shipper.Information.Length != 0)
                {
                    if (shipperService.isUnique(shipper))
                    {
                        if (shipperService.create(shipper))
                            return RedirectToRoute(new { controller = "Messages", action = "SuccessCreateShip" });
                        else return RedirectToRoute(new { controller = "Messages", action = "ErrorCreateShip" });

                    }
                    else RedirectToRoute(new { controller = "Messages", action = "ErrorUniqueShip" });
                }
            }
            catch
            {
                
            }
            return RedirectToRoute(new { controller = "Messages", action = "ErrorCreateShip" });
        }

        [HttpGet]
        public ActionResult InputUpdateShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputUpdateShipper(int updateId)
        {
            if (updateId > 0)
                return RedirectToAction("UpdateShipper", new { id = updateId });
            else
                return RedirectToRoute(new { controller = "Messages", action = "ErrorID" });
        }

        [HttpGet]
        public ActionResult UpdateShipper(int id)
        {
            var shipper = shipperService.getShipperById(id);
            if(shipper != null)
            {                       
                ViewBag.Shipper = shipper;
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Messages", action = "ErrorUpdateShip" });
            }
        }

        [HttpPost]
        public ActionResult UpdateShipper(Shipper shipper)
        {
            try
            {
                if (shipper.Name.Length != 0 && shipper.Address.Length != 0 && shipper.Information.Length != 0)
                {
                    if (shipperService.update(shipper))
                        return RedirectToRoute(new { controller = "Messages", action = "SuccessUpdateShip" });
                    else return RedirectToRoute(new { controller = "Messages", action = "ErrorUpdateShip" });
                }
                else return RedirectToRoute(new { controller = "Messages", action = "ErrorNullPointer" });
            }
            catch
            {
                return RedirectToRoute(new { controller = "Messages", action = "ErrorUpdateShip" });
            }
        }

        [HttpGet]
        public ActionResult InputDelShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputDelShipper(int delId)
        {
            Shipper shipper = shipperService.getShipperById(delId);
            if (shipperService.delete(shipper))
                return RedirectToRoute(new { controller = "Messages", action = "SuccessDelShip" });
            else return RedirectToRoute(new { controller = "Messages", action = "ErrorDeleteShip" });
        }

    }
}