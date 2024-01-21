using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:7016/api/Auth/";
        public IActionResult Login()
        {
            return View();
        }
    }
}
