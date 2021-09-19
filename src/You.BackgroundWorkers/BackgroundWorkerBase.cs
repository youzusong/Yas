using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Yas.Core.DependencyInjection;

namespace You.BackgroundWorkers
{
    /// <summary>
    /// 后台工作者基类
    /// </summary>
    public abstract class BackgroundWorkerBase : IBackgroundWorker
    {
        public ILazyServiceProvider LazyServiceProvider { get; set; }

        protected ILoggerFactory LoggerFactory => LazyServiceProvider.LazyGetRequiredService<ILoggerFactory>();

        protected ILogger Logger => LazyServiceProvider.LazyGetService<ILogger>(provider => LoggerFactory?.CreateLogger(GetType().FullName) ?? NullLogger.Instance);

        public virtual Task StartAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogDebug("后台工作者开始工作：" + ToString());
            return Task.CompletedTask;
        }

        public virtual Task StopAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogDebug("后台工作者结束工作：" + ToString());
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
