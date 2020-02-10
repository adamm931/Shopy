using Newtonsoft.Json;
using Shopy.Api.DI;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity.WebApi;

namespace Shopy.Api.App_Start
{
    public static class HttpConfigExtensions
    {
        public static HttpConfiguration MapRoutes(this HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{uid}/{action}",
                defaults: new
                {
                    uid = RouteParameter.Optional,
                    action = RouteParameter.Optional
                }
            );

            return config;
        }

        public static HttpConfiguration SetupUnity(this HttpConfiguration config)
        {
            config.DependencyResolver = new UnityDependencyResolver(DIContainer.Instance);

            return config;
        }

        public static HttpConfiguration SetupJsonFormat(this HttpConfiguration config)
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