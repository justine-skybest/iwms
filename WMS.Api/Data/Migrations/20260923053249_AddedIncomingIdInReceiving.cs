using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncomingIdInReceiving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncomingId",
                table: "Receivings",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 1,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 2,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 3,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 4,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 5,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 6,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 7,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 8,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 9,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 10,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 11,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 12,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 13,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 14,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 18,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 19,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 20,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 21,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 22,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 23,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 24,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 25,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 26,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 27,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 28,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 29,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 30,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 31,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 32,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 33,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 34,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 35,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 36,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 37,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 38,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 39,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 40,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 41,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 42,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 43,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 44,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 45,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 46,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 47,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 48,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 49,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 50,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 51,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 52,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 53,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 54,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 55,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 56,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 57,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 58,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 59,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 60,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 62,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 63,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 64,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 65,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 66,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 67,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 68,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 69,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 70,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 71,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 72,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 73,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 74,
                column: "IncomingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Receivings",
                keyColumn: "Id",
                keyValue: 75,
                column: "IncomingId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_IncomingId",
                table: "Receivings",
                column: "IncomingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_Incomings_IncomingId",
                table: "Receivings",
                column: "IncomingId",
                principalTable: "Incomings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_Incomings_IncomingId",
                table: "Receivings");

            migrationBuilder.DropIndex(
                name: "IX_Receivings_IncomingId",
                table: "Receivings");

            migrationBuilder.DropColumn(
                name: "IncomingId",
                table: "Receivings");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 10, 0, 53, 588, DateTimeKind.Local).AddTicks(531));
        }
    }
}
