using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedWarehouseIdInReportJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "ReportJobs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 7, 14, 37, 53, 284, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.CreateIndex(
                name: "IX_ReportJobs_WarehouseId",
                table: "ReportJobs",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportJobs_Warehouses_WarehouseId",
                table: "ReportJobs",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportJobs_Warehouses_WarehouseId",
                table: "ReportJobs");

            migrationBuilder.DropIndex(
                name: "IX_ReportJobs_WarehouseId",
                table: "ReportJobs");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "ReportJobs");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9573));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 6, 11, 38, 37, 83, DateTimeKind.Local).AddTicks(8977));
        }
    }
}
