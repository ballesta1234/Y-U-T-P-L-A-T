using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YUTPLAT.App_Start;
using YUTPLAT.Helpers;

namespace YUTPLAT
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            string mensaje;

            if (httpException != null)
            {
                switch (httpException.GetHttpCode())
                {
                    case 403:
                        // not authorized
                        mensaje = "Acceso denegado.";
                        break;
                    case 404:
                        // page not found
                        mensaje = "La página solicitada no se ha encontrado, inténtelo de nuevo y verifique que sea correcta.";
                        break;
                    case 500:
                        // server error
                        mensaje = "Ha ocurrido un error en el servidor, por favor cantáctese con el administrador.";
                        break;
                    case 503:
                        // server error
                        mensaje = "Servicio no disponible, por favor cantáctese con el administrador.";
                        break;
                    default:
                        mensaje = "Ha ocurrido un error en el servidor, por favor cantáctese con el administrador.";
                        break;
                }
                // clear error on server
                Server.ClearError();                
            }
            else
            {
                mensaje = "Ha ocurrido un error en el servidor, por favor cantáctese con el administrador.";                
            }
            
            string msgEncrypt = MyExtensions.Encrypt(new { msg = mensaje });

            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Error/HttpError?q=" + Server.UrlEncode(msgEncrypt));
            }
            else
            {
                Response.Redirect("~/Error/HttpErrorGeneral?q=" + Server.UrlEncode(msgEncrypt));
            }
        }
    }
}
