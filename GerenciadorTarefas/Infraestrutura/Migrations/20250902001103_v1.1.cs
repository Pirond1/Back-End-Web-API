using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tarefa",
                newName: "concluido");

            migrationBuilder.AddColumn<int>(
                name: "idLogin",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_idLogin",
                table: "Tarefa",
                column: "idLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Usuarios_idLogin",
                table: "Tarefa",
                column: "idLogin",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Usuarios_idLogin",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_idLogin",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "idLogin",
                table: "Tarefa");

            migrationBuilder.RenameColumn(
                name: "concluido",
                table: "Tarefa",
                newName: "status");
        }
    }
}
