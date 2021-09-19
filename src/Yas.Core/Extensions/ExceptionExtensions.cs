using Microsoft.Extensions.Logging;
using Yas.Core.Logging;

namespace System
{
    public static class ExceptionExtensions
    {
        public static LogLevel GetLogLevel(this Exception exception, LogLevel defaultLevel = LogLevel.Error)
        {
            return (exception as IHasLogLevel)?.LogLevel ?? defaultLevel;
        }
    }
}
