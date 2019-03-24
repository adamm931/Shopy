using Shopy.SDK;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    public class BaseController : Controller
    {
        private IShopyDriver shopy;

        protected IShopyDriver Shopy
        {
            get
            {
                return shopy ?? (shopy = SDK.ShopyDriver.Create());
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            base.OnActionExecuting(filterContext);
        }
    }
}