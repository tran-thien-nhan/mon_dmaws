using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pretest_3.Models;

namespace Pretest_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext db;

        public AccountController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("login/{username}/{password}")]
        public async Task<Account> GetLogin(string username, string password)
        {
            var acc = await db.accounts.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if(acc != null)
            {
                return acc;
            }
            return null;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<Account>> GetAllAcc()
        {
            var list = await db.accounts.ToListAsync();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        [HttpGet("withdraw/{username}/{amount}")]
        public async Task<bool> GetWithDraw(string username, int amount)
        {
            var acc = await db.accounts.SingleOrDefaultAsync(a => a.Username == username);
            if(acc != null)
            {
                acc.Balance -= amount;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpGet("getone/{username}/{password}")]
        public async Task<Account> GetOne(string username, string password)
        {
            var acc = await db.accounts.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if (acc != null)
            {
                return acc;
            }
            return null;
        }

        [HttpGet("deposit/{username}/{amount}")]
        public async Task<bool> GetDeposit(string username, int amount)
        {
            var acc = await db.accounts.SingleOrDefaultAsync(a => a.Username == username);
            if (acc != null)
            {
                acc.Balance += amount;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //tạo chức năng hiển thị danh sách các account cùng balance của họ
        [HttpGet("getallbalance")]
        public async Task<IEnumerable<Account>> GetAllBalance()
        {
            var list = await db.accounts.ToListAsync();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        [HttpGet("checklogin/{username}/{password}")]
        public async Task<bool> GetCheckLogin(string username, string password)
        {
            var acc = await db.accounts.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if (acc != null)
            {
                return true;
            }
            return false;
        }
    }
}
