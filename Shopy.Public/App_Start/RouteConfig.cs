using System.Web.Mvc;
using System.Web.Routing;

namespace Shopy.Public
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Products",
                url: "Products/{action}/{id}",
                defaults: new
                {
                    controller = "Products",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Products",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}

