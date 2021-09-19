using System.Threading.Tasks;

namespace Yas.Core.Excepting
{
    /// <summary>
    /// 错误通知者接口
    /// </summary>
    public interface IExceptionNotifier
    {
        /// <summary>
        /// 通知
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        Task NotifyAsync(ExceptionNotificationContext context);
    }
}
