using System;
using System.Collections.Generic;
using System.Text;
using Yas.Core.Excepting;

namespace Microsoft.Extensions.Logging
{
    public static class LoggerExtensions
    {
        public static void LogWithLevel(this ILogger logger, LogLevel logLevel, string msg)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    logger.LogCritical(msg);
                    break;

                case LogLevel.Error:
                    logger.LogError(msg);
                    break;

                case LogLevel.Warning:
                    logger.LogWarning(msg);
                    break;

                case LogLevel.Information:
                    logger.LogInformation(msg);
                    break;

                case LogLevel.Trace:
                    logger.LogTrace(msg);
                    break;

                default:
                    logger.LogDebug(msg);
                    break;
            }
        }

        public static void LogWithLevel(this ILogger logger, LogLevel logLevel, string msg, Exception ex)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    logger.LogCritical(ex, msg);
                    break;

                case LogLevel.Error:
                    logger.LogError(ex, msg);
                    break;

                case LogLevel.Warning:
                    logger.LogWarning(ex, msg);
                    break;

                case LogLevel.Information:
                    logger.LogInformation(ex, msg);
                    break;

                case LogLevel.Trace:
                    logger.LogTrace(ex, msg);
                    break;

                default:
                    logger.LogDebug(ex, msg);
                    break;
            }
        }

        public static void LogKnownProperties(ILogger logger, Exception ex, LogLevel logLevel)
        {
            if (ex is IHasErrorCode exWithErrorCode)
            {
                logger.LogWithLevel(logLevel, "ErrorCode:" + exWithErrorCode.ErrorCode);
            }

            if (ex is IHasErrorDetails exWithErrorDetails)
            {
                logger.LogWithLevel(logLevel, "ErrorDetails:" + exWithErrorDetails.ErrorDetails);
            }
        }

        public static void LogSelf(this ILogger logger, Exception exception)
        {
            var loggingExceptions = new List<IHasSelfLogging>();

            if (exception is IHasSelfLogging)
            {
                loggingExceptions.Add(exception as IHasSelfLogging);
            }
            else if (exception is AggregateException && exception.InnerException != null)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerException is IHasSelfLogging)
                {
                    loggingExceptions.Add(aggException.InnerException as IHasSelfLogging);
                }

                foreach (var innerException in aggException.InnerExceptions)
                {
                    if (innerException is IHasSelfLogging)
                    {
                        loggingExceptions.AddIfNotContains(innerException as IHasSelfLogging);
                    }
                }
            }

            foreach (var ex in loggingExceptions)
            {
                ex.SelfLog(logger);
            }
        }

        private static void LogData(ILogger logger, Exception ex, LogLevel logLevel)
        {
            if (ex.Data == null || ex.Data.Count <= 0)
                return;

            var exceptionData = new StringBuilder();
            exceptionData.AppendLine("---------- Exception Data ----------");
            foreach (var key in ex.Data.Keys)
            {
                exceptionData.AppendLine($"{key} = {ex.Data[key]}");
            }

            logger.LogWithLevel(logLevel, exceptionData.ToString());
        }

        public static void LogException(this ILogger logger, Exception ex, LogLevel? level = null)
        {
            var exLevel = level ?? ex.GetLogLevel();
            LogWithLevel(logger, exLevel, ex.Message, ex);
            LogKnownProperties(logger, ex, exLevel);
            LogSelf(logger, ex);
            LogData(logger, ex, exLevel);
        }
    }
}
