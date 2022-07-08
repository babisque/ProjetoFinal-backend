using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastCursos.Migrations
{
    public partial class RemovendodeleçãoemcascatadarelaçãoCursoeCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categorias_CategoriaId",
                table: "Cursos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
