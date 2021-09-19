using Microsoft.Extensions.Logging;
using System;
using Yas.Core.DependencyInjection;

namespace Yas.Core.Excepting
{
    /// <summary>
    /// 错误通知上下文
    /// </summary>
    public class ExceptionNotificationContext : IServiceProviderAccessor
    {
        /// <summary>
        /// 服务提供者
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 错误
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevel LogLevel { get; }

        /// <summary>
        /// 是否已处理
        /// </summary>
        public bool Handled { get; }

        public ExceptionNotificationContext(
            IServiceProvider serviceProvider,
            Exception exception,
            LogLevel? logLevel = null,
            bool handled = true)
        {
            this.ServiceProvider = serviceProvider;
            this.Exception = exception;
            this.LogLevel = logLevel ?? exception.GetLogLevel();
            this.Handled = handled;
        }

    }
}
