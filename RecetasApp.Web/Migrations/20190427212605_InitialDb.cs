using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RecetasApp.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ImagenUrl = table.Column<string>(nullable: true),
                    UrlVideo = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Dificultad = table.Column<string>(nullable: true),
                    Tiempo = table.Column<string>(nullable: true),
                    Temporada = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Pasos = table.Column<string>(nullable: true),
                    Raciones = table.Column<int>(nullable: false),
                    NumIngredientes = table.Column<int>(nullable: false),
                    MedidaIngredientes = table.Column<string>(nullable: true),
                    Ingredientes = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Comentarios = table.Column<bool>(nullable: false),
                    PublicadaEn = table.Column<DateTime>(nullable: false),
                    Stock = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}
