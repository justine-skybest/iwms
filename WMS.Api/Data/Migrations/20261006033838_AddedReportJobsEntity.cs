using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedReportJobsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PeriodStart = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    PeriodEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    RequestedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorMessage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportJobs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportJobs");

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
        }
    }
}
