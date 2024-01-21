using Microsoft.EntityFrameworkCore.Migrations;

namespace Day5_DemoWCF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 1, "Dung xe duong Hoang Sa", "Hot Hot Hot" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 2, "Chay Lotte Q7", "Hot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
