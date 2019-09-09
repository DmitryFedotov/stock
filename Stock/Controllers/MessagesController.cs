using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock.Controllers
{
    public class MessagesController : Controller
    {
        public ActionResult SuccessDel()
        {
            TempData["msg"] = "<script>alert('Товар успешно удалён.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorDel()
        {
            TempData["msg"] = "<script>alert('Ошибка удаления товара.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult SuccessCreate()
        {
            TempData["msg"] = "<script>alert('Товар успешно добавлен.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorCreate()
        {
            TempData["msg"] = "<script>alert('Ошибка добавления товара.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult SuccessUpdate()
        {
            TempData["msg"] = "<script>alert('Товар успешно обновлён.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorUpdate()
        {
            TempData["msg"] = "<script>alert('Ошибка обновления товара.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorID()
        {
            TempData["msg"] = "<script>alert('Ошибка! Уникальный идентификатор должен быть натуральным числом.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorShipperSelection()
        {
            TempData["msg"] = "<script>alert('Ошибка! Вы не выбрали поставщика.');" +
                "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorType()
        {
            TempData["msg"] = "<script>alert('Ошибка! Цена должна быть рациональным числом.');" +
             "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorNullPointer()
        {
            TempData["msg"] = "<script>alert('Ошибка! Все поля должны быть заполнены.');" +
             "location.href='/Home/Index/';</script>";
            return View();
        }

        public ActionResult ErrorUniqueProduct()
        {
            TempData["msg"] = "<script>alert('Такой товар уже есть на складе.');" +
             "location.href='/Home/Index/';</script>";
            return View();
        }


        public ActionResult ErrorUniqueShip()
        {
            TempData["msg"] = "<script>alert('Такой поставщик уже добавлен.');" +
             "location.href='/Home/Shippers/';</script>";
            return View();
        }

        public ActionResult SuccessDelShip()
        {
            TempData["msg"] = "<script>alert('Поставщик успешно удалён.');" +
                "location.href='/Home/Shippers/';</script>";
            return View();
        }

        public ActionResult ErrorDeleteShip()
        {
            TempData["msg"] = "<script>alert('Ошибка удаления поставщика.');" +
                "location.href='/Home/Shippers/';</script>";
            return View();
        }

        public ActionResult SuccessCreateShip()
        {
            TempData["msg"] = "<script>alert('Поставщик успешно добавлен.');" +
                "location.href='/Home/Shippers/';</script>";
            return View();
        }

        public ActionResult ErrorCreateShip()
        {
            TempData["msg"] = "<script>alert('Ошибка добавления поставщика.');" +
                "location.href='/Home/Shippers/';</script>";
            return View();
        }

        public ActionResult SuccessUpdateShip()
        {
            TempData["msg"] = "<script>alert('Поставщик успешно обновлён.');" +
                "location.href='/Home/Shippers/';</script>";
            return View();
        }

        public ActionResult ErrorUpdateShip()
        {
            TempData["msg"] = "<script>alert('Ошибка обновления поставщика.');" +
                "location.href='/Home/Shippers/';</script>";
            return View();
        }
    }
}