using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBinLocation3D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location3DId",
                table: "Bins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RelativeX",
                table: "Bins",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RelativeY",
                table: "Bins",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RelativeZ",
                table: "Bins",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandaloneLocationId",
                table: "Bins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Bins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location3D",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PositionX = table.Column<float>(type: "float", nullable: false),
                    PositionY = table.Column<float>(type: "float", nullable: false),
                    PositionZ = table.Column<float>(type: "float", nullable: false),
                    RotationY = table.Column<float>(type: "float", nullable: false),
                    Width = table.Column<float>(type: "float", nullable: false),
                    Height = table.Column<float>(type: "float", nullable: false),
                    Depth = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location3D", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Bins",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Location3DId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 21, 49, 20, 411, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.CreateIndex(
                name: "IX_Bins_Location3DId",
                table: "Bins",
                column: "Location3DId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_WarehouseId",
                table: "Bins",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Location3D_Location3DId",
                table: "Bins",
                column: "Location3DId",
                principalTable: "Location3D",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Warehouses_WarehouseId",
                table: "Bins",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Location3D_Location3DId",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Warehouses_WarehouseId",
                table: "Bins");

            migrationBuilder.DropTable(
                name: "Location3D");

            migrationBuilder.DropIndex(
                name: "IX_Bins_Location3DId",
                table: "Bins");

            migrationBuilder.DropIndex(
                name: "IX_Bins_WarehouseId",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "Location3DId",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "RelativeX",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "RelativeY",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "RelativeZ",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "StandaloneLocationId",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Bins");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 8, 17, 37, 8, 316, DateTimeKind.Local).AddTicks(8697));
        }
    }
}
