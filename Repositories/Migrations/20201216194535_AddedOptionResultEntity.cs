using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AddedOptionResultEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionResults",
                columns: table => new
                {
                    SlideId = table.Column<short>(nullable: false),
                    SlideOptionId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionResults", x => new { x.SlideId, x.SlideOptionId });
                    table.ForeignKey(
                        name: "FK_OptionResults_Slides_SlideId",
                        column: x => x.SlideId,
                        principalTable: "Slides",
                        principalColumn: "SlideId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionResults_SlideOptions_SlideOptionId",
                        column: x => x.SlideOptionId,
                        principalTable: "SlideOptions",
                        principalColumn: "SlideOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_SlideOptionId",
                table: "OptionResults",
                column: "SlideOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionResults_UserId",
                table: "OptionResults",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionResults");
        }
    }
}
