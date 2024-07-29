using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommunityEventPlanner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EventCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EventCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EventCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EventCategories");

            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "EventCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Conference" },
                    { 2, "Workshop" },
                    { 3, "Seminar" },
                    { 4, "Meetup" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "EventCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "EventCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "EventCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "EventCategoryId",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EventCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EventCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EventCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EventCategories",
                type: "datetime2",
                nullable: true);
        }
    }
}
