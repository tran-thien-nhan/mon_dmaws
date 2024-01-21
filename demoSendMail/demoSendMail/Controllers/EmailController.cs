using demoSendMail.Models;
using demoSendMail.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoSendMail.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult SendEmail()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string toEmail, string subject, string body)
        {
            await _emailService.SendEmailAsync(toEmail, subject, body);
            return Content("Email sent successfully!");
        }
    }
}
