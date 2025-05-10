using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserInfo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "6B8BB5EAE345018F01DC8F5E516EA5E0A79E2F901A0AE6B780A822F413B2D22B-C13C751C14D8A31B1978EA7E4B139146");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "C97E54106AFEFCBE18470AF99E80D55A13D72EED59F1B1AC805B1F8A3F51062A-B6EBDC4C24102084C25BE44A0DE06865");
        }
    }
}
