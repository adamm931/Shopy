using System;
using System.Configuration;
using System.IO;

namespace Shopy.Api.Logging
{
    public class Logger : ILogger
    {
        private const string DirectoryPathKey = "Logger.Directory";

        private const string LogFileName = "Shopy-Logs.txt";

        private static ILogger _instance = null;

        public static ILogger Instance => _instance ??= new Logger();

        private Logger()
        {
        }

        public void LogMessage(string message)
        {
            var path = EnsureLogFilePath();

            using var stream = File.AppendText(path);

            stream.WriteLine(DateTime.Now.ToString() + message);
            stream.WriteLine(new string('-', 100));
        }

        public string EnsureLogFilePath()
        {
            var directoryPath = ConfigurationManager.AppSettings[DirectoryPathKey];

            if (directoryPath == null)
            {
                throw new Exception("Directory path is not in configuration");
            }

            var filePath = @$"{directoryPath}\{LogFileName}";


            if (File.Exists(filePath))
            {
                return filePath;
            }

            Directory.CreateDirectory(directoryPath);

            var file = File.Create(filePath);
            file.Close();

            return filePath;
        }
    }
}