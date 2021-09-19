using System.Threading.Tasks;

namespace Yas.Core.Email
{
    /// <summary>
    /// 邮件发送配置接口
    /// </summary>
    public interface IEmailSenderConfiguration
    {
        /// <summary>
        /// 获取寄信者地址
        /// </summary>
        /// <returns></returns>
        Task<string> GetAddressAsync();

        /// <summary>
        /// 获取寄信者名称
        /// </summary>
        /// <returns></returns>
        Task<string> GetDisplayNameAsync();
    }
}
