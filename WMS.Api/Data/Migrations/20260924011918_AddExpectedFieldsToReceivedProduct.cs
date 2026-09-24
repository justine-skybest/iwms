using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExpectedFieldsToReceivedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpectedCBM",
                table: "ReceivedProducts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpectedExpirationDate",
                table: "ReceivedProducts",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpectedProductName",
                table: "ReceivedProducts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExpectedTotalWeight",
                table: "ReceivedProducts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 24, 9, 19, 17, 261, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "ExpectedCBM", "ExpectedExpirationDate", "ExpectedProductName", "ExpectedTotalWeight" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedCBM",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "ExpectedExpirationDate",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "ExpectedProductName",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "ExpectedTotalWeight",
                table: "ReceivedProducts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 35, 53, 408, DateTimeKind.Local).AddTicks(537));
        }
    }
}
