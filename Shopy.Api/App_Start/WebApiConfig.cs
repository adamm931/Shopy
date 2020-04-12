using Newtonsoft.Json;
using Shopy.Api.DI;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity.WebApi;

namespace Shopy
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.MapRoutes();

            config.SetupJsonFormat();

            config.SetupUnity();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }

        private static HttpConfiguration MapRoutes(this HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new
                {
                    action = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithUid",
                routeTemplate: "api/{controller}/{uid}/{action}",
                defaults: new
                {
                    uid = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );

            return config;
        }

        private static HttpConfiguration SetupUnity(this HttpConfiguration config)
        {
            config.DependencyResolver = new UnityDependencyResolver(DIContainer.Instance);

            return config;
        }

        private static HttpConfiguration SetupJsonFormat(this HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return config;
        }
    }
}
