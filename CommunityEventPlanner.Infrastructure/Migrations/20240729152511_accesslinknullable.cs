using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityEventPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class accesslinknullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccessLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndDate", "EndTime", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccessLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EndDate", "EndTime", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "StartTime" },
                values: new object[] { new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0) });
        }
    }
}
