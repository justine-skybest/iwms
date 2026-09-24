using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCodeInProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7107) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7111) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7119) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7121) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7125) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7125) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7137) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7149) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7152) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7157) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7158) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7164) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7166) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7167) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7172) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7172) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7178) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7179) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7184) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7184) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7228) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7231) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7234) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7235) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7235) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7237) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7239) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7247) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7252) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7256) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7258) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7262) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7262) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7268) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7284) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7284) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7286) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7286) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7288) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7293) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7298) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7299) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7308) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7311) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7311) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7338) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7344) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7356) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7363) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7363) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7365) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7369) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7373) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7386) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7388) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Code", "DateAdded" },
                values: new object[] { null, new DateTime(2026, 9, 23, 16, 7, 0, 874, DateTimeKind.Local).AddTicks(7389) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

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
        }
    }
}
