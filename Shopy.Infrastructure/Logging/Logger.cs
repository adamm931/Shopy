using Shopy.Core.Logging;
using System.Collections.Generic;

namespace Shopy.Infrastructure.Logging
{
    internal class Logger : ILogger
    {
        private readonly List<ILogger> _loggers;

        internal Logger(List<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public void Log(string message, LogLevel logLevel)
        {
            foreach (var logger in _loggers)
            {
                try
                {
                    logger.Log(message, logLevel);
                }

                catch
                {
                    // for now do nothing when logging breaks
                }
            }
        }
    }
}
