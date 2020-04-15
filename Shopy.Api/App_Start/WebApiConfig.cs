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

            config.SetupMediaFormats();

            config.SetupUnity();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }

        private static HttpConfiguration MapRoutes(this HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "1",
                routeTemplate: "api/{controller}/{productid}/{action}/{categoryid}"
            );

            config.Routes.MapHttpRoute(
                name: "2",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "3",
                routeTemplate: "api/{controller}/{uid}/{action}",
                defaults: new
                {
                    action = RouteParameter.Optional,
                    uid = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "4",
                routeTemplate: "api/{controller}/{uid}",
                defaults: new
                {
                    uid = RouteParameter.Optional
                }
            );

            return config;
        }

        private static HttpConfiguration SetupUnity(this HttpConfiguration config)
        {
            config.DependencyResolver = new UnityDependencyResolver(DIContainer.Instance);

            return config;
        }

        private static HttpConfiguration SetupMediaFormats(this HttpConfiguration config)
        {
            var mediaType = config.Formatters.JsonFormatter.SupportedMediaTypes;

            mediaType.Add(new MediaTypeHeaderValue("multipart/form-data"));
            mediaType.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return config;
        }
    }
}
