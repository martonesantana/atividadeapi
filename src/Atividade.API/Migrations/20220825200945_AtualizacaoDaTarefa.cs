using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atividade.API.Migrations
{
    public partial class AtualizacaoDaTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Tarefas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Tarefas");
        }
    }
}
