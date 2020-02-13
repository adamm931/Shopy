namespace Shopy.Core.Logging
{
    public class LogLevel
    {
        public string Name { get; }

        public static LogLevel Information = new LogLevel("Information");

        public static LogLevel Debug = new LogLevel("Debug");

        public static LogLevel Error = new LogLevel("Error");

        public static LogLevel Critical = new LogLevel("Critical");

        public static LogLevel Warning = new LogLevel("Warning");

        private LogLevel(string name)
        {
            Name = name;
        }

        public static bool operator ==(LogLevel left, LogLevel right)
        {
            return left.Name == right.Name;
        }

        public static bool operator !=(LogLevel left, LogLevel right)
        {
            return !(left.Name == right.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
