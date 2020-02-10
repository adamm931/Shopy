namespace Shopy.Core.Logging
{
    public class LoggerFactory
    {
        public static ILogger GetLogger() => Logger.Instance;
    }
}
