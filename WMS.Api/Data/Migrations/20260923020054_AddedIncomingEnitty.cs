using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncomingEnitty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ReceivedProducts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpirationDate",
                table: "ReceivedProducts",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "Incomings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Shipper = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Consignee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomings_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomingProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncomingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CBM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalWeight = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomingProduct_Incomings_IncomingId",
                        column: x => x.IncomingId,
                        principalTable: "Incomings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomingProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_IncomingProduct_IncomingId",
                table: "IncomingProduct",
                column: "IncomingId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingProduct_ProductId",
                table: "IncomingProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomings_WarehouseId",
                table: "Incomings",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomingProduct");

            migrationBuilder.DropTable(
                name: "Incomings");

            migrationBuilder.UpdateData(
                table: "ReceivedProducts",
                keyColumn: "Remarks",
                keyValue: null,
                column: "Remarks",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ReceivedProducts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpirationDate",
                table: "ReceivedProducts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 9, 16, 16, 7, 58, 212, DateTimeKind.Local).AddTicks(580));
        }
    }
}
