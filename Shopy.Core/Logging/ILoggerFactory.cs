namespace Shopy.Core.Logging
{
    public interface ILoggerFactory
    {
        ILogger GetLogger();

        void AddProvider(ILoggerProvider loggerProvider);
    }
}
