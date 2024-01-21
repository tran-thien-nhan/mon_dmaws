﻿using day8_DemoMail.Models;
using day8_DemoMail.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace day8_DemoMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;

        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendMailAsync(request);
                return Ok();
            }
            catch
            {
                throw;
            }
        }
    }
}
