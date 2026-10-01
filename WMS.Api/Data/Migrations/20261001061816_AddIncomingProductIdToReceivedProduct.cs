using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIncomingProductIdToReceivedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncomingProductId",
                table: "ReceivedProducts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 14, 18, 15, 507, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 10,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 11,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 12,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 13,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 14,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 15,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 16,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 17,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 18,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 19,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 20,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 21,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 22,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 23,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 24,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 25,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 26,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 27,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 28,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 29,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 30,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 37,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 38,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 39,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 40,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 41,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 42,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 43,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 44,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 45,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 46,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 47,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 48,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 49,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 50,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 51,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 52,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 53,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 54,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 55,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 56,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 57,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 58,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 59,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 60,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 61,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 62,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 63,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 64,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 65,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 66,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 67,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 68,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 69,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 70,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 71,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 72,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 73,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 74,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 75,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 76,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 77,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 78,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 79,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 80,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 81,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 82,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 83,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 84,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 85,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 86,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 87,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 88,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 89,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 90,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 91,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 92,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 93,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 94,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 95,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 96,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 97,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 98,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 99,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 100,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 101,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 102,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 103,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 104,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 105,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 106,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 107,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 108,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 109,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 110,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 111,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 112,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 113,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 114,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 115,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 116,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 117,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 118,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 119,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 120,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 121,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 122,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 123,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 124,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 125,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 126,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 127,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 128,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 129,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 130,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 131,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 132,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 133,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 134,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 135,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 136,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 137,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 138,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 139,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 140,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 141,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 142,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 143,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 144,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 145,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 146,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 147,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 148,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 149,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 150,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 151,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 152,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 153,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 154,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 155,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 156,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 157,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 158,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 159,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 160,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 161,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 162,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 163,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 164,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 165,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 166,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 167,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 168,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 169,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 170,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 171,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 172,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 173,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 174,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 175,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 176,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 177,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 178,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 179,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 180,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 181,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 182,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 183,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 184,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 185,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 186,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 187,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 188,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 189,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 190,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 191,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 192,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 193,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 194,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 195,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 196,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 197,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 198,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 199,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 201,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 202,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 203,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 204,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 205,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 206,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 207,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 208,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 209,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 210,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 211,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 212,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 232,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 233,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 234,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 235,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 236,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 237,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 238,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 239,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 240,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 241,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 242,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 243,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 244,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 245,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 246,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 247,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 248,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 249,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 250,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 251,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 252,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 253,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 254,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 255,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 256,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 257,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 258,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 259,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 260,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 261,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 262,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 263,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 264,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 265,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 266,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 267,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 268,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 269,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 270,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 271,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 272,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 273,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 274,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 275,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 276,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 277,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 278,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 279,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 280,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 281,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 282,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 283,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 284,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 285,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 286,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 287,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 288,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 289,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 290,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 291,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 292,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 293,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 294,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 295,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 296,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 297,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 298,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 299,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 300,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 301,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 302,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 303,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 304,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 305,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 306,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 307,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 308,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 309,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 310,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 311,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 312,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 313,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 314,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 315,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 316,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 317,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 318,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 319,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 320,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 321,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 322,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 323,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 324,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 325,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 326,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 327,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 328,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 329,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 330,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 331,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 332,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 333,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 334,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 335,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 336,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 337,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 338,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 339,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 340,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 341,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 342,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 343,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 344,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 345,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 346,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 347,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 348,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 349,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 350,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 351,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 352,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 353,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 354,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 355,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 356,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 357,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 358,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 359,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 360,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 361,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 362,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 363,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 364,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 365,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 366,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 367,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 368,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 369,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 370,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 371,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 372,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 373,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 374,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 375,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 376,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 377,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 378,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 379,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 380,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 381,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 382,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 383,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 384,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 385,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 386,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 387,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 388,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 389,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 390,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 391,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 392,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 393,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 394,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 395,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 396,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 397,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 398,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 399,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 400,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 401,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 402,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 403,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 404,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 405,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 406,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 407,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 408,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 409,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 410,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 411,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 412,
                column: "IncomingProductId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_IncomingProductId",
                table: "ReceivedProducts",
                column: "IncomingProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedProducts_IncomingProduct_IncomingProductId",
                table: "ReceivedProducts",
                column: "IncomingProductId",
                principalTable: "IncomingProduct",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedProducts_IncomingProduct_IncomingProductId",
                table: "ReceivedProducts");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedProducts_IncomingProductId",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "IncomingProductId",
                table: "ReceivedProducts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 1, 11, 3, 7, 234, DateTimeKind.Local).AddTicks(5999));
        }
    }
}
