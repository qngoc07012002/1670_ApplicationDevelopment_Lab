using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _1670_ApplicationDevelopment_Lab.Migrations
{
    /// <inheritdoc />
    public partial class seedingBooksTable_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TEST");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 2, "Nguyen Quang Ngoc", 2, "Appppp DEVVVV", 20.0, "App Dev" },
                    { 3, "Ngoc Nguyen Quang", 3, "Basic Python", 40.0, "Python" },
                    { 4, "Quang Ngoc", 4, "Start C#", 30.0, "C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "TEST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST", x => x.ID);
                });
        }
    }
}
