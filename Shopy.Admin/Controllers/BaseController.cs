using Shopy.SDK;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    public class BaseController : Controller
    {
        private IShopyProxy shopy;

        protected IShopyProxy Shopy
        {
            get
            {
                return shopy ?? (shopy = ShopyProxy.Create());
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            base.OnActionExecuting(filterContext);
        }
    }
}