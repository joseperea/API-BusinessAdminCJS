using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BusinessAdminCJS.Migrations
{
    public partial class mt5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35ad8d70-31b1-4b16-9038-65e8aa25c892", "7e2f8ff1-9fdc-4250-a904-2ac1c1067727", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af6a88a2-6898-4094-83e5-1eda9281ec63", "89e0158e-4f23-4a2b-8077-ff382119247e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ad8d70-31b1-4b16-9038-65e8aa25c892");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af6a88a2-6898-4094-83e5-1eda9281ec63");
        }
    }
}
