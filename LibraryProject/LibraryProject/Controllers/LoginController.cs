using Library.Data.HelperClass;
using Library.Data.Model;
using Library.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly UnitOfWork _unitofWork;
        public LoginController()
        {
            _unitofWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            if (Request.Cookies["member"] != null) //kullanıcı giriş yapmışsa ve tekrar logine dönerse?
            {
                return RedirectToAction("Index","Book");
            }
            
            return View();
        }

        [HttpPost]
        public JsonResult LoginControl(string email, string pass, bool remember)
        {
            email = email.Trim();
            pass = pass.Trim();
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(pass))
            {
                return Json("notNull");
            }

            pass=pass.Encrypt();
            var member = new Member();

            try{ member = _unitofWork.GetRepository<Member>().Get(x => x.Mail == email && x.Pass == pass); }
            catch { }

            if (member != null)
            {
                HttpCookie cookie = new HttpCookie("member");
                cookie.Values.Add("Id", member.Id.ToString());
                cookie.Values.Add("Name", member.Name);
                cookie.Values.Add("Surname", member.Surname);
                cookie.Values.Add("RoleId", member.Role);

                if (remember) cookie.Expires = DateTime.Now.AddDays(5); //cookie 5 gün tut

                Response.Cookies.Add(cookie);

                return Json("Success");
            }
            else return Json("0");
        }

        public ActionResult Logout()
        {
            var cookie = Response.Cookies["member"];
            if (cookie !=null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("Index");
        }
    }
}