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
            ViewBag.Authenticated = HttpContext?.Session?["Authenticated"] != null;

            base.OnActionExecuting(filterContext);
        }
    }
}