using System;

namespace Shopy.Core.Logging
{
    public interface ILogger
    {
        void Info(string message);

        void Error(string message);

        void Error(Exception exception);
    }
}