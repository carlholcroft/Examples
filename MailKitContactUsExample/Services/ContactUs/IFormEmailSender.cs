using MailKit.Net.Smtp;
using MailKitContactUsExample.Models.ContactUs;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MailKitContactUsExample.Services.ContactUs
{
    public interface IFormEmailSender
    {
        Task SendEmailAsync(string name, string email, string subject, string message);
    }

    public class EmailSenderForm : IFormEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostEnvironment _env;

        public EmailSenderForm(
            IOptions<EmailSettings> emailSettings,
            IHostEnvironment env)
        {
            _emailSettings = emailSettings.Value;
            _env = env;
        }

        public async Task SendEmailAsync(string name, string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));

                mimeMessage.To.Add(new MailboxAddress(name, email));

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_env.IsDevelopment())
                    {
                        // The third parameter is useSSL (true if the client should make an SSL-wrapped
                        // connection to the server; otherwise, false).
                        await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true);
                    }
                    else
                    {
                        await client.ConnectAsync(_emailSettings.MailServer);
                    }

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
