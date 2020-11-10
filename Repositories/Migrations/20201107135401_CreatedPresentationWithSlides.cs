using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class CreatedPresentationWithSlides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.PresentationId);
                    table.ForeignKey(
                        name: "FK_Presentations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlideTypes",
                columns: table => new
                {
                    SlideTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideTypes", x => x.SlideTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    SlidetId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideTypeId = table.Column<short>(nullable: false),
                    PresentationEntityPresentationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.SlidetId);
                    table.ForeignKey(
                        name: "FK_Slides_Presentations_PresentationEntityPresentationId",
                        column: x => x.PresentationEntityPresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Slides_SlideTypes_SlideTypeId",
                        column: x => x.SlideTypeId,
                        principalTable: "SlideTypes",
                        principalColumn: "SlideTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlideOptions",
                columns: table => new
                {
                    SlideOptionId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideId = table.Column<short>(nullable: false),
                    Text = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideOptions", x => x.SlideOptionId);
                    table.ForeignKey(
                        name: "FK_SlideOptions_Slides_SlideId",
                        column: x => x.SlideId,
                        principalTable: "Slides",
                        principalColumn: "SlidetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_UserId",
                table: "Presentations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SlideOptions_SlideId",
                table: "SlideOptions",
                column: "SlideId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_PresentationEntityPresentationId",
                table: "Slides",
                column: "PresentationEntityPresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_SlideTypeId",
                table: "Slides",
                column: "SlideTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlideOptions");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "SlideTypes");
        }
    }
}
