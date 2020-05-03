using Shopy.Admin.Utils;
using System.Web.Mvc;

namespace Shopy.Admin.Filters
{
    public class LoginCheck : ActionFilterAttribute
    {
        public IAuthenticationUtils _authenticationUtils = DependencyResolver.Current.GetService<IAuthenticationUtils>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            if (_authenticationUtils.IsUserAuthenticated(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectResult(_authenticationUtils.DefaultUrl);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}