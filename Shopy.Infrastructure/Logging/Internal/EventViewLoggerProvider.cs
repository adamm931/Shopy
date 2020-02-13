using Shopy.Core.Logging;

namespace Shopy.Infrastructure.Logging
{
    internal class EventViewerLoggerProvider : ILoggerProvider

    {
        public ILogger GetLogger()
        {
            return new EventViewerLogger();
        }
    }
}
