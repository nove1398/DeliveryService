using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class RiderChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Riiders_RiderDetails_RiderDetailsId",
                table: "Riiders");

            migrationBuilder.DropIndex(
                name: "IX_Riiders_RiderDetailsId",
                table: "Riiders");

            migrationBuilder.AlterColumn<string>(
                name: "Parish",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppRoleId", "AppUserId" },
                values: new object[] { 1, 1L });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2020, 7, 16, 20, 9, 33, 27, DateTimeKind.Local).AddTicks(1942), "tfgASWG3bGLbZctuVJf0j57WqHXQUl6DDh733l/eVY6pfNRte0hBWCDLCHkBpl88aMM=" });

            migrationBuilder.CreateIndex(
                name: "IX_Riiders_RiderDetailsId",
                table: "Riiders",
                column: "RiderDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Riiders_RiderDetails_RiderDetailsId",
                table: "Riiders",
                column: "RiderDetailsId",
                principalTable: "RiderDetails",
                principalColumn: "RiderDetailsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Riiders_RiderDetails_RiderDetailsId",
                table: "Riiders");

            migrationBuilder.DropIndex(
                name: "IX_Riiders_RiderDetailsId",
                table: "Riiders");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppRoleId", "AppUserId" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.AlterColumn<string>(
                name: "Parish",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2020, 7, 11, 19, 52, 44, 235, DateTimeKind.Local).AddTicks(6692), "vgyY9YZfI/db3zPQ7QeYq0H/ohgMk541K8iZBb9/6ariFxBrs6f2PVRdm2IRl2msv6E=" });

            migrationBuilder.CreateIndex(
                name: "IX_Riiders_RiderDetailsId",
                table: "Riiders",
                column: "RiderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Riiders_RiderDetails_RiderDetailsId",
                table: "Riiders",
                column: "RiderDetailsId",
                principalTable: "RiderDetails",
                principalColumn: "RiderDetailsId");
        }
    }
}
