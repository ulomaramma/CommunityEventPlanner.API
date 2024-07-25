using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityEventPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyeventbooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_EventBookings_EventBookingId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "EventBookingId",
                table: "Tickets",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EventBookingId",
                table: "Tickets",
                newName: "IX_Tickets_EventId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBookings_Tickets_TicketId",
                table: "EventBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_EventBookings_TicketId",
                table: "EventBookings");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "EventBookings");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Tickets",
                newName: "EventBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                newName: "IX_Tickets_EventBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_EventBookings_EventBookingId",
                table: "Tickets",
                column: "EventBookingId",
                principalTable: "EventBookings",
                principalColumn: "EventBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
