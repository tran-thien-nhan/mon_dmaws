using Day2_Demo3Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2_Demo3Table.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
                u.HasData(new User[]
                {
                    new User { Id = 1, Name="Nhi", Email="nhi", Password="123"},
                    new User { Id = 2, Name="Nhan", Email="nhan", Password="123"},
                    new User { Id = 3, Name="Nhan 2", Email="pipclupnomad@gmail.com", Password="123"},
                });
            });
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasData(new Product[]
                {
                    new Product {Id = 1,Name="sua chua", Description="do lanh", Price=9},
                    new Product {Id = 2,Name="trung ga", Description="do song", Price=5},
                    new Product {Id = 3,Name="mi goi", Description="do khi", Price=11}
                });
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(o=> o.Id);
                o.HasOne(o => o.User).WithMany(u=> u.Orders).HasForeignKey(o=>o.UserId);
                o.HasData(new Order[]
                {
                    new Order {Id=1, UserId=1, Address="Quan 6", OrderDate= DateTime.Now, Phone="111"},
                    new Order {Id=2, UserId=2, Address="Quan 7", OrderDate= DateTime.Now, Phone="112"}
                });
            });

            modelBuilder.Entity<OrderDetail>(od =>
            {
                od.HasKey(od => new {od.OrderId,od.ProductId});
                od.HasOne(od => od.Order).WithMany(o => o.Details).HasForeignKey(o => o.OrderId);
                od.HasOne(od => od.Product).WithMany(p => p.OrderDetails).HasForeignKey(od => od.ProductId);
                od.HasData(new OrderDetail[]
                {
                    new OrderDetail {OrderId=1, ProductId=1, Quantity=4},
                    new OrderDetail {OrderId=1, ProductId=2, Quantity=3},
                    new OrderDetail {OrderId=2, ProductId=2, Quantity=1},
                    new OrderDetail {OrderId=2, ProductId=3, Quantity=1}
                });
            });

            modelBuilder.Entity<Cart>(c =>
            {
                c.HasOne(c => c.Product).WithMany(p => p.Carts).HasForeignKey(c => c.ProductId);
            });
        }
    }
}
