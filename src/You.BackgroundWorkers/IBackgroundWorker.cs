using Yas.Core.DependencyInjection;
using Yas.Core.Threading;

namespace You.BackgroundWorkers
{
    /// <summary>
    /// 后台工作者接口
    /// </summary>
    public interface IBackgroundWorker : IRunnable, ISingletonDependency
    {

    }
}
