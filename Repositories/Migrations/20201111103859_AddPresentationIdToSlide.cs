using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AddPresentationIdToSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Presentations_PresentationEntityPresentationId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_Slides_PresentationEntityPresentationId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "PresentationEntityPresentationId",
                table: "Slides");

            migrationBuilder.AddColumn<int>(
                name: "PresentationId",
                table: "Slides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Slides_PresentationId",
                table: "Slides",
                column: "PresentationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Presentations_PresentationId",
                table: "Slides",
                column: "PresentationId",
                principalTable: "Presentations",
                principalColumn: "PresentationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Presentations_PresentationId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_Slides_PresentationId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "PresentationId",
                table: "Slides");

            migrationBuilder.AddColumn<int>(
                name: "PresentationEntityPresentationId",
                table: "Slides",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slides_PresentationEntityPresentationId",
                table: "Slides",
                column: "PresentationEntityPresentationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Presentations_PresentationEntityPresentationId",
                table: "Slides",
                column: "PresentationEntityPresentationId",
                principalTable: "Presentations",
                principalColumn: "PresentationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
