using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class QuestionNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides");

            migrationBuilder.AlterColumn<short>(
                name: "SlideTypeId",
                table: "Slides",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "Slides",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides",
                column: "SlideTypeId",
                principalTable: "SlideTypes",
                principalColumn: "SlideTypeId",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_SlideTypes_SlideTypeId",
                table: "Slides",
                column: "SlideTypeId",
                principalTable: "SlideTypes",
                principalColumn: "SlideTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
