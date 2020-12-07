using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class SlideOptionNewId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SlideOptions");

            migrationBuilder.AddColumn<Guid>(
                name: "SlideOptionId",
                table: "SlideOptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions",
                column: "SlideOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideOptions",
                table: "SlideOptions",
                column: "Id");
        }
    }
}
