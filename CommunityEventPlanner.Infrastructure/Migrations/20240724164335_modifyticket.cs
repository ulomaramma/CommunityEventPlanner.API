using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityEventPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBookings_Tickets_TicketId",
                table: "EventBookings");

            migrationBuilder.DropIndex(
                name: "IX_EventBookings_TicketId",
                table: "EventBookings");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "EventBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "EventBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventBookings_TicketId",
                table: "EventBookings",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBookings_Tickets_TicketId",
                table: "EventBookings",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId");
        }
    }
}
