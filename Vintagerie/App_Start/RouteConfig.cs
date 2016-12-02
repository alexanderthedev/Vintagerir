using System.Web.Mvc;
using System.Web.Routing;

namespace Vintagerie
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            /*routes.MapRoute(
                name: "ForStore",
                url: "{controller}/{action}/{slug}",
                defaults: new { controller = "Store", action = "SingleStore"}
            );*/


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
