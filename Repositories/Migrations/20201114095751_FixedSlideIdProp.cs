using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class FixedSlideIdProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideOptions_Slides_SlideId",
                table: "SlideOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "SlidetId",
                table: "Slides");

            migrationBuilder.AddColumn<short>(
                name: "SlideId",
                table: "Slides",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "SlideId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideOptions_Slides_SlideId",
                table: "SlideOptions",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "SlideId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideOptions_Slides_SlideId",
                table: "SlideOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "SlideId",
                table: "Slides");

            migrationBuilder.AddColumn<short>(
                name: "SlidetId",
                table: "Slides",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "SlidetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideOptions_Slides_SlideId",
                table: "SlideOptions",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "SlidetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
