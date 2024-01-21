using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace Client.Controllers
{
    public class EmpController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:7286/api/Emp/";
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
                    return Redirect("MenuEmp");
                }
                return View("Index");
            }
            catch
            {
                ViewBag.error = "Invalid username or password";
                return View("Index");
            }
        }
        public IActionResult ListEmp()
        {
            var result = client.GetStringAsync(uri + "listemp").Result;
            var listEmp = JsonConvert.DeserializeObject<IEnumerable<tblEmp>>(result);
            return View(listEmp);
        }

        public IActionResult MenuEmp()
        {
            return View();
        }

        public IActionResult UpdateSalary()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSalary(tblEmp employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = client.PutAsJsonAsync(uri + "editsalary/" + employee.EmpID + "/" + employee.Salary, employee).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.success = "Cập nhật lương thành công.";
                        return View(employee);
                    }
                    ViewBag.error = "Cập nhật lương fail.";
                    return View(employee);
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                    return View(employee);
                }
            }
            return View();
        }

        public IActionResult Edit(string EmpID)
        {
            tblEmp emp = new tblEmp();
            emp.EmpID = EmpID;
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(tblEmp employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = client.PutAsJsonAsync(uri + "editsalary/" + employee.EmpID + "/" + employee.Salary, employee).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.success = "Cập nhật lương thành công.";
                        return View(employee);
                    }
                    ViewBag.error = "Cập nhật lương fail.";
                    return View(employee);
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                    return View(employee);
                }
            }
            return View();
        }

        public IActionResult MinMaxSalary(float minSalary, float maxSalary)
        {
            try
            {
                if (minSalary == 0 || maxSalary == 0)
                {
                    maxSalary = 10000000;
                }
                var result = client.GetStringAsync(uri + "minMaxSalary/" + minSalary + "/" + maxSalary).Result;
                var listEmp = JsonConvert.DeserializeObject<IEnumerable<tblEmp>>(result);
                return View(listEmp);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        public IActionResult FindOneEmp(string EmpID)
        {
            try
            {
                var result = client.GetStringAsync(uri + "getone/" + EmpID).Result;
                var emp = JsonConvert.DeserializeObject<tblEmp>(result);
                if (emp != null)
                {
                    // Chuyển đổi đối tượng tblEmp thành một danh sách để tránh lỗi
                    var listEmp = new List<tblEmp> { emp };
                    return View("FindOneEmp", listEmp);
                }
                return View("FindOneEmp");
            }
            catch (Exception ex)
            {
                //ViewBag.error = ex.Message;
                return View("FindOneEmp");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblEmp employee)
        {
            if (ModelState.IsValid)
            {
                var result = client.PostAsJsonAsync(uri + "postemp", employee).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListEmp");
                }
            }
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string EmpID)
        {
            var result = client.DeleteAsync(uri + "delete/" + EmpID).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ListEmp");
            }
            return Redirect("/Home/Error");
        }
    }
}
