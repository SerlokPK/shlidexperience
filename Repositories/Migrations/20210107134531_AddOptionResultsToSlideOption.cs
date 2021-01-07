using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AddOptionResultsToSlideOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_Devices_DeviceId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_DeviceId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults");

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_DeviceId",
                table: "OptionResults",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_Devices_DeviceId",
                table: "OptionResults",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_Devices_DeviceId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_DeviceId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults");

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_DeviceId",
                table: "OptionResults",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_Devices_DeviceId",
                table: "OptionResults",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
