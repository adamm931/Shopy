using Shopy.Admin.ViewModels.Implementations;
using Shopy.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Shopy.Admin
{
    public static class UnityConfig
    {
        public static void RegisterContainer()
        {
            var container = new UnityContainer();
            container.Configure<ProductViewModelService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}