using Shopy.Infrastructure.Logging.Options;
using System;
using System.Configuration;
using System.IO;

namespace Shopy.Core.Logging
{
    internal class FileLogger : ILogger
    {
        private string _path;

        internal FileLogger(FileLoggerOptions options)
        {
            InitializeFromOptions(options);
        }

        private string EnsureLogFilePath()
        {
            if (File.Exists(_path))
            {
                return _path;
            }

            var fileInfo = new FileInfo(_path);

            Directory.CreateDirectory(fileInfo.Directory.FullName);

            fileInfo
                .Create()
                .Close();

            return _path;
        }

        private void WriteMessage(string message, LogLevel logLevel)
        {
            var path = EnsureLogFilePath();

            using var stream = File.AppendText(path);

            stream.WriteLine($"{logLevel}: {DateTime.Now} {new string('-', 90)}");
            stream.WriteLine(message);
            stream.WriteLine(new string('-', 100));
        }

        private void InitializeFromOptions(FileLoggerOptions options)
        {
            _path = options.Path ?? ConfigurationManager.AppSettings[options.PathKey];

            if (string.IsNullOrEmpty(_path))
            {
                throw new Exception("File logger path could not be resoled");
            }
        }

        public void Log(string message, LogLevel logLevel)
        {
            WriteMessage(message, logLevel);
        }
    }
}