using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalWebSiteMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class DALExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 17, 49, 10, 185, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 17, 49, 10, 185, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 17, 49, 10, 185, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 17, 49, 10, 185, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 17, 49, 10, 186, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 17, 49, 10, 186, DateTimeKind.Local).AddTicks(658));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 16, 2, 7, 402, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 16, 2, 7, 402, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 16, 2, 7, 402, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 16, 2, 7, 402, DateTimeKind.Local).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 16, 2, 7, 402, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 16, 2, 7, 402, DateTimeKind.Local).AddTicks(5905));
        }
    }
}
