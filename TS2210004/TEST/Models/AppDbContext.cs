using Microsoft.EntityFrameworkCore;

namespace TS2210004.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = "E01", Password = "123", EmployeeName = "Bill Gates", Age = 50, Role = true },
                new Employee { EmployeeID = "E02", Password = "123", EmployeeName = "Ronaldo", Age = 25, Role = false },
                new Employee { EmployeeID = "E04", Password = "123", EmployeeName = "Merida", Age = 22, Role = false },
                new Employee { EmployeeID = "E08", Password = "123", EmployeeName = "John Vu", Age = 54, Role = false }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
