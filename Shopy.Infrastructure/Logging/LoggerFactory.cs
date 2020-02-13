using Shopy.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Infrastructure.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly List<ILoggerProvider> _loggerProviders = new List<ILoggerProvider>();

        public void AddProvider(ILoggerProvider loggerProvider)
        {
            if (loggerProvider == null)
            {
                throw new ArgumentNullException(nameof(loggerProvider));
            }

            _loggerProviders.Add(loggerProvider);
        }

        public ILogger GetLogger()
        {
            var loggers = _loggerProviders
                .Select(provider => provider.GetLogger())
                .ToList();

            return new Logger(loggers);
        }
    }
}
