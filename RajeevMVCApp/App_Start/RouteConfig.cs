using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RajeevMVCApp.Customization;

namespace RajeevMVCApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.RouteExistingFiles = true;
            //routes.MapPageRoute("Page", "TestHtmlPhysicalPage", "~/views/TestHtmlPhysicalPage.html", false);
            // Adding custom routehandler for ~/Test url.
            //routes.Add(new Route("Test", new TestRouteHandler()));
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}