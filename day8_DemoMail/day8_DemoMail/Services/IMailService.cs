using day8_DemoMail.Models;

namespace day8_DemoMail.Services
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
    }
}
