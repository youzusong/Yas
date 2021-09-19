using System.Threading.Tasks;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务(异步)接口
    /// </summary>
    /// <typeparam name="TArgs">任务参数类型</typeparam>
    public interface IAsyncBackgroundJob<in TArgs>
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task ExecuteAsync(TArgs args);
    }
}
