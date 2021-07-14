using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageNotFound() //404 ve 400 sayfa bulunamadı hataları için
        {
            return View();
        }

        public ActionResult NoAccessAllowed() //403 erişim izni yok hatası
        {
            return View();
        }

        public ActionResult ServerError() //500 sunucu hatası
        {
            return View();
        }
    }
}