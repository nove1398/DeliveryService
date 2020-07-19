using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class StoreEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2020, 7, 18, 19, 31, 24, 197, DateTimeKind.Local).AddTicks(2234), "5GGCTQUv34kXKZCl/WjxKMRLXf7LXDGTKIVnlaZvB7ZL+Ly8CqOIlF5DHnBSL+4/gdg=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Stores");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2020, 7, 16, 20, 9, 33, 27, DateTimeKind.Local).AddTicks(1942), "tfgASWG3bGLbZctuVJf0j57WqHXQUl6DDh733l/eVY6pfNRte0hBWCDLCHkBpl88aMM=" });
        }
    }
}
