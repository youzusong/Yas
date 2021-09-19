using System;
using Yas.Core.DependencyInjection;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务执行上下文
    /// </summary>
    public class BackgroundJobExecutionContext : IServiceProviderAccessor
    {
        /// <summary>
        /// 服务提供者
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public Type JobType { get; }

        /// <summary>
        /// 任务参数
        /// </summary>
        public object JobArgs { get; }

        public BackgroundJobExecutionContext(IServiceProvider serviceProvider, Type jobType, object objArgs)
        {
            this.ServiceProvider = serviceProvider;
            this.JobType = jobType;
            this.JobArgs = JobArgs;
        }
    }
}
