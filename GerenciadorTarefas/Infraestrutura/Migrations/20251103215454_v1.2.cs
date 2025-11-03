using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idLogin",
                table: "TipoTarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoTarefa_idLogin",
                table: "TipoTarefa",
                column: "idLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoTarefa_Usuarios_idLogin",
                table: "TipoTarefa",
                column: "idLogin",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoTarefa_Usuarios_idLogin",
                table: "TipoTarefa");

            migrationBuilder.DropIndex(
                name: "IX_TipoTarefa_idLogin",
                table: "TipoTarefa");

            migrationBuilder.DropColumn(
                name: "idLogin",
                table: "TipoTarefa");
        }
    }
}
