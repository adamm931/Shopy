using Shopy.Infrastructure.Logging;
using Shopy.Infrastructure.Logging.DI;
using Shopy.Public.Service;
using Shopy.Sdk;
using Shopy.Web;
using Unity;

namespace Shopy.Public.Unity
{
    public class ShopyPublicUnityInstaller : IUnityInstaller
    {
        public void InstallUnity(IUnityContainer container)
        {
            container.RegisterInstance(ShopyDriveBuilder.GetDriver());
            container.RegisterAutoMapper<ShopyPublicUnityInstaller>();
            container.RegisterType<IProductsViewModelService, ProductsViewModelService>();
            container.AddLogging(factory =>
            {
                factory.AddFile(options => options.PathKey = "Logger.FilePath");
            });
        }
    }
}