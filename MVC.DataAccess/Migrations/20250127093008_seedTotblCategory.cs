using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedTotblCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblCategory",
                columns: new[] { "fldslno", "fldDisplayOrder", "fldName" },
                values: new object[,]
                {
                    { 1, 1, "Test" },
                    { 2, 2, "Test1" },
                    { 3, 3, "Test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblCategory",
                keyColumn: "fldslno",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblCategory",
                keyColumn: "fldslno",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblCategory",
                keyColumn: "fldslno",
                keyValue: 3);
        }
    }
}
