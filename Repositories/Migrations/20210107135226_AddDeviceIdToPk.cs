using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AddDeviceIdToPk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionResults",
                table: "OptionResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionResults",
                table: "OptionResults",
                columns: new[] { "SlideId", "SlideOptionId", "DeviceId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionResults",
                table: "OptionResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionResults",
                table: "OptionResults",
                columns: new[] { "SlideId", "SlideOptionId" });
        }
    }
}
