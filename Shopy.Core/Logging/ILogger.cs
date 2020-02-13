namespace Shopy.Core.Logging
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel);
    }
}