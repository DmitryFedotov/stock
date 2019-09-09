using Stock.Models;
using Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock.Controllers
{
    public class ProductsController : Controller
    {
        private StockContext db = new StockContext();
        private ProductService productService = new ProductService();

        [HttpGet]
        public ActionResult AddProduct()
        {
            var shippers = db.Shippers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            SelectList list = new SelectList(shippers, "Value", "Text");
            ViewBag.shipper = list;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, FormCollection form)
        {
            try
            {
                var selectedShipper = form["shipper"];             
                if (selectedShipper.Length != 0) // проверка на выбранного поставщика
                {
                    if (product.PriceForOne != 0) //валидность цены
                    {
                        if (product.Name.Length != 0 && product.Unit.Length != 0 && product.Amount != 0) //заполнение оставшихся полей
                        {
                            int selectedID = int.Parse(selectedShipper);
                            if (productService.isUnique(product, selectedID)) //уникальность товара
                            {
                                if (productService.create(product, selectedID))
                                    return RedirectToRoute(new { controller = "Messages", action = "SuccessCreate" });
                                else
                                    return RedirectToRoute(new { controller = "Messages", action = "ErrorCreate" });
                            }
                            else return RedirectToRoute(new { controller = "Messages", action = "ErrorUniqueProduct" });
                        }
                        else return RedirectToRoute(new { controller = "Messages", action = "ErrorNullPointer" });
                    }
                    else return RedirectToRoute(new { controller = "Messages", action = "ErrorType" });
                }            
                else return RedirectToRoute(new { controller = "Messages", action = "ErrorShipperSelection" });
            }
            catch
            {
                return RedirectToRoute(new { controller = "Messages", action = "ErrorCreate" });
            }                                                                       
        }
        [HttpGet]
        public ActionResult InputUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputUpdate(int updateId)
        {   if (updateId > 0)
                return RedirectToAction("UpdateProduct", new {  id = updateId });
            else
                return RedirectToRoute(new { controller = "Messages", action = "ErrorID" });
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = productService.getProductById(id);
            if (product != null)
            {           
                var shippers = db.Shippers.Select(c => new SelectListItem { Value = product.ShipperId.ToString(), Text = c.Name });
                SelectList list = new SelectList(shippers, "Value", "Text");
                ViewBag.shipper = list;
                ViewBag.Product = product;
                return View();
            }
            else
            {
                return RedirectToRoute(new { controller = "Messages", action = "ErrorUpdate" });
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product, FormCollection form)
        {
            var selectedShipper = form["shipper"];
            if (selectedShipper.Length != 0)
            {
                int selectedID = int.Parse(selectedShipper);
                product.ShipperId = selectedID;
         
                if (productService.update(product))
                    return RedirectToRoute(new { controller = "Messages", action = "SuccessUpdate" });
                else return RedirectToRoute(new { controller = "Messages", action = "ErrorUpdate" });
            }    
            else return RedirectToRoute(new {controller = "Messages", action = "ErrorShipperSelection" });
        }

        [HttpGet]
        public ActionResult InputDel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputDel(int delId)
        {
            Product product = productService.getProductById(delId);
            if (productService.delete(product))
                return RedirectToRoute(new { controller = "Messages", action = "SuccessDel" });
            else return RedirectToRoute(new { controller = "Messages", action = "ErrorDel" });
        }    
    }
}