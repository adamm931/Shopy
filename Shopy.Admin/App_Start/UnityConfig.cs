using Shopy.Admin.ModelBuilder;
using Shopy.Admin.Utils;
using Shopy.SDK;
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

            container.RegisterInstance(new ShopyDriveBuilder().Configure());
            container.RegisterType<IAuthenticationUtils, AuthenticationUtils>();
            container.RegisterType<ISelectListUtils, SelectListUtils>();
            container.RegisterType(typeof(ProductListModelBuilder));
            container.RegisterType(typeof(DefaultProductModelBuilder));
            container.RegisterType(typeof(ProductListModelBuilder));
            container.RegisterType(typeof(AddEditProductModelBuidler));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}