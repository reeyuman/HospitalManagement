using Hospital.BLL.Abstraction;
using Hospital.BLL.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions options;

        public EmailSender(IOptionsMonitor<EmailOptions> options)
        {
            this.options = options.CurrentValue;
        }
        public void send(string to, string subject, string message)
        {
            var ms = new MimeMessage
            {
                Sender = MailboxAddress.Parse(options.From),
                Subject = subject

            };
            ms.To.Add(MailboxAddress.Parse(to));
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message;
            ms.Body = bodyBuilder.ToMessageBody();
            ms.From.Add(new MailboxAddress("your hospital", options.From));
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect(options.SmtpServer, options.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtpClient.Authenticate(options.From, options.Password);
            smtpClient.Send(ms);
            smtpClient.Disconnect(true);
        }
    }
}
