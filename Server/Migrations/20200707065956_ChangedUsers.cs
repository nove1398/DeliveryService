using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class ChangedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AddressLine1", "AddressLine2", "AppUserId", "Country", "Parish", "ZipCode" },
                values: new object[] { 1L, "merrivale apartments", "13 merrivale close", null, "Jamaica", "Kingston", 876 });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "BetaCode", "Biography", "Contact", "CreatedAt", "DateOfBirth", "Email", "FirstName", "HashedPassword", "IsActive", "LastName", "Nickname", "Photo", "RiderId", "Salt", "Sex", "UpdatedAt" },
                values: new object[] { 1L, "gPOOLderZ", "Hi, i'm new", "18762782795", new DateTime(2020, 7, 7, 1, 59, 55, 720, DateTimeKind.Local).AddTicks(2252), new DateTime(1989, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "nove1398@yahoo.com", "evon", "", true, "franklin", "nove", null, null, "", 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L);
        }
    }
}
