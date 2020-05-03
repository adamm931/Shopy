using Shopy.Core.Logging;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Shopy.Web
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        public void OnException(ExceptionContext filterContext)
        {
            var logger = DependencyResolver.Current.GetService<ILogger>();

            logger.Critical(filterContext.Exception.ToString());
        }
    }
}
