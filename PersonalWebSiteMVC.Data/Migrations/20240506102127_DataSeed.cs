using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalWebSiteMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Talents",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 6, 13, 21, 27, 436, DateTimeKind.Local).AddTicks(1502), null, null, "images/ofis-araclari", "jpg", false },
                    { 2, new DateTime(2024, 5, 6, 13, 21, 27, 436, DateTimeKind.Local).AddTicks(1516), null, null, "images/vs-code", "jpg", false },
                    { 3, new DateTime(2024, 5, 6, 13, 21, 27, 436, DateTimeKind.Local).AddTicks(1517), null, null, "images/linked-in", "png", false }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "Url" },
                values: new object[] { 1, new DateTime(2024, 5, 6, 13, 21, 27, 436, DateTimeKind.Local).AddTicks(2935), null, null, 3, false, "LinkedIn", "https://linkedin.com/user" });

            migrationBuilder.InsertData(
                table: "Talents",
                columns: new[] { "Id", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Name", "Progress" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 6, 13, 21, 27, 436, DateTimeKind.Local).AddTicks(4570), null, null, 1, false, "Ofis Araçları", 100 },
                    { 2, new DateTime(2024, 5, 6, 13, 21, 27, 436, DateTimeKind.Local).AddTicks(4573), null, null, 2, false, "VS Code", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Talents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
