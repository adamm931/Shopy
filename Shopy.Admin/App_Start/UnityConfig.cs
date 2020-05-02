using Shopy.Admin.Mapping;
using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels.Implementations;
using Shopy.Admin.ViewModels.Interfaces;
using Shopy.Infrastructure.Logging;
using Shopy.Infrastructure.Logging.DI;
using Shopy.Sdk;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Shopy.Admin
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterInstance(ShopyDriveBuilder.GetDriver());
            container.RegisterType<IAuthenticationUtils, AuthenticationUtils>();
            container.RegisterType<ISelectListUtils, SelectListUtils>();
            container.RegisterType(typeof(Lazy<>));
            container.RegisterType<IProductViewModelService, ProductViewModelService>();
            container.RegisterType<ICategoryViewModelService, CategoriesViewModelService>();
            container.RegisterAutoMapper();

            container.AddLogging(factory =>
            {
                factory.AddFile(options => options.PathKey = "Logger.FilePath");
            });

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}