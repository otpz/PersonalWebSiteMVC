using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalWebSiteMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "875123e1-2ba0-4552-82ce-36b6ad51370c", "AQAAAAIAAYagAAAAEOP8aKk2kNuUor7+0HJH3wPkzMiI65Mqdta5jPx3YkwHwXcCnwEGP6mUEQeSwIyWxQ==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 16, 42, 28, 130, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 16, 42, 28, 130, DateTimeKind.Local).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 16, 42, 28, 130, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 16, 42, 28, 131, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 16, 42, 28, 132, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 16, 42, 28, 132, DateTimeKind.Local).AddTicks(366));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Experiences");

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
        }
    }
}
