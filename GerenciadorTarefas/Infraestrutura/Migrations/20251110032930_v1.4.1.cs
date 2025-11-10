using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class v141 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cor",
                table: "Tarefa");

            migrationBuilder.AddColumn<string>(
                name: "cor",
                table: "TipoTarefa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cor",
                table: "TipoTarefa");

            migrationBuilder.AddColumn<string>(
                name: "cor",
                table: "Tarefa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
