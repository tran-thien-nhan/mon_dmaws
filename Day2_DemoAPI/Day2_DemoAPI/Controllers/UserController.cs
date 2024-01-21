using Day2_DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Day2_DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserDbContext db;

        public UserController(UserDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var list = await db.Users.ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsers(User user)
        {
            try
            {
                db.Users.Add(user);
                var result = await db.SaveChangesAsync();
                if (result == 1)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest(); //code: 400
                }
            }
            catch (Exception ex)
            {
                return BadRequest(); //code: 400
            }
        }

        [HttpGet("{username}")] // /api/User/{username}
        public async Task<ActionResult> GetUser(string username)
        {
            var user = await db.Users.SingleOrDefaultAsync(x => x.Username == username);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> PutUser(User user)
        {
            var oldUser = await db.Users.SingleOrDefaultAsync(u  => u.Username == user.Username);   
            if (oldUser != null)
            {
                oldUser.Password = user.Password;
                oldUser.Name = user.Name;
                oldUser.YoB = user.YoB;
                await db.SaveChangesAsync();
                return NoContent(); //200, without body
            }
            return BadRequest();
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteUser(string username)
        {
            var deleteUser = await db.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (deleteUser != null)
            {
                db.Users.Remove(deleteUser);
                await db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
