using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.Server.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AppUsers_AppUserId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_AppUserId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Stores");

            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserStores",
                columns: table => new
                {
                    AppUserId = table.Column<long>(nullable: false),
                    StoreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserStores", x => new { x.AppUserId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_AppUserStores_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2020, 7, 27, 23, 22, 57, 728, DateTimeKind.Local).AddTicks(6474), "DZhZnQklYN9yIIlGezgVKeCyCxoptikBPHuEvvcKnoqPh0T4zkJTfufP66wDLdBtlUY=" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_StoreId",
                table: "AppUsers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserStores_StoreId",
                table: "AppUserStores",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Stores_StoreId",
                table: "AppUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Stores_StoreId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppUserStores");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_StoreId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AppUsers");

            migrationBuilder.AddColumn<long>(
                name: "AppUserId",
                table: "Stores",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Salt" },
                values: new object[] { new DateTime(2020, 7, 27, 23, 4, 14, 157, DateTimeKind.Local).AddTicks(3636), "FUe6qfF48eRvxG6T5rctOVS5Av1nMJXBBQ2NzmenVfm5xIZD/e3QuPklALdTkw8ww/E=" });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AppUserId",
                table: "Stores",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AppUsers_AppUserId",
                table: "Stores",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
