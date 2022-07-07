using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CastCursos.Migrations
{
    public partial class StatusCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Cursos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cursos");
        }
    }
}
