using System.Threading.Tasks;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务执行者接口
    /// </summary>
    public interface IBackgroundJobExecuter
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        Task ExecuteAsync(BackgroundJobExecutionContext context);
    }
}
