﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pretest_3.Models;

#nullable disable

namespace Pretest_3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240104095234_InitialCreate")]
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

            modelBuilder.Entity("Pretest_3.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            Username = "nhan",
                            Balance = 1000,
                            Password = "123"
                        },
                        new
                        {
                            Username = "thien",
                            Balance = 900,
                            Password = "123"
                        },
                        new
                        {
                            Username = "tran",
                            Balance = 1500,
                            Password = "123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}