using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class SlideTypeMotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides");

            migrationBuilder.AlterColumn<short>(
                name: "SlideTypeId",
                table: "Slides",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides",
                column: "SlideTypeId",
                principalTable: "SlideTypes",
                principalColumn: "SlideTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides");

            migrationBuilder.AlterColumn<short>(
                name: "SlideTypeId",
                table: "Slides",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides",
                column: "SlideTypeId",
                principalTable: "SlideTypes",
                principalColumn: "SlideTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
