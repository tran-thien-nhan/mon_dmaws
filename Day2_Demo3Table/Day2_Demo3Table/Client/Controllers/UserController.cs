using Client.Models;
using Client.ModelStatic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:7120/api/User/";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var result = client.GetStringAsync(uri + username + "/" + password).Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            if(user != null)
            {
                UserStatic.userId = user.Id;
                return Redirect("/Product"); //chuyen toi productController
            }
            ViewBag.error = "Invalid username or password";
            return View("Index");
        }
    }
}
