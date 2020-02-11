using Shopy.Infrastructure.Logging;

namespace Shopy.Core.Logging
{
    public class LoggerFactory
    {
        public static ILogger GetLogger(string type)
        {
            if (type == "File")
            {
                return new FileLogger();
            }

            if (type == "EventLog")
            {
                return new EventLogLogger();
            }

            return null;
        }
    }
}
