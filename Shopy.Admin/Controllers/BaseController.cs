using Shopy.Sdk;
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
                return shopy ?? (shopy = new ShopyDriveBuilder().Configure());
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            base.OnActionExecuting(filterContext);
        }
    }
}