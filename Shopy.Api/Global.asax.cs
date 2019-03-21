using Shopy.Api.Data;
using System.Web.Http;

namespace Sample_v1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            DatabaseSeeder.Seed();
        }
    }
}