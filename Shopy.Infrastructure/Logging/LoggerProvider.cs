using Shopy.Core.Logging;
using System.Configuration;

namespace Shopy.Infrastructure.Logging
{
    public class LoggerProvider : ILoggerProvider
    {
        private const string LoggerType = "LoggerType";

        public ILogger GetLogger()
        {
            var loggerType = ConfigurationManager.AppSettings[LoggerType];

            var logger = LoggerFactory.GetLogger(loggerType);

            return logger;
        }
    }
}
