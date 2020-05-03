using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels.Implementations;
using Shopy.Admin.ViewModels.Interfaces;
using Shopy.Infrastructure.Logging;
using Shopy.Infrastructure.Logging.DI;
using Shopy.Sdk;
using Shopy.Web;
using System;
using Unity;

namespace Shopy.Admin.Unity
{
    public class ShopyAdminUnityInstaller : IUnityInstaller
    {
        public void InstallUnity(IUnityContainer container)
        {
            container.RegisterInstance(ShopyDriveBuilder.GetDriver());
            container.RegisterType<IAuthenticationUtils, AuthenticationUtils>();
            container.RegisterType<ISelectListUtils, SelectListUtils>();
            container.RegisterType(typeof(Lazy<>));
            container.RegisterType<IProductViewModelService, ProductViewModelService>();
            container.RegisterType<ICategoryViewModelService, CategoriesViewModelService>();
            container.RegisterAutoMapper<SelectListUtils>();

            container.AddLogging(factory =>
            {
                factory.AddFile(options => options.PathKey = "Logger.FilePath");
            });
        }
    }
}