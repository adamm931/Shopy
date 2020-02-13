using Shopy.Core.Logging;
using Shopy.Infrastructure.Logging.Internal;
using Shopy.Infrastructure.Logging.Options;
using System;

namespace Shopy.Infrastructure.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory AddEventViewer(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new EventViewerLoggerProvider());

            return loggerFactory;
        }

        public static ILoggerFactory AddFile(this ILoggerFactory loggerFactory, Action<FileLoggerOptions> optionsConfiguration)
        {
            loggerFactory.AddProvider(new FileLoggerProvider(optionsConfiguration));

            return loggerFactory;
        }
    }
}
