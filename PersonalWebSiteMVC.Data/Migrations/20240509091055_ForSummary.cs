using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalWebSiteMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talents_Images_ImageId",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Summaries",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Talents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65c78b7c-e991-4013-a67e-22a4c14e5305", "AQAAAAIAAYagAAAAEE6plfn+R3lMBt+DxMX+R8g2mzsX7JeCm5zIlyExw8PUfTJHMCCDudEP64aOeICQoQ==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 12, 10, 54, 612, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 12, 10, 54, 612, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 12, 10, 54, 612, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 12, 10, 54, 613, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 12, 10, 54, 613, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 12, 10, 54, 613, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.AddForeignKey(
                name: "FK_Talents_Images_ImageId",
                table: "Talents",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talents_Images_ImageId",
                table: "Talents");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Summaries",
                newName: "Number");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Talents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Job", "PasswordHash" },
                values: new object[] { "a34dd473-2229-4d0a-9a6e-29361bafe4de", "Software Engineer", "AQAAAAIAAYagAAAAEDqEOSfUrHeY4w84EytFfMf6yJCBajB8gqKQpu0eBi7nvc0UqIQDwLWhn/0mBQhbZA==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 17, 51, 14, 963, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 17, 51, 14, 963, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 17, 51, 14, 963, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 17, 51, 14, 964, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 17, 51, 14, 964, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 17, 51, 14, 964, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.AddForeignKey(
                name: "FK_Talents_Images_ImageId",
                table: "Talents",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
