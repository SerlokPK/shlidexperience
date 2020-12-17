using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AnsweredColumnInSlideEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_SlideOptions_SlideOptionId",
                table: "OptionResults");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_Users_UserId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults");

            migrationBuilder.AddColumn<bool>(
                name: "Answered",
                table: "Slides",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_SlideOptions_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId",
                principalTable: "SlideOptions",
                principalColumn: "SlideOptionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_Users_UserId",
                table: "OptionResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_SlideOptions_SlideOptionId",
                table: "OptionResults");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionResults_Users_UserId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults");

            migrationBuilder.DropIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults");

            migrationBuilder.DropColumn(
                name: "Answered",
                table: "Slides");

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_SlideOptions_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId",
                principalTable: "SlideOptions",
                principalColumn: "SlideOptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionResults_Users_UserId",
                table: "OptionResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
