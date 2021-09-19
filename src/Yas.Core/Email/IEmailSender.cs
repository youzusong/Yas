using System.Net.Mail;
using System.Threading.Tasks;

namespace Yas.Core.Email
{
    /// <summary>
    /// 邮件发送接口
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="mail">邮件</param>
        /// <param name="normalize">标准化</param>
        /// <returns></returns>
        Task SendAsync(MailMessage mail, bool normalize = true);

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="from">寄信人</param>
        /// <param name="to">收信人</param>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="isBodyHtml">是否为HTML内容</param>
        /// <returns></returns>
        Task SendAsync(
            string from,
            string to,
            string subject,
            string body,
            bool isBodyHtml = true
        );

        /// <summary>
        /// 暂存
        /// </summary>
        /// <param name="from">寄信人</param>
        /// <param name="to">收信人</param>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="isHtmlBody">是否为HTML内容</param>
        /// <returns></returns>
        Task QueueAsync(
            string from,
            string to,
            string subject,
            string body,
            bool isHtmlBody = true
        );

    }
}
