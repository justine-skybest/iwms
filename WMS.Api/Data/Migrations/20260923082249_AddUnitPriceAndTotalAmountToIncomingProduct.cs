using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitPriceAndTotalAmountToIncomingProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "IncomingProduct",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "IncomingProduct",
                type: "decimal(65,30)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "IncomingProduct");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "IncomingProduct");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(6557));
        }
    }
}
