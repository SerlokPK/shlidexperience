using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class SeedSlideTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SlideTypes",
                columns: new[] { "SlideTypeId", "Type" },
                values: new object[] { (short)1, 0 });

            migrationBuilder.InsertData(
                table: "SlideTypes",
                columns: new[] { "SlideTypeId", "Type" },
                values: new object[] { (short)2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SlideTypes",
                keyColumn: "SlideTypeId",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "SlideTypes",
                keyColumn: "SlideTypeId",
                keyValue: (short)2);
        }
    }
}
