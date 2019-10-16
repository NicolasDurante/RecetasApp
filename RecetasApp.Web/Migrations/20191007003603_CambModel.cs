using Microsoft.EntityFrameworkCore.Migrations;

namespace RecetasApp.Web.Migrations
{
    public partial class CambModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecetaIngredientes_Ingredientes_IngredientesId",
                table: "RecetaIngredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecetaIngredientes_Medidas_MedidasId",
                table: "RecetaIngredientes");

            migrationBuilder.DropIndex(
                name: "IX_RecetaIngredientes_IngredientesId",
                table: "RecetaIngredientes");

            migrationBuilder.DropIndex(
                name: "IX_RecetaIngredientes_MedidasId",
                table: "RecetaIngredientes");

            migrationBuilder.DropColumn(
                name: "IngredientesId",
                table: "RecetaIngredientes");

            migrationBuilder.DropColumn(
                name: "MedidasId",
                table: "RecetaIngredientes");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Recetas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "RecetaIngredientes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "RecetaIngredientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedidaId",
                table: "RecetaIngredientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "PasosRecetas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "Observacions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "Likes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "Comentarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "CategoriaComidaRecetas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_IngredienteId",
                table: "RecetaIngredientes",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_MedidaId",
                table: "RecetaIngredientes",
                column: "MedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaIngredientes_Ingredientes_IngredienteId",
                table: "RecetaIngredientes",
                column: "IngredienteId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaIngredientes_Medidas_MedidaId",
                table: "RecetaIngredientes",
                column: "MedidaId",
                principalTable: "Medidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecetaIngredientes_Ingredientes_IngredienteId",
                table: "RecetaIngredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecetaIngredientes_Medidas_MedidaId",
                table: "RecetaIngredientes");

            migrationBuilder.DropIndex(
                name: "IX_RecetaIngredientes_IngredienteId",
                table: "RecetaIngredientes");

            migrationBuilder.DropIndex(
                name: "IX_RecetaIngredientes_MedidaId",
                table: "RecetaIngredientes");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "RecetaIngredientes");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "RecetaIngredientes");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Recetas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "RecetaIngredientes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IngredientesId",
                table: "RecetaIngredientes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedidasId",
                table: "RecetaIngredientes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "PasosRecetas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "Observacions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "Likes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "Comentarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecetaId",
                table: "CategoriaComidaRecetas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_IngredientesId",
                table: "RecetaIngredientes",
                column: "IngredientesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_MedidasId",
                table: "RecetaIngredientes",
                column: "MedidasId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaIngredientes_Ingredientes_IngredientesId",
                table: "RecetaIngredientes",
                column: "IngredientesId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecetaIngredientes_Medidas_MedidasId",
                table: "RecetaIngredientes",
                column: "MedidasId",
                principalTable: "Medidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
