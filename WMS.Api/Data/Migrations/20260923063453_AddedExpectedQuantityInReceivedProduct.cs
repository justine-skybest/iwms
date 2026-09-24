using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedExpectedQuantityInReceivedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpectedQuantity",
                table: "ReceivedProducts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 14, 34, 51, 923, DateTimeKind.Local).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 16,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 17,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 18,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 19,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 20,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 21,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 22,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 23,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 24,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 26,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 27,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 28,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 29,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 30,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 37,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 38,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 39,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 40,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 41,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 42,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 43,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 44,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 45,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 46,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 47,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 48,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 49,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 50,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 51,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 52,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 53,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 54,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 55,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 56,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 57,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 58,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 59,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 60,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 61,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 62,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 63,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 64,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 65,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 66,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 67,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 68,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 69,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 70,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 71,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 72,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 73,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 74,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 75,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 76,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 77,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 78,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 79,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 80,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 81,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 82,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 83,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 84,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 85,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 86,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 87,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 88,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 89,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 90,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 91,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 92,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 93,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 94,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 95,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 96,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 97,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 98,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 99,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 100,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 101,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 102,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 103,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 104,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 105,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 106,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 107,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 108,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 109,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 110,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 111,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 112,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 113,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 114,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 115,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 116,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 117,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 118,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 119,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 120,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 121,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 122,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 123,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 124,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 125,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 126,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 127,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 128,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 129,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 130,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 131,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 132,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 133,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 134,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 135,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 136,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 137,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 138,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 139,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 140,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 141,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 142,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 143,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 144,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 145,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 146,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 147,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 148,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 149,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 150,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 151,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 152,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 153,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 154,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 155,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 156,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 157,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 158,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 159,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 160,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 161,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 162,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 163,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 164,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 165,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 166,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 167,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 168,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 169,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 170,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 171,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 172,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 173,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 174,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 175,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 176,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 177,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 178,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 179,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 180,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 181,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 182,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 183,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 184,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 185,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 186,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 187,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 188,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 189,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 190,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 191,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 192,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 193,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 194,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 195,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 196,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 197,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 198,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 199,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 201,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 202,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 203,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 204,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 205,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 206,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 207,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 208,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 209,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 210,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 211,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 212,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 232,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 233,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 234,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 235,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 236,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 237,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 238,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 239,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 240,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 241,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 242,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 243,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 244,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 245,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 246,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 247,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 248,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 249,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 250,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 251,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 252,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 253,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 254,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 255,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 256,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 257,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 258,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 259,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 260,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 261,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 262,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 263,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 264,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 265,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 266,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 267,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 268,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 269,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 270,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 271,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 272,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 273,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 274,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 275,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 276,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 277,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 278,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 279,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 280,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 281,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 282,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 283,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 284,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 285,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 286,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 287,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 288,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 289,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 290,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 291,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 292,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 293,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 294,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 295,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 296,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 297,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 298,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 299,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 300,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 301,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 302,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 303,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 304,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 305,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 306,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 307,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 308,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 309,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 310,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 311,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 312,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 313,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 314,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 315,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 316,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 317,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 318,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 319,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 320,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 321,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 322,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 323,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 324,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 325,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 326,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 327,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 328,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 329,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 330,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 331,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 332,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 333,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 334,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 335,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 336,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 337,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 338,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 339,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 340,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 341,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 342,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 343,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 344,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 345,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 346,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 347,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 348,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 349,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 350,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 351,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 352,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 353,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 354,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 355,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 356,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 357,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 358,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 359,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 360,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 361,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 362,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 363,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 364,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 365,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 366,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 367,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 368,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 369,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 370,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 371,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 372,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 373,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 374,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 375,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 376,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 377,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 378,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 379,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 380,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 381,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 382,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 383,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 384,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 385,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 386,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 387,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 388,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 389,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 390,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 391,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 392,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 393,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 394,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 395,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 396,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 397,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 398,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 399,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 400,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 401,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 402,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 403,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 404,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 405,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 406,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 407,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 408,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 409,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 410,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 411,
                column: "ExpectedQuantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 412,
                column: "ExpectedQuantity",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedQuantity",
                table: "ReceivedProducts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 13, 32, 48, 526, DateTimeKind.Local).AddTicks(1808));
        }
    }
}
