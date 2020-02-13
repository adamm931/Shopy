using System;

namespace Shopy.Infrastructure.Logging.Options
{
    public class FileLoggerOptions
    {
        public string Path { get; set; }

        public string PathKey { get; set; }

        internal static FileLoggerOptions Configure(Action<FileLoggerOptions> applier)
        {
            var options = new FileLoggerOptions();

            applier(options);

            return options;
        }

        private FileLoggerOptions()
        {
        }
    }
}
