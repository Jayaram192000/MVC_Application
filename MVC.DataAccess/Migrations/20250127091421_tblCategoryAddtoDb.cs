using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tblCategoryAddtoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    fldslno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fldDisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.fldslno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCategory");
        }
    }
}
