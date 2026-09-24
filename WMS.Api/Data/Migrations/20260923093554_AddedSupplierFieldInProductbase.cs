using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSupplierFieldInProductbase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "ReceivedProducts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "IncomingProduct",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 37,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 38,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 39,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 40,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 41,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 42,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 43,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 44,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 45,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 46,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 47,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 48,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 49,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 50,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 51,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 52,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 53,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 54,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 55,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 56,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 57,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 58,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 59,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 60,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 61,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 62,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 63,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 64,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 65,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 66,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 67,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 68,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 69,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 70,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 71,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 72,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 73,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 74,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 75,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 76,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 77,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 78,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 79,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 80,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 81,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 82,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 83,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 84,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 85,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 86,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 87,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 88,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 89,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 90,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 91,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 92,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 93,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 94,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 95,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 96,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 97,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 98,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 99,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 100,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 101,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 102,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 103,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 104,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 105,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 106,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 107,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 108,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 109,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 110,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 111,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 112,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 113,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 114,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 115,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 116,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 117,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 118,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 119,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 120,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 121,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 122,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 123,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 124,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 125,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 126,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 127,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 128,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 129,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 130,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 131,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 132,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 133,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 134,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 135,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 136,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 137,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 138,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 139,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 140,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 141,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 142,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 143,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 144,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 145,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 146,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 147,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 148,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 149,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 150,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 151,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 152,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 153,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 154,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 155,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 156,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 157,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 158,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 159,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 160,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 161,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 162,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 163,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 164,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 165,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 166,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 167,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 168,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 169,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 170,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 171,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 172,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 173,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 174,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 175,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 176,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 177,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 178,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 179,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 180,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 181,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 182,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 183,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 184,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 185,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 186,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 187,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 188,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 189,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 190,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 191,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 192,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 193,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 194,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 195,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 196,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 197,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 198,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 199,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 201,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 202,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 203,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 204,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 205,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 206,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 207,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 208,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 209,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 210,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 211,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 212,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 232,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 233,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 234,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 235,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 236,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 237,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 238,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 239,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 240,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 241,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 242,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 243,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 244,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 245,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 246,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 247,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 248,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 249,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 250,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 251,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 252,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 253,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 254,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 255,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 256,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 257,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 258,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 259,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 260,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 261,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 262,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 263,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 264,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 265,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 266,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 267,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 268,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 269,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 270,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 271,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 272,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 273,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 274,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 275,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 276,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 277,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 278,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 279,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 280,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 281,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 282,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 283,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 284,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 285,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 286,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 287,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 288,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 289,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 290,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 291,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 292,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 293,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 294,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 295,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 296,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 297,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 298,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 299,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 300,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 301,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 302,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 303,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 304,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 305,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 306,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 307,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 308,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 309,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 310,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 311,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 312,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 313,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 314,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 315,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 316,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 317,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 318,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 319,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 320,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 321,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 322,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 323,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 324,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 325,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 326,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 327,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 328,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 329,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 330,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 331,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 332,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 333,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 334,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 335,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 336,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 337,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 338,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 339,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 340,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 341,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 342,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 343,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 344,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 345,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 346,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 347,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 348,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 349,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 350,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 351,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 352,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 353,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 354,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 355,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 356,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 357,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 358,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 359,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 360,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 361,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 362,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 363,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 364,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 365,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 366,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 367,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 368,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 369,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 370,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 371,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 372,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 373,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 374,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 375,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 376,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 377,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 378,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 379,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 380,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 381,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 382,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 383,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 384,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 385,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 386,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 387,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 388,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 389,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 390,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 391,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 392,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 393,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 394,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 395,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 396,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 397,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 398,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 399,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 400,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 401,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 402,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 403,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 404,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 405,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 406,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 407,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 408,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 409,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 410,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 411,
                column: "Supplier",
                value: null);

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Id",
                keyValue: 412,
                column: "Supplier",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "ReceivedProducts");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "IncomingProduct");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 23, 17, 23, 2, 908, DateTimeKind.Local).AddTicks(1620));
        }
    }
}
