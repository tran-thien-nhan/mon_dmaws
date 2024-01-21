﻿// <auto-generated />
using System;
using Day2_Demo3Table.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day2_Demo3Table.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240101053721_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Day2_Demo3Table.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Quan 6",
                            OrderDate = new DateTime(2024, 1, 1, 12, 37, 20, 973, DateTimeKind.Local).AddTicks(3292),
                            Phone = "111",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Quan 7",
                            OrderDate = new DateTime(2024, 1, 1, 12, 37, 20, 973, DateTimeKind.Local).AddTicks(3305),
                            Phone = "112",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 4
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "do lanh",
                            Name = "sua chua",
                            Price = 9
                        },
                        new
                        {
                            Id = 2,
                            Description = "do song",
                            Name = "trung ga",
                            Price = 5
                        },
                        new
                        {
                            Id = 3,
                            Description = "do khi",
                            Name = "mi goi",
                            Price = 11
                        });
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "nhi",
                            Name = "Nhi",
                            Password = "123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "nhan",
                            Name = "Nhan",
                            Password = "123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "pipclupnomad@gmail.com",
                            Name = "Nhan 2",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.Cart", b =>
                {
                    b.HasOne("Day2_Demo3Table.Models.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2_Demo3Table.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.Order", b =>
                {
                    b.HasOne("Day2_Demo3Table.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.OrderDetail", b =>
                {
                    b.HasOne("Day2_Demo3Table.Models.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2_Demo3Table.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Day2_Demo3Table.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
