using Shopy.Core.Logging;
using Shopy.Infrastructure.Logging.Options;
using System;

namespace Shopy.Infrastructure.Logging.Internal
{
    internal class FileLoggerProvider : ILoggerProvider
    {
        private readonly FileLoggerOptions _options;

        internal FileLoggerProvider(Action<FileLoggerOptions> optionsConfiguration)
        {
            _options = FileLoggerOptions.Configure(optionsConfiguration);
        }

        public ILogger GetLogger()
        {
            return new FileLogger(_options);
        }
    }
}
