using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Shopy
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{uid}",
                defaults: new
                {
                    uid = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{action}/{uid}",
                defaults: new
                {
                    uid = RouteParameter.Optional
                }
            );

            SetupJsonFormat(config);
        }

        private static void SetupJsonFormat(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings =
                 new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }
    }
}
