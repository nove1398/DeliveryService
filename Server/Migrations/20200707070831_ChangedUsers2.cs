using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class ChangedUsers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "HashedPassword", "Salt" },
                values: new object[] { new DateTime(2020, 7, 7, 2, 8, 31, 284, DateTimeKind.Local).AddTicks(7648), "uSt3kNClMBz6tSUZ7bdvHYjigepCaSWxS9OqeUEns55tlTfjoGwL5hIXANvwcdlWyvw=XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "uSt3kNClMBz6tSUZ7bdvHYjigepCaSWxS9OqeUEns55tlTfjoGwL5hIXANvwcdlWyvw=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "HashedPassword", "Salt" },
                values: new object[] { new DateTime(2020, 7, 7, 1, 59, 55, 720, DateTimeKind.Local).AddTicks(2252), "", "" });
        }
    }
}
