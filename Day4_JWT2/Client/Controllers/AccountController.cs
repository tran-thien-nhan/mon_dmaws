using Client.Models;
using Client.StaticVariable;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client.Controllers
{
    public class AccountController : Controller
    {
        HttpClient client = new HttpClient();
        string uriAuth = "https://localhost:7048/api/Auth/";
        string uriProduct = "https://localhost:7048/api/product/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var accountLogin = new AccountLogin { Email = username, Password = password };
            var result = client.PostAsJsonAsync(uriAuth, accountLogin).Result;
            if (result.IsSuccessStatusCode) //200
            {
                var response = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                var token = response["token"].ToString();
                UserToken.Token = token;
                ViewBag.success = "login successfully !";
                return RedirectToAction("List");
            }
            //ko phai 200
            ViewBag.error = "login fail";
            return View("Index");
        }

        public IActionResult List()
        {
            var result = client.GetStringAsync(uriProduct).Result;
            var list = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + UserToken.Token);
            var result = client.PostAsJsonAsync<Product>(uriProduct, product).Result;
            if (result.IsSuccessStatusCode)
            {
                ViewBag.success = "created successfully !";
                return RedirectToAction("list");
            }
            else if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized) //401
            {
                ViewBag.error = "Please Login !";
            }
            else if (result.StatusCode == System.Net.HttpStatusCode.Forbidden) //403
            {
                ViewBag.error = "you dont have a permission !";
            }
            ViewBag.error = "create must not be null !";
            return View("Index");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + UserToken.Token);

            // Gửi yêu cầu DELETE đến API
            var result = await client.DeleteAsync($"{uriProduct}+{id}");

            // Xử lý kết quả trả về từ API
            if (result.IsSuccessStatusCode)
            {
                ViewBag.success = "deleted successfully!";
                return RedirectToAction("List");
            }

            ViewBag.error = "fail to delete!";
            return View();
        }
    }
}
