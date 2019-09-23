using Microsoft.EntityFrameworkCore.Migrations;

namespace RecetasApp.Web.Migrations
{
    public partial class morechan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlVideo",
                table: "Recetas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlVideo",
                table: "Recetas",
                nullable: true);
        }
    }
}
