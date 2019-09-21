using Microsoft.EntityFrameworkCore.Migrations;

namespace RecetasApp.Web.Migrations
{
    public partial class masRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaComidaRecetas_CategoriaComidas_CategoriaComidaId",
                table: "CategoriaComidaRecetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Observaciones_Recetas_RecetaId",
                table: "Observaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Recetas_Regiones_RegionId",
                table: "Recetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regiones",
                table: "Regiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Observaciones",
                table: "Observaciones");

            migrationBuilder.RenameTable(
                name: "Regiones",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "Observaciones",
                newName: "Observacions");

            migrationBuilder.RenameColumn(
                name: "Comentarios",
                table: "Recetas",
                newName: "ActiComentarios");

            migrationBuilder.RenameColumn(
                name: "CategoriaComidaId",
                table: "CategoriaComidaRecetas",
                newName: "CategoriaComidasId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaComidaRecetas_CategoriaComidaId",
                table: "CategoriaComidaRecetas",
                newName: "IX_CategoriaComidaRecetas_CategoriaComidasId");

            migrationBuilder.RenameIndex(
                name: "IX_Observaciones_RecetaId",
                table: "Observacions",
                newName: "IX_Observacions_RecetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Observacions",
                table: "Observacions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaComidaRecetas_CategoriaComidas_CategoriaComidasId",
                table: "CategoriaComidaRecetas",
                column: "CategoriaComidasId",
                principalTable: "CategoriaComidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Observacions_Recetas_RecetaId",
                table: "Observacions",
                column: "RecetaId",
                principalTable: "Recetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recetas_Regions_RegionId",
                table: "Recetas",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaComidaRecetas_CategoriaComidas_CategoriaComidasId",
                table: "CategoriaComidaRecetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Observacions_Recetas_RecetaId",
                table: "Observacions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recetas_Regions_RegionId",
                table: "Recetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Observacions",
                table: "Observacions");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Regiones");

            migrationBuilder.RenameTable(
                name: "Observacions",
                newName: "Observaciones");

            migrationBuilder.RenameColumn(
                name: "ActiComentarios",
                table: "Recetas",
                newName: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "CategoriaComidasId",
                table: "CategoriaComidaRecetas",
                newName: "CategoriaComidaId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriaComidaRecetas_CategoriaComidasId",
                table: "CategoriaComidaRecetas",
                newName: "IX_CategoriaComidaRecetas_CategoriaComidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Observacions_RecetaId",
                table: "Observaciones",
                newName: "IX_Observaciones_RecetaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regiones",
                table: "Regiones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Observaciones",
                table: "Observaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaComidaRecetas_CategoriaComidas_CategoriaComidaId",
                table: "CategoriaComidaRecetas",
                column: "CategoriaComidaId",
                principalTable: "CategoriaComidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Observaciones_Recetas_RecetaId",
                table: "Observaciones",
                column: "RecetaId",
                principalTable: "Recetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recetas_Regiones_RegionId",
                table: "Recetas",
                column: "RegionId",
                principalTable: "Regiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
