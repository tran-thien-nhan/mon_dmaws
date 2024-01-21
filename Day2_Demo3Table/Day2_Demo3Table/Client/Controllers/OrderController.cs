using Client.Models;
using Client.ModelStatic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Client.Controllers
{
    public class OrderController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:7120/api/Order/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.UserId = UserStatic.userId;
            var result = client.PostAsJsonAsync(uri, order).Result;
            if (result.IsSuccessStatusCode)
            {
                //Add order thành công 
                return RedirectToAction("ListOrder");
            }
            //Lỗi
            return Redirect("/Home/Error");
        }

        public IActionResult ListOrder()
        {
            var result = client.GetStringAsync(uri + UserStatic.userId).Result;
            var list = JsonConvert.DeserializeObject<IEnumerable<Order>>(result);
            return View(list);
        }
        public IActionResult Details(int orderId)
        {
            var result = client.GetStringAsync(uri + "Details/" + orderId).Result;
            var order = JsonConvert.DeserializeObject<Order>(result);
            return View(order.Details);
        }

        public IActionResult ExportPDF(int orderId)
        {
            try
            {
                // Call the API endpoint to initiate PDF download
                var response = client.GetAsync($"{uri}exportpdf/{orderId}").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Return the PDF file stream directly to the client
                    return File(response.Content.ReadAsByteArrayAsync().Result, "application/pdf", $"Order_{orderId}.pdf");
                }
                return Redirect("/Home/Error");
            }
            catch (Exception ex)
            {
                // Handle client-side errors
                return StatusCode(500, ex.Message);
            }
        }

    }
}