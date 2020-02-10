using System;
using System.Configuration;
using System.IO;

namespace Shopy.Core.Logging
{
    internal class Logger : ILogger
    {
        private const string DirectoryPathKey = "Logger.Directory";

        private const string LogFileName = "Shopy-Logs.txt";

        private static ILogger _instance = null;

        public static ILogger Instance => _instance ??= new Logger();

        private Logger()
        {
        }

        public void Info(string message)
        {
            WriteMessage("INFO", message);
        }

        public void Error(string message)
        {
            WriteMessage("ERROR", message);
        }

        public void Error(Exception exception)
        {
            Error(exception.ToString());
        }

        private string EnsureLogFilePath()
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

        private void WriteMessage(string type, string message)
        {
            var path = EnsureLogFilePath();

            using var stream = File.AppendText(path);

            stream.WriteLine($"{type}: {DateTime.Now} {new string('-', 90)}");
            stream.WriteLine(message);
            stream.WriteLine(new string('-', 100));
        }
    }
}