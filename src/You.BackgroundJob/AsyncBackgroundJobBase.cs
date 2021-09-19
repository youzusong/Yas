using System.Threading.Tasks;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务(异步)基类
    /// </summary>
    /// <typeparam name="TArgs">任务参数类型</typeparam>
    public abstract class AsyncBackgroundJobBase<TArgs> : IAsyncBackgroundJob<TArgs>
    {
        public AsyncBackgroundJobBase()
        { }

        public abstract Task ExecuteAsync(TArgs args);
    }
}
