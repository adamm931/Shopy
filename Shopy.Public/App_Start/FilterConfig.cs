using Shopy.Web;
using System.Web.Mvc;

namespace Shopy.Public
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.AddMvcExceptionFilter();
        }
    }
}
