using Client.Models;
using Client.ModelStatic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:7120/api/Product/";

        public IActionResult Index()
        {
            var result = client.GetStringAsync(uri).Result;
            var list = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            return View(list);
        }

        public IActionResult AddCart(int id) 
        { 
            var cart = new Cart();  
            cart.ProductId = id;
            cart.Quantity = 1;
            cart.UserId = UserStatic.userId;
            var result = client.PostAsJsonAsync(uri, cart).Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Redirect("/Home/Error");
        }

        public IActionResult ShowCart()
        {
            var result = client.GetStringAsync(uri + "showCart/" + UserStatic.userId).Result;
            var listCart = JsonConvert.DeserializeObject<IEnumerable<Cart>>(result);
            return View(listCart);
        }

        public IActionResult DeleteCart(int cartId)
        {
            var result = client.DeleteAsync(uri + "deleteCart/" + cartId).Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCart");
            }
            return Redirect("/Home/Error");
        }

    }
}
