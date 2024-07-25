using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityEventPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyuserlogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLogins",
                newName: "UserLoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLoginId",
                table: "UserLogins",
                newName: "Id");
        }
    }
}
