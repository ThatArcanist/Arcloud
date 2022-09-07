using Microsoft.EntityFrameworkCore.Migrations;

namespace Arcloud.Migrations
{
    public partial class FormFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadFile",
                table: "Uploads",
                newName: "UploadContent");

            migrationBuilder.AlterColumn<string>(
                name: "UploadTitle",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UploadAuthor",
                table: "Uploads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadContent",
                table: "Uploads",
                newName: "UploadFile");

            migrationBuilder.AlterColumn<string>(
                name: "UploadTitle",
                table: "Uploads",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UploadAuthor",
                table: "Uploads",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
