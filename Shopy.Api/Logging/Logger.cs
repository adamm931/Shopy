using System;
using System.IO;

namespace Shopy.Api.Logging
{
    public class Logger : ILogger
    {
        private static ILogger _instance = null;

        private string logFilePath;

        public static ILogger Create(string logFilePath)
        {
            if (_instance == null)
            {
                _instance = new Logger(logFilePath);
            }

            return _instance;
        }

        private Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void LogMessage(string message)
        {
            using (var stream = File.AppendText(this.logFilePath))
            {
                stream.WriteLine(DateTime.Now.ToString() + message);
                stream.WriteLine(new string('-', 100));
            }
        }
    }
}