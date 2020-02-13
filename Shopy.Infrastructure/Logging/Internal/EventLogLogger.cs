using Shopy.Core.Logging;
using System.Diagnostics;

namespace Shopy.Infrastructure.Logging
{
    internal class EventViewerLogger : ILogger
    {
        internal EventViewerLogger()
        {
            // EventLog.("Shopy", "ShopyLog");
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Information)
            {
                EventLog.WriteEntry("Shopy", message, EventLogEntryType.Information);
            }

            else if (logLevel == LogLevel.Debug)
            {
                EventLog.WriteEntry("Shopy", message, EventLogEntryType.Information);
            }

            else if (logLevel == LogLevel.Warning)
            {
                EventLog.WriteEntry("Shopy", message, EventLogEntryType.Warning);
            }

            else if (logLevel == LogLevel.Error)
            {
                EventLog.WriteEntry("Shopy", message, EventLogEntryType.Error);
            }

            else
            {
                EventLog.WriteEntry("Shopy", message, EventLogEntryType.Error);
            }
        }
    }
}
