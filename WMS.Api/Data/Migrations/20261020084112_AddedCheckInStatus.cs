using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCheckInStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "CheckIns",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CheckIns",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 20, 16, 41, 11, 193, DateTimeKind.Local).AddTicks(7134));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "CheckIns");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CheckIns");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 19, 11, 14, 31, 983, DateTimeKind.Local).AddTicks(4871));
        }
    }
}
