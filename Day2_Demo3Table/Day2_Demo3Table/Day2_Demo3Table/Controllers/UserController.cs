using Day2_Demo3Table.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2_Demo3Table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;

        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet("{email}/{password}")]
        public async Task<ActionResult> CheckLogin(string email, string password)
        {
            var user = await userRepo.Login(email, password);
            return Ok(user);
        }

    }
}
