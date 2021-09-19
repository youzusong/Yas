using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Yas.Core.Email
{
    /// <summary>
    /// 邮件发送基类
    /// </summary>
    public abstract class EmailSenderBase : IEmailSender
    {
        protected IEmailSenderConfiguration Configuration { get; }

        public EmailSenderBase(IEmailSenderConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected abstract Task HandleSendAsync(MailMessage mail);

        protected virtual async Task NormalizeMailAsync(MailMessage mail)
        {
            if (mail.From == null || mail.From.Address.IsNullOrEmpty())
            {
                mail.From = new MailAddress(
                    await Configuration.GetAddressAsync(),
                    await Configuration.GetDisplayNameAsync(),
                    Encoding.UTF8);
            }

            if (mail.HeadersEncoding == null)
                mail.HeadersEncoding = Encoding.UTF8;

            if (mail.SubjectEncoding == null)
                mail.SubjectEncoding = Encoding.UTF8;

            if (mail.BodyEncoding == null)
                mail.BodyEncoding = Encoding.UTF8;
        }

        public virtual async Task SendAsync(MailMessage mail, bool normalize = true)
        {
            if (normalize)
                await NormalizeMailAsync(mail);

            await HandleSendAsync(mail);
        }

        public virtual async Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendAsync(new MailMessage(from, to, subject, body) { IsBodyHtml = isBodyHtml });
        }

        public virtual async Task QueueAsync(string from, string to, string subject, string body, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }
    }
}
