using Shopy.Core.Logging;
using System.Web.Mvc;

namespace Shopy.Admin.Filters
{
    public class LogExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var logger = DependencyResolver.Current.GetService<ILogger>();

            logger.Critical(filterContext.Exception.ToString());
        }
    }
}