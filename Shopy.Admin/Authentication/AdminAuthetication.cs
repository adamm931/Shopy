using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shopy.Admin.Authentication
{
    public class AdminAuthetication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Authenticated"] == null)
            {
                var route = new RouteValueDictionary();
                route.Add("action", "Index");
                filterContext.Result = new RedirectToRouteResult("Login", route);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}