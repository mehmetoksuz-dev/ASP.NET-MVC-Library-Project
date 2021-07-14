using Library.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryProject.SupporterClasses
{
    public class RoleControl : ActionFilterAttribute
    {
        readonly UnitOfWork _unitofWork;
        public RoleControl()
        {
            _unitofWork = new UnitOfWork();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies["member"];
            if (cookie == null)
            {
                //giriş yapılmamışsa logine attık
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {{ "controller", "Login" },{ "action", "Index" } });
            }
            else
            {
                var role = cookie["RoleId"];
                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var actionName = filterContext.RouteData.Values["action"].ToString();
                if (role == "2") // Moderator erisimi
                {
                    if (controllerName=="Membership") 
                    {
                        //yetkisi olmadigi icin direk kitaplara gidecek
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Book" }, { "action", "Index" } });
                    }
                }
                else if (role=="3") //normal uye
                {
                    //index harici yerlerde degisiklik yapılıyor url sonuna ekleme yapılıp farklı yerlere gidebiliyordu kullanıcı kısıtlandı
                    if (controllerName == "Membership" || actionName != "Index") 
                    {
                        //yetkisi olmadigi icin direk kitaplara gidecek
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Book" }, { "action", "Index" } });
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}