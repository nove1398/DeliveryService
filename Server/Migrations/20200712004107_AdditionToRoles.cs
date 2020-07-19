using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class AdditionToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 1L,
                column: "AppUserId",
                value: 1L);

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "AppRolesId", "Description", "Name" },
                values: new object[] { 5, "Base account, no value or moral. No contribution to the community", "User" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "HashedPassword", "Salt" },
                values: new object[] { new DateTime(2020, 7, 11, 19, 41, 6, 581, DateTimeKind.Local).AddTicks(5859), "WBXjg0VZfDI6Y8zQzkP78mmgbSDbp+Sj3mmeemXtWfXkgBlpSJN+4MFnQptOA8PGeFs=XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "WBXjg0VZfDI6Y8zQzkP78mmgbSDbp+Sj3mmeemXtWfXkgBlpSJN+4MFnQptOA8PGeFs=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "AppRolesId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 1L,
                column: "AppUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "HashedPassword", "Salt" },
                values: new object[] { new DateTime(2020, 7, 7, 2, 8, 31, 284, DateTimeKind.Local).AddTicks(7648), "uSt3kNClMBz6tSUZ7bdvHYjigepCaSWxS9OqeUEns55tlTfjoGwL5hIXANvwcdlWyvw=XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "uSt3kNClMBz6tSUZ7bdvHYjigepCaSWxS9OqeUEns55tlTfjoGwL5hIXANvwcdlWyvw=" });
        }
    }
}
