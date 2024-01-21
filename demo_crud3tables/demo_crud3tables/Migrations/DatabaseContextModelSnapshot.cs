﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo_crud3tables.Data;

#nullable disable

namespace demo_crud3tables.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("demo_crud3tables.Models.Category", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = "C001",
                            CategoryName = "Laptop",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7871),
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7882),
                            Visibility = true
                        },
                        new
                        {
                            CategoryID = "C002",
                            CategoryName = "Smartphone",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7884),
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7885),
                            Visibility = true
                        },
                        new
                        {
                            CategoryID = "C003",
                            CategoryName = "Tablet",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7887),
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7887),
                            Visibility = true
                        },
                        new
                        {
                            CategoryID = "C004",
                            CategoryName = "Printer",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7889),
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7889),
                            Visibility = true
                        });
                });

            modelBuilder.Entity("demo_crud3tables.Models.Product", b =>
                {
                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SupplierID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = "P001",
                            CategoryID = "C001",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(497),
                            ImagePath = "",
                            Price = 2000m,
                            ProductName = "Macbook Pro 13",
                            Quantity = 10,
                            SupplierID = "S001",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(501),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P002",
                            CategoryID = "C001",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(505),
                            ImagePath = "",
                            Price = 3000m,
                            ProductName = "Macbook Pro 16",
                            Quantity = 10,
                            SupplierID = "S001",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(506),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P003",
                            CategoryID = "C002",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(508),
                            ImagePath = "",
                            Price = 1000m,
                            ProductName = "iPhone 11",
                            Quantity = 10,
                            SupplierID = "S001",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(509),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P004",
                            CategoryID = "C002",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(511),
                            ImagePath = "",
                            Price = 1200m,
                            ProductName = "iPhone 11 Pro",
                            Quantity = 10,
                            SupplierID = "S001",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(512),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P005",
                            CategoryID = "C002",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(514),
                            ImagePath = "",
                            Price = 900m,
                            ProductName = "Galaxy S20",
                            Quantity = 10,
                            SupplierID = "S002",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(514),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P006",
                            CategoryID = "C002",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(517),
                            ImagePath = "",
                            Price = 1000m,
                            ProductName = "Galaxy Note 10",
                            Quantity = 10,
                            SupplierID = "S002",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(518),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P007",
                            CategoryID = "C001",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(520),
                            ImagePath = "",
                            Price = 800m,
                            ProductName = "HP Pavilion 15",
                            Quantity = 10,
                            SupplierID = "S003",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(521),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P008",
                            CategoryID = "C001",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(523),
                            ImagePath = "",
                            Price = 1000m,
                            ProductName = "HP Envy 13",
                            Quantity = 10,
                            SupplierID = "S003",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(523),
                            Visibility = true
                        },
                        new
                        {
                            ProductID = "P009",
                            CategoryID = "C004",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(525),
                            ImagePath = "",
                            Price = 200m,
                            ProductName = "Canon Pixma G2010",
                            Quantity = 10,
                            SupplierID = "S004",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(526),
                            Visibility = true
                        });
                });

            modelBuilder.Entity("demo_crud3tables.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierID = "S001",
                            City = "California",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9718),
                            SupplierName = "Apple",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9722),
                            Visibility = true
                        },
                        new
                        {
                            SupplierID = "S002",
                            City = "Seoul",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9724),
                            SupplierName = "Samsung",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9725),
                            Visibility = true
                        },
                        new
                        {
                            SupplierID = "S003",
                            City = "Texas",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9727),
                            SupplierName = "HP",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9727),
                            Visibility = true
                        },
                        new
                        {
                            SupplierID = "S004",
                            City = "Tokyo",
                            CreatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9729),
                            SupplierName = "Canon",
                            UpdatedDate = new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9730),
                            Visibility = true
                        });
                });

            modelBuilder.Entity("demo_crud3tables.Models.Product", b =>
                {
                    b.HasOne("demo_crud3tables.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.HasOne("demo_crud3tables.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("demo_crud3tables.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("demo_crud3tables.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}