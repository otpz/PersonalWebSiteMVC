using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalWebSiteMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Images_ImageId",
                table: "Portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Portfolios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "610b6210-faee-4a2d-8766-a5357096c83d", "AQAAAAIAAYagAAAAEDwHao1zs8gfLM5r2wvxml5LfgGDptOAdHZvsOWqI6XxdJC/bWMMW/64SYq18Z9nsw==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 11, 0, 981, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 11, 0, 981, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 11, 0, 981, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 11, 0, 982, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 11, 0, 982, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 11, 0, 982, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Images_ImageId",
                table: "Portfolios",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Images_ImageId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Images_ImageId",
                table: "Portfolios",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
