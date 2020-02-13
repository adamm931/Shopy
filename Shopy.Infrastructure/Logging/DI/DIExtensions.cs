using Shopy.Core.Logging;
using System;
using Unity;

namespace Shopy.Infrastructure.Logging.DI
{
    public static class DIExtensions
    {
        public static void AddLogging(this IUnityContainer container, Action<ILoggerFactory> factoryConfiguration)
        {
            var factory = new LoggerFactory();

            factoryConfiguration(factory);

            var logger = factory.GetLogger();

            container.RegisterInstance(logger);
        }
    }
}
