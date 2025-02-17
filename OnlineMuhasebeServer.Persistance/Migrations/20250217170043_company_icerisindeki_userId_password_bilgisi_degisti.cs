using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebeServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class company_icerisindeki_userId_password_bilgisi_degisti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Companies",
                newName: "ServerUserId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Companies",
                newName: "ServerPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerUserId",
                table: "Companies",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ServerPassword",
                table: "Companies",
                newName: "Password");
        }
    }
}
