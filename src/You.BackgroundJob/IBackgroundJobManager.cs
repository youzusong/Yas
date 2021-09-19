using System;
using System.Threading.Tasks;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务管理者接口
    /// </summary>
    public interface IBackgroundJobManager
    {
        /// <summary>
        /// 任务入队
        /// </summary>
        /// <typeparam name="TArgs">任务参数类型</typeparam>
        /// <param name="args">任务参数</param>
        /// <param name="priority">任务级别</param>
        /// <param name="delayTime">延迟执行时间</param>
        /// <returns>任务ID</returns>
        Task<string> EnqueueAsync<TArgs>(
            TArgs args,
            BackgroundJobPriority priority = BackgroundJobPriority.Normal,
            TimeSpan? delayTime = null
        );
    }
}
