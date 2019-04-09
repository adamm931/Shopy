using Shopy.SDK;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected IShopyDriver Shopy { get; }
        protected IDependencyResolver DiC { get; } = DependencyResolver.Current;

        public BaseController(IShopyDriver shopy)
        {
            Shopy = shopy;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            base.OnActionExecuting(filterContext);
        }
    }
}