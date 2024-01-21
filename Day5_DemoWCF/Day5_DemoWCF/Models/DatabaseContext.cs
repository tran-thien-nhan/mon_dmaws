using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Day5_DemoWCF.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base() { }
        public DbSet<News> News { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectDB"].ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasKey(n => n.Id);
            modelBuilder.Entity<News>().HasData(new Models.News[]
            {
                new News {Id=1, Title="Hot Hot Hot", Content="Dung xe duong Hoang Sa"},
                new News {Id=2, Title="Hot", Content="Chay Lotte Q7"}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}