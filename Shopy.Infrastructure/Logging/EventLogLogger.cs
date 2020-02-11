using Shopy.Core.Logging;
using System;
using System.Diagnostics;

namespace Shopy.Infrastructure.Logging
{
    public class EventLogLogger : ILogger
    {
        public void Error(string message)
        {
            EventLog.WriteEntry("Shopy", message, EventLogEntryType.Error, 1007);
        }

        public void Error(Exception exception)
        {
            EventLog.WriteEntry("Shopy", exception.ToString(), EventLogEntryType.Error, 1007);
        }

        public void Info(string message)
        {
            EventLog.WriteEntry("Shopy", message, EventLogEntryType.Information, 1007);
        }
    }
}
