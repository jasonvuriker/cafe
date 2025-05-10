using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cafe.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserInfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "super_admin" },
                    { 2, true, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsActive", "PasswordHash", "RoleId", "Username" },
                values: new object[] { 1, "super_admin@yandex.ru", true, "6B8BB5EAE345018F01DC8F5E516EA5E0A79E2F901A0AE6B780A822F413B2D22B-C13C751C14D8A31B1978EA7E4B139146", 1, "super_admin" });
        }
    }
}
