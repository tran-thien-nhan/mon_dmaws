using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TS2210004.Models;

namespace TS2210004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext db;

        public EmployeeController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("checklogin/{id}/{password}")]
        public async Task<bool> checkLogin(string id, string password)
        {
            var emp = await db.Employees.SingleOrDefaultAsync(e => e.EmployeeID == id && e.Password == password);
            if (emp != null)
            {
                return true;
            }
            return false;
        }

        [HttpGet("findall")]
        public async Task<List<Employee>> FindAll()
        {
            var emp = await db.Employees.ToListAsync();
            if (emp != null)
            {
                return emp;
            }
            return null;
        }

        [HttpGet("findone/{EmployeeId}")]
        public async Task<Employee> FindOne(string EmployeeId)
        {
            var emp = await db.Employees.FindAsync(EmployeeId);
            if (emp != null)
            {
                return emp;
            }
            return null;
        }

        [HttpPut("updateemployee/{EmployeeId}")]
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var oldEmp = await db.Employees.FindAsync(employee.EmployeeID);
            if (oldEmp != null)
            {
                oldEmp.EmployeeName = employee.EmployeeName;
                oldEmp.Age = employee.Age;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
