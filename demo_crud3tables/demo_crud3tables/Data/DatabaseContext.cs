using demo_crud3tables.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace demo_crud3tables.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Supplier> Suppliers { get; set; }
        public DbSet<Models.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(e => e.CategoryID);
                c.HasMany(e => e.Products).WithOne(e => e.Category).HasForeignKey(e => e.CategoryID);
                c.HasData(new Category[]
                {
                    new Category { CategoryID = "C001", CategoryName = "Laptop", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Category { CategoryID = "C002", CategoryName = "Smartphone", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Category {CategoryID = "C003", CategoryName = "Tablet", Visibility = true, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
                    new Category {CategoryID = "C004", CategoryName = "Printer", Visibility = true, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
                });
            });

            modelBuilder.Entity<Supplier>(s =>
            {
                s.HasKey(e => e.SupplierID);
                s.HasMany(e => e.Products).WithOne(e => e.Supplier).HasForeignKey(e => e.SupplierID);
                s.HasData(new Supplier[]
                {
                    new Supplier { SupplierID = "S001", SupplierName = "Apple", City = "California", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Supplier { SupplierID = "S002", SupplierName = "Samsung", City = "Seoul", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Supplier { SupplierID = "S003", SupplierName = "HP", City = "Texas", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now},
                    new Supplier { SupplierID = "S004", SupplierName = "Canon", City = "Tokyo", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                });
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(e => e.ProductID);
                p.HasOne(e => e.Supplier).WithMany(e => e.Products).HasForeignKey(e => e.SupplierID);
                p.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryID);
                p.HasData(new Product[]
                {
                    new Product { ProductID = "P001", ProductName = "Macbook Pro 13", SupplierID = "S001", CategoryID = "C001", Quantity = 10, Price = 2000, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P002", ProductName = "Macbook Pro 16", SupplierID = "S001", CategoryID = "C001", Quantity = 10, Price = 3000, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P003", ProductName = "iPhone 11", SupplierID = "S001", CategoryID = "C002", Quantity = 10, Price = 1000, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P004", ProductName = "iPhone 11 Pro", SupplierID = "S001", CategoryID = "C002", Quantity = 10, Price = 1200, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P005", ProductName = "Galaxy S20", SupplierID = "S002", CategoryID = "C002", Quantity = 10, Price = 900, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P006", ProductName = "Galaxy Note 10", SupplierID = "S002", CategoryID = "C002", Quantity = 10, Price = 1000, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P007", ProductName = "HP Pavilion 15", SupplierID = "S003", CategoryID = "C001", Quantity = 10, Price = 800, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P008", ProductName = "HP Envy 13", SupplierID = "S003", CategoryID = "C001", Quantity = 10, Price = 1000, ImagePath = "", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now },
                    new Product { ProductID = "P009", ProductName = "Canon Pixma G2010", SupplierID = "S004", CategoryID = "C004", Quantity = 10, Price = 200, ImagePath="", Visibility=true, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now}
                });
            });
        }
    }
}
