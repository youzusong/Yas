using System.Threading.Tasks;

namespace Yas.Core.Email.Smtp
{
    /// <summary>
    /// SMTP邮件发送配置接口
    /// </summary>
    public interface ISmtpEmailSenderConfiguration: IEmailSenderConfiguration
    {
        /// <summary>
        /// 获取主机
        /// </summary>
        /// <returns></returns>
        Task<string> GetHostAsync();

        /// <summary>
        /// 获取端口
        /// </summary>
        /// <returns></returns>
        Task<int> GetPortAsync();

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        Task<string> GetUserNameAsync();

        /// <summary>
        /// 获取密码
        /// </summary>
        /// <returns></returns>
        Task<string> GetPasswordAsync();

        /// <summary>
        /// 获取域名
        /// </summary>
        /// <returns></returns>
        Task<string> GetDomainAsync();

        /// <summary>
        /// 获取SSL启用状态
        /// </summary>
        /// <returns></returns>
        Task<bool> GetEnableSslAsync();

        /// <summary>
        /// 获取默认凭据启用状态
        /// </summary>
        /// <returns></returns>
        Task<bool> GetUseDefaultCredentialsAsync();
    }
}
