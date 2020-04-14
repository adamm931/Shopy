using Shopy.Application.Products.Add;
using Shopy.Core.Data;
using Shopy.Data;
using Shopy.Infrastructure.Logging;
using Shopy.Infrastructure.Logging.DI;
using System;
using Unity;
using Unity.Lifetime;

namespace Shopy.Api.DI
{
    public class DIContainer : UnityContainer
    {
        private static readonly Lazy<DIContainer> _instanceProvider = new Lazy<DIContainer>(CreateContainer, isThreadSafe: true);

        public static DIContainer Instance => _instanceProvider.Value;

        private DIContainer()
        {
        }

        private static DIContainer CreateContainer()
        {
            var container = new DIContainer();

            container
                .RegisterMediator(new HierarchicalLifetimeManager())
                .RegisterMediatorHandlers(typeof(AddProductResponse).Assembly);

            //container.RegisterFactory<IShopyContext>(container => ShopyContextFactory.CreateContext(), new PerThreadLifetimeManager());

            container.RegisterType<IShopyContext, ShopyContext>();

            container.AddLogging(factory =>
            {
                factory
                    .AddFile(options => options.PathKey = "Logger.FilePath")
                    .AddEventViewer();
            });

            return container;
        }
    }
}