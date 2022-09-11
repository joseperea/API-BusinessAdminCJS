using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BusinessAdminCJS.Migrations
{
    public partial class mt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDocumento_AspNetUsers_usuarioId",
                table: "TipoDocumento");

            migrationBuilder.DropIndex(
                name: "IX_TipoDocumento_usuarioId",
                table: "TipoDocumento");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "TipoDocumento");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDocumento",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdTipoDocumento",
                table: "AspNetUsers",
                column: "IdTipoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoDocumento_IdTipoDocumento",
                table: "AspNetUsers",
                column: "IdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoDocumento_IdTipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdTipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdTipoDocumento",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "usuarioId",
                table: "TipoDocumento",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumento_usuarioId",
                table: "TipoDocumento",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDocumento_AspNetUsers_usuarioId",
                table: "TipoDocumento",
                column: "usuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
