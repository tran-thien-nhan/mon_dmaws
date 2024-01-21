using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Principal;

namespace Client.Controllers
{
    public class EmployeeController : Controller
    {
        string uri = "https://localhost:7049/api/Employee/"; //7049, 7295
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult checkLogin(string id, string password)
        {
            try
            {
                var result = client.GetStringAsync(uri + "checklogin/" + id + "/" + password).Result;
                var resultLogin = JsonConvert.DeserializeObject<bool>(result);
                if (resultLogin)
                {
                    var result1 = client.GetStringAsync(uri + "findone/" + id).Result;
                    var resultLogin1 = JsonConvert.DeserializeObject<Employee>(result1);
                    if (resultLogin1.Role == true)
                    {
                        return View("ListEmployee");
                    }
                    return View("ErrorPage");
                }
                return View("Index");
            }
            catch (Exception ex) 
            {
                ViewBag.error = ex.Message;
                return View("Index");
            }
        }

        public IActionResult ListEmployee()
        {
            var result = client.GetStringAsync(uri + "findall").Result;
            var listEmp = JsonConvert.DeserializeObject<List<Employee>>(result);
            return View(listEmp);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Update(string id)
        {
            return View();
        }

        public IActionResult Update(Employee employee)
        {
            var result = client.PutAsJsonAsync(uri + "updateemployee/" + employee.EmployeeID, employee).Result;
            if (result.IsSuccessStatusCode)
            {
                return View(employee);
            }
            return View(employee);
        }
    }
}
