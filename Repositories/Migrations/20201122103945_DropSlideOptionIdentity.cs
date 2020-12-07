using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class DropSlideOptionIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions");

            migrationBuilder.DropColumn(
                name: "SlideOptionId",
                table: "SlideOptions");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SlideOptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SlideOptions");

            migrationBuilder.AddColumn<short>(
                name: "SlideOptionId",
                table: "SlideOptions",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions",
                column: "SlideOptionId");
        }
    }
}
