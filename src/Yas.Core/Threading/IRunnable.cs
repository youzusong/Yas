using System.Threading;
using System.Threading.Tasks;

namespace Yas.Core.Threading
{
    /// <summary>
    /// 可执行服务接口
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// 开始
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 结束
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default);
    }
}
