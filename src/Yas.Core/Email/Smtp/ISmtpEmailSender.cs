using System.Net.Mail;
using System.Threading.Tasks;

namespace Yas.Core.Email.Smtp
{
    /// <summary>
    /// SMTP邮件发送接口
    /// </summary>
    public interface ISmtpEmailSender : IEmailSender
    {
        /// <summary>
        /// 创建SMTP客户端
        /// </summary>
        /// <returns></returns>
        Task<SmtpClient> BuildClientAsync();
    }
}
