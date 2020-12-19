using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class ChangedFkInsideResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_Users_UserId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OptionResults");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "OptionResults",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_DeviceId",
                table: "OptionResults",
                column: "DeviceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_Devices_DeviceId",
                table: "OptionResults",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_Devices_DeviceId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_DeviceId",
                table: "OptionResults");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "OptionResults");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OptionResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_Users_UserId",
                table: "OptionResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
