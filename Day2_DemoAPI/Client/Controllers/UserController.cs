using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        string uri = "https://localhost:7072/api/User/";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            var result = client.GetStringAsync(uri).Result;
            var list = JsonConvert.DeserializeObject<IEnumerable<User>>(result);
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                var result = client.PostAsJsonAsync(uri, user).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Edit(string username)
        {
            //localhost:xxx/api/User/user1
            var result = client.GetStringAsync(uri + username).Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                var result = client.PutAsJsonAsync(uri, user).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Delete(string username)
        {
            var result = client.DeleteAsync(uri + username).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Redirect("/Home/Error");
        }
    }
}
