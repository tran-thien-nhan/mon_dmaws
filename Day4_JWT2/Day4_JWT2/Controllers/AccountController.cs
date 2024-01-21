using Day4_JWT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day4_JWT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DatabaseContext db;

        public AccountController(DatabaseContext db)
        {
            this.db = db;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")] //kiểm tra đăng nhập
        public async Task<ActionResult> GetAccount(int id)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(acc);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostAccount(Account account)
        {
            db.Accounts.Add(account);
            await db.SaveChangesAsync();
            return Ok(account);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAccounts()
        {
            return Ok(await db.Accounts.ToListAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveAccount(int id)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(x => x.Id == id);
            if (acc != null)
            {
                db.Accounts.Remove(acc);
                await db.SaveChangesAsync();
                return Ok(new { message = "remove account successfully" });
            }
            return Ok(new { message = "no account to be removed" });
        }
    }
}
