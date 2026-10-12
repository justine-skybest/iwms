using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class OutboundWorkflowEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    LoadingReference = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipperName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsigneeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VehiclePlateNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrailerPlateNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContainerNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContainerType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SealNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlannedStartAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ActualStartAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SupervisorUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LoaderUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadingPlans_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutboundStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManualPickingId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    StagingBinId = table.Column<int>(type: "int", nullable: true),
                    StageReference = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    VerifiedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RequestedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundStages_Bins_StagingBinId",
                        column: x => x.StagingBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OutboundStages_ManualPickings_ManualPickingId",
                        column: x => x.ManualPickingId,
                        principalTable: "ManualPickings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutboundStages_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoadingEvidence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoadingPlanId = table.Column<int>(type: "int", nullable: false),
                    EvidenceType = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StoredPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MimeType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UploadedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UploadedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingEvidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadingEvidence_LoadingPlans_LoadingPlanId",
                        column: x => x.LoadingPlanId,
                        principalTable: "LoadingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoadingExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoadingPlanId = table.Column<int>(type: "int", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: true),
                    ExceptionType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Severity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadingExceptions_LoadingPlans_LoadingPlanId",
                        column: x => x.LoadingPlanId,
                        principalTable: "LoadingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadingExceptions_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoadingPalletVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoadingPlanId = table.Column<int>(type: "int", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: false),
                    ScannedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ScanTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ScanResult = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingPalletVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadingPalletVerifications_LoadingPlans_LoadingPlanId",
                        column: x => x.LoadingPlanId,
                        principalTable: "LoadingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadingPalletVerifications_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutboundStageCancellations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OutboundStageId = table.Column<int>(type: "int", nullable: false),
                    CancellationReference = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ApprovedByUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundStageCancellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundStageCancellations_OutboundStages_OutboundStageId",
                        column: x => x.OutboundStageId,
                        principalTable: "OutboundStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutboundStageLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OutboundStageId = table.Column<int>(type: "int", nullable: false),
                    PickedProductId = table.Column<int>(type: "int", nullable: false),
                    ReceivedProductId = table.Column<int>(type: "int", nullable: false),
                    OriginalBinId = table.Column<int>(type: "int", nullable: true),
                    OriginalPalletId = table.Column<int>(type: "int", nullable: true),
                    StagingBinId = table.Column<int>(type: "int", nullable: true),
                    QuantityToStage = table.Column<int>(type: "int", nullable: false),
                    QuantityStaged = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OperatorUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundStageLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundStageLines_Bins_OriginalBinId",
                        column: x => x.OriginalBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OutboundStageLines_Bins_StagingBinId",
                        column: x => x.StagingBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OutboundStageLines_OutboundStages_OutboundStageId",
                        column: x => x.OutboundStageId,
                        principalTable: "OutboundStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutboundStageLines_Pallets_OriginalPalletId",
                        column: x => x.OriginalPalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OutboundStageLines_PickedProducts_PickedProductId",
                        column: x => x.PickedProductId,
                        principalTable: "PickedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutboundStageLines_ReceivedProducts_ReceivedProductId",
                        column: x => x.ReceivedProductId,
                        principalTable: "ReceivedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoadingPlanLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoadingPlanId = table.Column<int>(type: "int", nullable: false),
                    OutboundStageId = table.Column<int>(type: "int", nullable: true),
                    OutboundStageLineId = table.Column<int>(type: "int", nullable: true),
                    PickedProductId = table.Column<int>(type: "int", nullable: true),
                    OriginalPalletId = table.Column<int>(type: "int", nullable: true),
                    QuantityPlanned = table.Column<int>(type: "int", nullable: false),
                    QuantityLoaded = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingPlanLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadingPlanLines_LoadingPlans_LoadingPlanId",
                        column: x => x.LoadingPlanId,
                        principalTable: "LoadingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadingPlanLines_OutboundStageLines_OutboundStageLineId",
                        column: x => x.OutboundStageLineId,
                        principalTable: "OutboundStageLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LoadingPlanLines_OutboundStages_OutboundStageId",
                        column: x => x.OutboundStageId,
                        principalTable: "OutboundStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LoadingPlanLines_Pallets_OriginalPalletId",
                        column: x => x.OriginalPalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_LoadingPlanLines_PickedProducts_PickedProductId",
                        column: x => x.PickedProductId,
                        principalTable: "PickedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutboundStageCancellationLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OutboundStageCancellationId = table.Column<int>(type: "int", nullable: false),
                    OutboundStageLineId = table.Column<int>(type: "int", nullable: false),
                    QuantityCancelled = table.Column<int>(type: "int", nullable: false),
                    OriginalBinId = table.Column<int>(type: "int", nullable: true),
                    ReturnBinId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExceptionReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundStageCancellationLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundStageCancellationLines_Bins_OriginalBinId",
                        column: x => x.OriginalBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OutboundStageCancellationLines_Bins_ReturnBinId",
                        column: x => x.ReturnBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OutboundStageCancellationLines_OutboundStageCancellations_Ou~",
                        column: x => x.OutboundStageCancellationId,
                        principalTable: "OutboundStageCancellations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutboundStageCancellationLines_OutboundStageLines_OutboundSt~",
                        column: x => x.OutboundStageLineId,
                        principalTable: "OutboundStageLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 12, 9, 50, 36, 420, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.CreateIndex(
                name: "IX_LoadingEvidence_LoadingPlanId",
                table: "LoadingEvidence",
                column: "LoadingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingExceptions_LoadingPlanId",
                table: "LoadingExceptions",
                column: "LoadingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingExceptions_PalletId",
                table: "LoadingExceptions",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPalletVerifications_LoadingPlanId_PalletId_ScanTime",
                table: "LoadingPalletVerifications",
                columns: new[] { "LoadingPlanId", "PalletId", "ScanTime" });

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPalletVerifications_PalletId",
                table: "LoadingPalletVerifications",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlanLines_LoadingPlanId",
                table: "LoadingPlanLines",
                column: "LoadingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlanLines_OriginalPalletId",
                table: "LoadingPlanLines",
                column: "OriginalPalletId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlanLines_OutboundStageId",
                table: "LoadingPlanLines",
                column: "OutboundStageId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlanLines_OutboundStageLineId",
                table: "LoadingPlanLines",
                column: "OutboundStageLineId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlanLines_PickedProductId",
                table: "LoadingPlanLines",
                column: "PickedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlans_LoadingReference",
                table: "LoadingPlans",
                column: "LoadingReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlans_Status",
                table: "LoadingPlans",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPlans_WarehouseId",
                table: "LoadingPlans",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageCancellationLines_OriginalBinId",
                table: "OutboundStageCancellationLines",
                column: "OriginalBinId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageCancellationLines_OutboundStageCancellationId",
                table: "OutboundStageCancellationLines",
                column: "OutboundStageCancellationId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageCancellationLines_OutboundStageLineId",
                table: "OutboundStageCancellationLines",
                column: "OutboundStageLineId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageCancellationLines_ReturnBinId",
                table: "OutboundStageCancellationLines",
                column: "ReturnBinId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageCancellations_CancellationReference",
                table: "OutboundStageCancellations",
                column: "CancellationReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageCancellations_OutboundStageId",
                table: "OutboundStageCancellations",
                column: "OutboundStageId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_OriginalBinId",
                table: "OutboundStageLines",
                column: "OriginalBinId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_OriginalPalletId",
                table: "OutboundStageLines",
                column: "OriginalPalletId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_OutboundStageId_PickedProductId",
                table: "OutboundStageLines",
                columns: new[] { "OutboundStageId", "PickedProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_PickedProductId",
                table: "OutboundStageLines",
                column: "PickedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_ReceivedProductId",
                table: "OutboundStageLines",
                column: "ReceivedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_StagingBinId",
                table: "OutboundStageLines",
                column: "StagingBinId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStageLines_Status",
                table: "OutboundStageLines",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStages_ManualPickingId",
                table: "OutboundStages",
                column: "ManualPickingId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStages_StageReference",
                table: "OutboundStages",
                column: "StageReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStages_StagingBinId",
                table: "OutboundStages",
                column: "StagingBinId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStages_Status",
                table: "OutboundStages",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundStages_WarehouseId",
                table: "OutboundStages",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadingEvidence");

            migrationBuilder.DropTable(
                name: "LoadingExceptions");

            migrationBuilder.DropTable(
                name: "LoadingPalletVerifications");

            migrationBuilder.DropTable(
                name: "LoadingPlanLines");

            migrationBuilder.DropTable(
                name: "OutboundStageCancellationLines");

            migrationBuilder.DropTable(
                name: "LoadingPlans");

            migrationBuilder.DropTable(
                name: "OutboundStageCancellations");

            migrationBuilder.DropTable(
                name: "OutboundStageLines");

            migrationBuilder.DropTable(
                name: "OutboundStages");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9975));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 201,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 202,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 203,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 204,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 205,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 206,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 207,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 208,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 209,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 210,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 211,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 212,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 213,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 214,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 215,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 216,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 217,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 218,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 219,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 220,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 221,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 222,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 223,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 224,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 225,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 226,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 227,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 228,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 229,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 230,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(55));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 231,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 232,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 233,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 234,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 235,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 236,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 237,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 238,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 240,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 241,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 242,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 243,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 244,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 245,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 246,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 247,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 248,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 249,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 250,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 251,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 252,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 253,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 254,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 255,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 256,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 257,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 258,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 259,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 260,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 261,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 262,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 263,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 925, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Racks",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2026, 10, 9, 13, 54, 40, 924, DateTimeKind.Local).AddTicks(8757));
        }
    }
}
