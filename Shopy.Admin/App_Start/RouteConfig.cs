using System.Web.Mvc;
using System.Web.Routing;

namespace Shopy.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "products",
                url: "Products/{action}/{uid}/",
                defaults: new
                {
                    controller = "Products",
                    action = "List",
                    uid = UrlParameter.Optional,
                }
            );

            routes.MapRoute(
                name: "ProductCategories",
                url: "ProductCategories/{uid}/{action}/{categoryUid}/",
                defaults: new
                {
                    controller = "Products",
                    action = "LoadCategories",
                    categoryUid = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "login",
                url: "Login/{action}",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "categories",
                url: "Categories/{action}/{uid}",
                defaults: new
                {
                    controller = "Categories",
                    action = "List",
                    uid = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

