using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommunityEventPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedeventdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "AccessLink", "Capacity", "Cost", "Description", "EndDate", "EndTime", "EventCategoryId", "EventStatus", "EventType", "ImageUrl", "IsFree", "IsPhysical", "Location", "StartDate", "StartTime", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "", 500, 299.99m, "Annual tech conference covering the latest in technology.", new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 1, 1, 0, "", false, true, "New York Convention Center", new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 0, 0, 0), "Tech Conference 2024", null },
                    { 2, "https://meet.google.com/oaf-ernz-mxi?hs=122&authuser=0", 1000, 0m, "Interactive online workshop on artificial intelligence.", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 2, 1, 0, "", true, false, "Online", new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "Online Workshop on AI", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);
        }
    }
}
