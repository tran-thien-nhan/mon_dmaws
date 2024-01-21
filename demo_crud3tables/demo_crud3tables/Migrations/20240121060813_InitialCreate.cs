using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo_crud3tables.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "CreatedDate", "UpdatedDate", "Visibility" },
                values: new object[,]
                {
                    { "C001", "Laptop", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7871), new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7882), true },
                    { "C002", "Smartphone", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7884), new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7885), true },
                    { "C003", "Tablet", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7887), new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7887), true },
                    { "C004", "Printer", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7889), new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(7889), true }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "City", "CreatedDate", "SupplierName", "UpdatedDate", "Visibility" },
                values: new object[,]
                {
                    { "S001", "California", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9718), "Apple", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9722), true },
                    { "S002", "Seoul", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9724), "Samsung", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9725), true },
                    { "S003", "Texas", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9727), "HP", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9727), true },
                    { "S004", "Tokyo", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9729), "Canon", new DateTime(2024, 1, 21, 13, 8, 13, 775, DateTimeKind.Local).AddTicks(9730), true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedDate", "ImagePath", "Price", "ProductName", "Quantity", "SupplierID", "UpdatedDate", "Visibility" },
                values: new object[,]
                {
                    { "P001", "C001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(497), "", 2000m, "Macbook Pro 13", 10, "S001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(501), true },
                    { "P002", "C001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(505), "", 3000m, "Macbook Pro 16", 10, "S001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(506), true },
                    { "P003", "C002", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(508), "", 1000m, "iPhone 11", 10, "S001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(509), true },
                    { "P004", "C002", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(511), "", 1200m, "iPhone 11 Pro", 10, "S001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(512), true },
                    { "P005", "C002", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(514), "", 900m, "Galaxy S20", 10, "S002", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(514), true },
                    { "P006", "C002", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(517), "", 1000m, "Galaxy Note 10", 10, "S002", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(518), true },
                    { "P007", "C001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(520), "", 800m, "HP Pavilion 15", 10, "S003", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(521), true },
                    { "P008", "C001", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(523), "", 1000m, "HP Envy 13", 10, "S003", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(523), true },
                    { "P009", "C004", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(525), "", 200m, "Canon Pixma G2010", 10, "S004", new DateTime(2024, 1, 21, 13, 8, 13, 776, DateTimeKind.Local).AddTicks(526), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
