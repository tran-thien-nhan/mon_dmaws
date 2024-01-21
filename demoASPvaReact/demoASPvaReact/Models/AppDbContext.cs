using Microsoft.EntityFrameworkCore;

namespace demoASPvaReact.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Author = "Van A", Title = "Tieng chim hot", Year = 1997}    ,
                new Book { Id = 2, Author = "Van B", Title = "kinh van hoa", Year = 2005 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
