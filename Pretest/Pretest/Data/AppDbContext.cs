using Microsoft.EntityFrameworkCore;
using Pretest.Models;

namespace Pretest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tblEmp> tblEmps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEmp>().HasData(
                new tblEmp { EmpID = "E001", FirstName = "nhan", LastName = "tran", Password = "123", Salary = 12.34f },
                new tblEmp { EmpID = "E002", FirstName = "tien", LastName = "nam", Password = "123", Salary = 56.78f }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
