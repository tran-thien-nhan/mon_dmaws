using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace Client.Controllers
{
    public class AccountController : Controller
    {
        string uri = "https://localhost:7092/api/Account/";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var result = client.GetStringAsync(uri + "login/" + username + "/" + password).Result;
                var acc = JsonConvert.DeserializeObject<Account>(result);
                if (acc != null)
                {
                    var balance = acc.Balance.ToString();
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("password", password);
                    HttpContext.Session.SetString("balance", balance);
                    return RedirectToAction("Transaction");
                }
                ViewBag.error = "wrong username or password";
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Index");
            }
        }

        //public IActionResult Transaction()
        //{
        //    return View();
        //}

        public IActionResult Transaction()
        {
            try
            {
                var newUsername = HttpContext.Session.GetString("username");
                var newBalance = HttpContext.Session.GetString("balance");
                var pass = HttpContext.Session.GetString("password");
                var resultFind = client.GetStringAsync(uri + "getone/" + newUsername + "/" + pass).Result;
                var accFind = JsonConvert.DeserializeObject<Account>(resultFind);
                if (accFind != null)
                {
                    ViewBag.balance = accFind.Balance;
                    return View();
                }
                ViewBag.error = "Cannot find this username";
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.error = "login please !";
                return View("Index");
            }
        }
        public IActionResult Withdraw(int amount)
        {
            try
            {
                var newUsername = HttpContext.Session.GetString("username"); //lấy session username
                var newBalance = HttpContext.Session.GetString("balance"); //lấy session balance của username trên
                var pass = HttpContext.Session.GetString("password"); //lấy session password của username trên
                var resultFind = client.GetStringAsync(uri + "getone/" + newUsername + "/" + pass).Result; // gửi request "https://localhost:7092/api/Account/getone/nhan/123" lên backend
                var accFind = JsonConvert.DeserializeObject<Account>(resultFind); //chuyển sang dạng json chứa {username: nhan, password: 123, balance: 1000}
                var accWithdraw = accFind.Balance; // chỉ lấy balance là 1000 của username trên nạp vào biến accWithdraw
                if (accFind != null) //nếu chuỗi json trên khác rỗng
                {
                    if (amount >= 0 && amount <= accWithdraw) //kiểm tra amount nhập vào nếu  thỏa những điều kiện trong ngoặc
                    {
                        var response = client.GetStringAsync(uri + "withdraw/" + newUsername + "/" + amount).Result; //gửi request rút tiền "https://localhost:7092/api/Account/withdraw/nhan/100" lên backend với amount rút là 100
                        var acc = JsonConvert.DeserializeObject<bool>(response); //chuyển kiểu json sang true/ false 
                        if (acc) // nếu rút được thành công (trả về true)
                        {
                            var newBalanceWithdraw = client.GetStringAsync(uri + "getone/" + newUsername + "/" + pass).Result;//lấy balance mới sau khi bị trừ tiền đi của username trên  bằng cách gửi lên backend bằng request getone
                            var accbalanceWithdraw = JsonConvert.DeserializeObject<Account>(newBalanceWithdraw); //lấy chuỗi json mới vd {username: nhan, password: 123, balance: 900}
                            var balanceWithdraw = accbalanceWithdraw.Balance.ToString(); //lấy giá trị balance mới withdraw của username trên, có thêm chuyển sang dạng string để cb nạp lên session
                            HttpContext.Session.SetString("balance", balanceWithdraw); //đẩy lên session giá trị balance vừa mới withdraw
                            ViewBag.success = "Withdraw successfully!"; // thông báo rút tiền thành công
                            return View("Transaction"); //quay lại trang Transaction
                        }
                        // nếu không rút được (trả về false)
                        ViewBag.error = "Withdraw fail...!"; //thông báo rút tiền thất bại
                        return View("Transaction"); // quay về trang Transaction
                    }
                    ViewBag.error = "số tiền rút phải nhỏ hơn số tiền hiện có trong tài khoản"; //nếu không thỏa điều kiện => thông báo lỗi nếu tiền rút < tiền đang có
                    return View("Transaction"); // quay về trang Transaction
                }
                // nếu accFind == null, nghĩa là chuỗi json rỗng
                ViewBag.error = "Cannot find this username"; //thông báo không tìm thấy username này
                return View("Transaction"); // quay về trang Transaction
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Transaction");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }   

        public IActionResult Deposit(int amount)
        {
            try
            {
                var newUsername = HttpContext.Session.GetString("username"); //lấy session username
                var newBalance = HttpContext.Session.GetString("balance"); //lấy session balance của username trên
                var pass = HttpContext.Session.GetString("password"); //lấy session password của username trên
                var resultFind = client.GetStringAsync(uri + "getone/" + newUsername + "/" + pass).Result; // gửi request "https://localhost:7092/api/Account/getone/nhan/123" lên backend
                var accFind = JsonConvert.DeserializeObject<Account>(resultFind); //chuyển sang dạng json chứa {username: nhan, password: 123, balance: 1000}
                var accDeposit = accFind.Balance; // chỉ lấy balance là 1000 của username trên nạp vào biến accWithdraw
                if (accFind != null) //nếu chuỗi json trên khác rỗng
                {
                    var response = client.GetStringAsync(uri + "deposit/" + newUsername + "/" + amount).Result; //gửi request nạp tiền "https://localhost:7092/api/Account/deposit/nhan/100" lên backend vd với amount nạp là 100
                    var acc = JsonConvert.DeserializeObject<bool>(response); //chuyển kiểu json sang true/ false 
                    if (acc) // nếu rút được thành công (trả về true)
                    {
                        var newBalanceDeposit = client.GetStringAsync(uri + "getone/" + newUsername + "/" + pass).Result;//lấy balance mới sau khi bị trừ tiền đi của username trên  bằng cách gửi lên backend bằng request getone
                        var accbalanceDeposit = JsonConvert.DeserializeObject<Account>(newBalanceDeposit); //lấy chuỗi json mới vd {username: nhan, password: 123, balance: 1100}
                        var balanceDeposit = accbalanceDeposit.Balance.ToString(); //lấy giá trị balance mới withdraw của username trên, có thêm chuyển sang dạng string để cb nạp lên session
                        HttpContext.Session.SetString("balance", balanceDeposit); //đẩy lên session giá trị balance vừa mới Deposit
                        ViewBag.success = "Deposit successfully!"; // thông báo nạp tiền thành công
                        return View("Transaction"); //quay lại trang Transaction
                    }
                    // nếu không rút được (trả về false)
                    ViewBag.error = "Deposit fail...!"; //thông báo nạp tiền thất bại
                    return View("Transaction"); // quay về trang Transaction
                }
                // nếu accFind == null, nghĩa là chuỗi json rỗng
                ViewBag.error = "Cannot find this username"; //thông báo không tìm thấy username này
                return View("Transaction"); // quay về trang Transaction
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Transaction");
            }
        }

        [HttpPost]
        public IActionResult Transaction(int amount, string withdraw, string deposit) // nhận 3 giá trị từ trường nhập từ các "name"
        {
            try
            {
                if (!string.IsNullOrEmpty(withdraw)) //nếu trường name="withdraw" dc bấm
                {
                    return Withdraw(amount); //chạy hàm withdraw với name="amount" từ input trong form
                }
                else if (!string.IsNullOrEmpty(deposit)) //nếu trường name="deposit" dc bấm
                {
                    return Deposit(amount); //chạy hàm deposit với name="amount" từ input trong form
                }
                return View(); // không bấm gì thì quay về trang Transaction 
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Transaction");
            }
        }

        //tạo chức năng hiển thị danh sách các account cùng balance của họ
        public IActionResult List()
        {
            try
            {
                var result = client.GetStringAsync(uri + "getallbalance").Result; //gửi request lấy danh sách account lên backend
                var acc = JsonConvert.DeserializeObject<List<Account>>(result); //chuyển chuỗi json sang dạng list
                return View(acc); //trả về view List với dữ liệu là list acc
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Transaction");
            }
        }

    }
}
