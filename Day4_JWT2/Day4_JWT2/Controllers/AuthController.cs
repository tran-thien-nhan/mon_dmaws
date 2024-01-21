using Day4_JWT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day4_JWT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext db;
        private readonly IConfiguration configuration;

        public AuthController(DatabaseContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration; //đọc thông tin trong appsetting.json
        }

        [NonAction]
        private async Task<Account> Authenticate(AccountLogin AccountLogin)
        {
            var listAccount = await db.Accounts.ToListAsync();
            if (listAccount != null && listAccount.Count > 0)
            {
                var currentAccount = listAccount.SingleOrDefault(u => u.Email.ToLower() == AccountLogin.Email.ToLower() && u.Password == AccountLogin.Password);
                return currentAccount;
            }
            return null;
        }

        [NonAction]
        private string GenerateToken(Account Account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // lưu vào claim
            var claims = new[]
            {
              new Claim("Name", Account.Name),
              new Claim("Email", Account.Email),
              new Claim(ClaimTypes.Role, Account.Role),
          };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(50), signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(AccountLogin accountLogin)
        {
            var user = await Authenticate(accountLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(new { token });
            }
            return NotFound("user not found");
        }
    }
}
