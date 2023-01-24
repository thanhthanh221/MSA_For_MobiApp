using MailKit.Security;
using Message.Interfaces;
using Message.Settings;
using Message.ViewModel;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Message.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly MailSettings mailSettings;

        private readonly ILogger<SendMailService> logger;
        public SendMailService(IOptions<MailSettings> mailSettings, ILogger<SendMailService> logger)
        {
            this.mailSettings = mailSettings.Value;
            this.logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await this.SendMail(new SendMailViewModel() {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }

        public async Task SendMail(SendMailViewModel model)
        {
            MimeMessage email = new() {
                Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail)
            };
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(model.To));
            email.Subject = model.Subject;

            BodyBuilder builder = new() {
                HtmlBody = model.Body
            };
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using MailKit.Net.Smtp.SmtpClient smtp = new();
            try {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex) {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - {Save} ", emailsavefile);
                logger.LogError("{message}", ex.Message);
            }
            smtp.Disconnect(true);
            logger.LogInformation("send mail to {Name} ", model.To);
        }
    }
}
