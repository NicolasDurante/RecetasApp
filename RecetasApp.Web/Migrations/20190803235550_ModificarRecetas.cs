using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecetasApp.Web.Migrations
{
    public partial class ModificarRecetas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Ingredientes",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "MedidaIngredientes",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Pasos",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "PublicadaEn",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Recetas");

            migrationBuilder.RenameColumn(
                name: "NumIngredientes",
                table: "Recetas",
                newName: "NumLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumLikes",
                table: "Recetas",
                newName: "NumIngredientes");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Recetas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredientes",
                table: "Recetas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedidaIngredientes",
                table: "Recetas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Recetas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pasos",
                table: "Recetas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicadaEn",
                table: "Recetas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Recetas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Stock",
                table: "Recetas",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
