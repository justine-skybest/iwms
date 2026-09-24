using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitPriceAndTotalAmountToIncomingProductBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "ReceivedProducts",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ReceivedProducts",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 29, 59, 788, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "TotalAmount", "UnitPrice" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ReceivedProducts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 22, 48, 486, DateTimeKind.Local).AddTicks(4195));
        }
    }
}
