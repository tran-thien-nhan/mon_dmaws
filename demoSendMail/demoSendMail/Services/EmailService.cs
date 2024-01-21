using MailKit.Net.Smtp;
using MimeKit;

namespace demoSendMail.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("tran thien nhan", "pipclupnomad@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var builder = new BodyBuilder();
            builder.TextBody = body;

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("pipclupnomad@gmail.com", "gujv vlgk njad ghlt");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
