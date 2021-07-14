using LibraryProject.SupporterClasses;
using LibraryProject.Tasks.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            PunishmentUpDownTrigger.Start(); //buradan baslicak
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception E = Server.GetLastError(); //hatay� yakalad�k
            Response.Clear(); //arabellekteki html outputlar�n� siliyor

            //HttpException httpEx = E as HttpException;

            //if (httpEx != null) //null degilse hataya d��m��t�r
            if (E is HttpException httpEx) //null degilse hataya d��m��t�r
            {
                //burada log al�yoruz
                LogInfo logs = new LogInfo
                {
                    Url = Request.Url.ToString(),
                    errorMsg = httpEx.Message,
                    whenAdded = DateTime.Now,
                    memberIp = MemberIpAdress.GetClientIp(), //ip
                    Browser = Request.Browser.Browser,
                    Lang = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2)
                };

                switch (httpEx.GetHttpCode())
                {
                    case 403:
                        Response.Redirect("/Error/NoAccessAllowed");
                        break;
                    case 404:
                        Response.Redirect("/Error/PageNotFound");
                        break;
                    case 500:
                        Response.Redirect("/Error/ServerError");
                        break;
                    default: //farkl� bir kod gelirse?
                        Response.Redirect("/Error/PageNotFound");
                        break;
                }
                Server.ClearError();
            }


        }
    }
}
