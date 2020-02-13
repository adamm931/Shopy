using System;

namespace Shopy.Core.Logging
{
    public static class LoggerExtensions
    {
        public static void Information(this ILogger logger, string message)
        {
            logger.Log(message, LogLevel.Information);
        }

        public static void Debug(this ILogger logger, string message)
        {
            logger.Log(message, LogLevel.Debug);
        }

        public static void Warning(this ILogger logger, string message)
        {
            logger.Log(message, LogLevel.Warning);
        }

        public static void Error(this ILogger logger, string message)
        {
            logger.Log(message, LogLevel.Error);
        }

        public static void Error(this ILogger logger, Exception exception)
        {
            logger.Log(exception.ToString(), LogLevel.Error);
        }

        public static void Critical(this ILogger logger, string message)
        {
            logger.Log(message, LogLevel.Critical);
        }
    }
}
