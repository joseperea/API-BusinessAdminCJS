using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BusinessAdminCJS.Migrations
{
    public partial class mt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cédula de ciudadanía", true, "C.C" },
                    { 2, "Tarjeta de identidad", true, "T.I" },
                    { 3, "Cédula de extranjería", true, "C.E" },
                    { 4, "Tarjeta de extranjería", true, "T.E" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoDocumento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoDocumento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoDocumento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoDocumento",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
