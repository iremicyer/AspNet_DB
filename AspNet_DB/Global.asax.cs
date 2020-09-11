using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet_DB
{
    
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // uygulama i�in genel ayarlar�n tan�t�ld��� aland�r.

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes); // uygulama ba�lad���nda buradaki parametre RouteConfig'e gider.
        }
    }
}
