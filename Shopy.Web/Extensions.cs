using AutoMapper;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace Shopy.Web
{
    public static class Extensions
    {
        public static void RegisterAutoMapper<TTypeSource>(this IUnityContainer container)
        {
            var profiles = ReflectionHelper.GetTypesFromAssembly<TTypeSource, Profile>();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            var mapper = configuration.CreateMapper();

            container.RegisterInstance(mapper);
        }

        public static void Configure<TTypeSource>(this IUnityContainer container)
        {
            var installers = ReflectionHelper.GetTypesFromAssembly<TTypeSource, IUnityInstaller>();

            foreach (var installer in installers)
            {
                installer.InstallUnity(container);
            }
        }

        public static void AddWebApiExceptionFilter(this HttpConfiguration httpConfig)
        {
            httpConfig.Filters.Add(new WebApiExceptionFilter());
        }

        public static void AddMvcExceptionFilter(this GlobalFilterCollection filters)
        {
            filters.Add(new MvcExceptionFilter());
        }
    }
}