using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class AdditionToRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "HashedPassword", "Salt" },
                values: new object[] { new DateTime(2020, 7, 11, 19, 52, 44, 235, DateTimeKind.Local).AddTicks(6692), "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "vgyY9YZfI/db3zPQ7QeYq0H/ohgMk541K8iZBb9/6ariFxBrs6f2PVRdm2IRl2msv6E=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "HashedPassword", "Salt" },
                values: new object[] { new DateTime(2020, 7, 11, 19, 41, 6, 581, DateTimeKind.Local).AddTicks(5859), "WBXjg0VZfDI6Y8zQzkP78mmgbSDbp+Sj3mmeemXtWfXkgBlpSJN+4MFnQptOA8PGeFs=XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "WBXjg0VZfDI6Y8zQzkP78mmgbSDbp+Sj3mmeemXtWfXkgBlpSJN+4MFnQptOA8PGeFs=" });
        }
    }
}
