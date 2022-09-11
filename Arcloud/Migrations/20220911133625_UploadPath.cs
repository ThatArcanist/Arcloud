using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arcloud.Migrations
{
    public partial class UploadPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadContent",
                table: "Uploads");

            migrationBuilder.AddColumn<string>(
                name: "UploadPath",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadPath",
                table: "Uploads");

            migrationBuilder.AddColumn<byte[]>(
                name: "UploadContent",
                table: "Uploads",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
