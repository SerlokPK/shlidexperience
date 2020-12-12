using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class QuestionMaxLength50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "Slides",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SlideTypes",
                keyColumn: "SlideTypeId",
                keyValue: (short)1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SlideTypes",
                keyColumn: "SlideTypeId",
                keyValue: (short)2,
                column: "Type",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SlideTypes",
                keyColumn: "SlideTypeId",
                keyValue: (short)1,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SlideTypes",
                keyColumn: "SlideTypeId",
                keyValue: (short)2,
                column: "Type",
                value: 1);
        }
    }
}
