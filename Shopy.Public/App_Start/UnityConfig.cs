using Shopy.Public.Service;
using Shopy.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Shopy.Public
{
    public static class UnityConfig
    {
        public static void RegisterContainer()
        {
            var container = new UnityContainer();
            container.Configure<ProductsViewModelService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}