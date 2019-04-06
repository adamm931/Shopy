using Shopy.Admin.Utils;
using System.Web.Mvc;

namespace Shopy.Admin.Filters
{
    public class LoginCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            var authentication = new AuthenticationUtils();

            if (authentication.IsUserAuthenticated(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectResult(authentication.DefaultUrl);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}