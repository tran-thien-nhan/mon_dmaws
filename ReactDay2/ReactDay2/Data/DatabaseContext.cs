using Microsoft.EntityFrameworkCore;
using ReactDay2.Models;

namespace ReactDay2.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student { Id = 1,Name= "Coca", Mark= 100, Email="nice@gmail.com"},
                new Student { Id = 2,Name= "Coca2", Mark= 10, Email="nice1@gmail.com"},
                new Student { Id = 3,Name= "Coca3", Mark= 12, Email="nice2@gmail.com"},
            });
        }
    }
}
