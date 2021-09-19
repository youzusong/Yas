using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Yas.Core.DependencyInjection;
using Yas.Core.Excepting;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务执行者
    /// </summary>
    public class DefaultBackgroundJobExecuter : IBackgroundJobExecuter, ITransientDependency
    {
        protected BackgroundJobOptions Options { get; }

        protected ILogger<DefaultBackgroundJobExecuter> Logger { get; }

        public DefaultBackgroundJobExecuter(
            IOptions<BackgroundJobOptions> options,
            ILogger<DefaultBackgroundJobExecuter> logger)
        {
            this.Options = options.Value;
            this.Logger = logger;
        }

        public virtual async Task ExecuteAsync(BackgroundJobExecutionContext context)
        {
            var job = context.ServiceProvider.GetService(context.JobType);
            if (job == null)
                throw new YasException($"后台任务类型未注册[{context.JobType}]");

            var jobExtMethod = context.JobType.IsAssignableFrom(typeof(IAsyncBackgroundJob<>))
                ? context.JobType.GetMethod(nameof(IAsyncBackgroundJob<object>.ExecuteAsync))
                : context.JobType.GetMethod(nameof(IBackgroundJob<object>.Execute));

            if (jobExtMethod == null)
                throw new YasException($"后台任务类型未继承后台任务接口[{context.JobType}]");

            try
            {
                if (jobExtMethod.Name == nameof(IAsyncBackgroundJob<object>.ExecuteAsync))
                    await ((Task)jobExtMethod.Invoke(job, new[] { context.JobArgs }));
                else
                    jobExtMethod.Invoke(job, new[] { context.JobArgs });
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);

                await context.ServiceProvider
                    .GetRequiredService<IExceptionNotifier>()
                    .NotifyAsync(new ExceptionNotificationContext(context.ServiceProvider, ex));

                throw new BackgroundJobExecutionException("后台任务执行失败", ex)
                {
                    JobType = context.JobType,
                    JobArgs = context.JobArgs
                };
            }
        }
    }
}
