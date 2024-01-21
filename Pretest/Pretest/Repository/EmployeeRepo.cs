using Microsoft.EntityFrameworkCore;
using Pretest.Data;
using Pretest.IRepository;
using Pretest.Models;

namespace Pretest.Repository
{
    public class EmployeeRepo : IEmployeRepo
    {
        private readonly AppDbContext db;

        public EmployeeRepo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<tblEmp> AddnewEmp(tblEmp employee)
        {
            var emp = GetOneEmp(employee.EmpID);
            db.Add(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> checkLogin(string id, string password)
        {
            var emp = await db.tblEmps.SingleOrDefaultAsync(e => e.EmpID == id && e.Password == password);
            if (emp != null)
            {
                return true;
            }
            return false;
        }

        public async Task<tblEmp> DeleteEmp(string id)
        {
            var emp = await db.tblEmps.SingleOrDefaultAsync(e => e.EmpID == id);
            if (emp != null)
            {
                db.tblEmps.Remove(emp);
                await db.SaveChangesAsync();
                return emp;
            }
            return null;
        }

        public async Task<IEnumerable<tblEmp>> FindAll(float minSalary, float maxSalary)
        {
            var employees = await db.tblEmps
                .Where(e => e.Salary >= minSalary && e.Salary <= maxSalary)
                .ToListAsync();

            return employees;
        }

        public async Task<IEnumerable<tblEmp>> FindAllEmp()
        {
            var list = await db.tblEmps.ToListAsync();
            return list;
        }

        public async Task<tblEmp> GetOneEmp(string id)
        {
            var emp = await db.tblEmps.FindAsync(id);
            return emp;
        }

        public async Task<tblEmp> UpdateSalary(string id, float salary)
        {
            var emp = await GetOneEmp(id);
            if (emp != null)
            {
                emp.Salary = salary;
                await db.SaveChangesAsync();
                return emp;
            }
            return null;
        }
    }
}
