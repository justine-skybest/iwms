using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BayNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bays", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BinNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BinName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinNames", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LevelNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfPackage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Measurement = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FloorPlanImage = table.Column<byte[]>(type: "longblob", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    PalletNumber = table.Column<int>(type: "int", nullable: false),
                    PalletHashCode = table.Column<int>(type: "int", nullable: false),
                    PalletDimension = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CapacityInKG = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CapacityInCBM = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pallets_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    BayId = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    IsFloorDocking = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racks_Bays_BayId",
                        column: x => x.BayId,
                        principalTable: "Bays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racks_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racks_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Receivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Series = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    TransportCompany = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Shipper = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Consignee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReceived = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reference = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlateNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DriverName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClientRepresentative = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CheckerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivings_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CheckInType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PalletId = table.Column<int>(type: "int", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckIns_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RackId = table.Column<int>(type: "int", nullable: false),
                    BayId = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    BinNamesId = table.Column<int>(type: "int", nullable: false),
                    BinHashCode = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bins_Bays_BayId",
                        column: x => x.BayId,
                        principalTable: "Bays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bins_BinNames_BinNamesId",
                        column: x => x.BinNamesId,
                        principalTable: "BinNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bins_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bins_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RackFloorMapObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RackId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Left = table.Column<float>(type: "float", nullable: false),
                    Top = table.Column<float>(type: "float", nullable: false),
                    Width = table.Column<float>(type: "float", nullable: false),
                    Height = table.Column<float>(type: "float", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fill = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stroke = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StrokeWidth = table.Column<double>(type: "double", nullable: false),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    ScaleX = table.Column<float>(type: "float", nullable: false),
                    ScaleY = table.Column<float>(type: "float", nullable: false),
                    Angle = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackFloorMapObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackFloorMapObjects_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReceivedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceivingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CBM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalWeight = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContainerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PalletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedProducts_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceivedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivedProducts_Receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "Receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckInBin",
                columns: table => new
                {
                    BinId = table.Column<int>(type: "int", nullable: false),
                    CheckInId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInBin", x => new { x.BinId, x.CheckInId });
                    table.ForeignKey(
                        name: "FK_CheckInBin_Bins_BinId",
                        column: x => x.BinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckInBin_CheckIns_CheckInId",
                        column: x => x.CheckInId,
                        principalTable: "CheckIns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ManualPickings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    BinId = table.Column<int>(type: "int", nullable: false),
                    CheckInId = table.Column<int>(type: "int", nullable: true),
                    PickingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualPickings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualPickings_Bins_BinId",
                        column: x => x.BinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManualPickings_CheckIns_CheckInId",
                        column: x => x.CheckInId,
                        principalTable: "CheckIns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManualPickings_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckInReceivedProduct",
                columns: table => new
                {
                    CheckInId = table.Column<int>(type: "int", nullable: false),
                    ReceivedProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInReceivedProduct", x => new { x.CheckInId, x.ReceivedProductId });
                    table.ForeignKey(
                        name: "FK_CheckInReceivedProduct_CheckIns_CheckInId",
                        column: x => x.CheckInId,
                        principalTable: "CheckIns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckInReceivedProduct_ReceivedProducts_ReceivedProductId",
                        column: x => x.ReceivedProductId,
                        principalTable: "ReceivedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PickedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ManualPickingId = table.Column<int>(type: "int", nullable: false),
                    ReceivedProductId = table.Column<int>(type: "int", nullable: false),
                    QuantityPicked = table.Column<int>(type: "int", nullable: false),
                    DatePicked = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickedProducts_ManualPickings_ManualPickingId",
                        column: x => x.ManualPickingId,
                        principalTable: "ManualPickings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickedProducts_ReceivedProducts_ReceivedProductId",
                        column: x => x.ReceivedProductId,
                        principalTable: "ReceivedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Bays",
                columns: new[] { "Id", "BayNumber" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "BinNames",
                columns: new[] { "Id", "BinName" },
                values: new object[,]
                {
                    { 1, "Bin 1" },
                    { 2, "Bin 2" },
                    { 3, "Bin 3" },
                    { 4, "Bin 4" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "LevelNumber" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateAdded", "Measurement", "Name", "TypeOfPackage", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8181), "47 X 21 X 35", "Pillows Ube-Filled Crackers HA-24gX100", "Carton", 3.5m },
                    { 2, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8184), "47 X 21 X 35", "Pillows Chocolate Crackers HA-24gX100", "Carton", 3.5m },
                    { 3, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8185), "56 X 24 X 40", "Bread Pan Toasted Garlic 24gX100pcs", "Carton", 3.5m },
                    { 4, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8187), "56 X 24 X 40", "Bread Pan Cheese & Onion 24gX100pcs", "Carton", 3.5m },
                    { 5, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8188), "56 X 24 X 40", "Bread Pan Cheese & Onion 24gX100pcs", "Carton", 3.5m },
                    { 6, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8189), "56 X 24 X 40", "Bread Pan Buttered Toast 24gX100pcs", "Carton", 3.5m },
                    { 7, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8190), "56 X 24 X 40", "Miggos Sweet Corn Tortilla Chips L28g", "Carton", 3.5m },
                    { 8, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8191), "56 X 24 X 40", "O-puff Chocolate Cream Filled OWA 3.5g x 24 x 30", "Carton", 3.5m },
                    { 9, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8192), "56 X 24 X 40", "O-puff Mango Filled OWA 3.5g x 24 x 30", "Carton", 3.5m },
                    { 10, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8194), "56 X 24 X 40", "O-puff Ube Marshmallow OWA 3.5g x 24 x 30", "Carton", 3.5m },
                    { 11, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8195), "56 X 24 X 40", "Onion Rings L-16gx100", "Carton", 3.5m },
                    { 12, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8196), "56 X 24 X 40", "Oishi Prawn Cracker L-24gx100", "Carton", 3.5m },
                    { 13, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8197), "56 X 24 X 40", "Oishi Potato Fries BBQ LB-21gx100", "Carton", 3.5m },
                    { 14, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8198), "56 X 24 X 40", "Oishi Potato Fries Cheese LB-21gx100", "Carton", 3.5m },
                    { 15, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8199), "56 X 24 X 40", "Potato Fries Tomato Ketchup LB-21gx100", "Carton", 3.5m },
                    { 16, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8200), "56 X 24 X 40", "Oishi Fishda Fish Kropeck LF-22gx100", "Carton", 3.5m },
                    { 17, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8201), "56 X 24 X 40", "Fish Cracker L-24gx100", "Carton", 3.5m },
                    { 18, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8203), "56 X 24 X 40", "Oishi Sundays Mango Juice 35gx6x20", "Carton", 3.5m },
                    { 19, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8204), "56 X 24 X 40", "Oishi Sundays Orange Juice 35gx6x20", "Carton", 3.5m },
                    { 20, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8205), "56 X 24 X 40", "Oishi Sundays Orange-Mango Blends 35gx6x20", "Carton", 3.5m },
                    { 21, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8206), "56 X 24 X 40", "POTATO FRIES BBQ 50gX50", "Carton", 3.5m },
                    { 22, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8207), "56 X 24 X 40", "POTATO FRIES CHEESE 50gX50", "Carton", 3.5m },
                    { 23, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8208), "56 X 24 X 40", "POTATO FRIES KETCHUP FLAVOR 50gX50", "Carton", 3.5m },
                    { 24, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8209), "56 X 24 X 40", "OISHI PILLOWS CHOCOLATE CRACKERS 150gX20", "Carton", 3.5m },
                    { 25, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8211), "56 X 24 X 40", "MIGGOS NACHO CHEESE TORTILLA CHIPS L28gX100", "Carton", 3.5m },
                    { 26, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8212), "56 X 24 X 40", "SELECTA MOO MILK", "Carton", 3.5m },
                    { 27, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8213), "56 X 24 X 40", "SKYFLAKES", "Carton", 3.5m },
                    { 28, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8214), "56 X 24 X 40", "ISDALICIOUS FISH CRACKER", "Carton", 3.5m },
                    { 29, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8215), "56 X 24 X 40", "RICE & CORN CHEESE", "Carton", 3.5m },
                    { 30, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8219), "71 X 42 X 13", "CHEESE RING 60gX25pcs", "Sack", 2m },
                    { 31, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8220), "71 X 42 X 13", "CHEESE BALL 60gX25pcs", "Sack", 2m },
                    { 32, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8221), "71 X 42 X 13", "GOLDEN SWEET CORN 60gX25pcs", "Sack", 2m },
                    { 33, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8222), "60 X 46 X 46", "FAN MOTOR 24V 10' FAN BASE 10' FAN BLADE", "PCS", 0m },
                    { 34, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8224), "62 X 28 X 16", "CIRCUIT BOARD TS26F CONTROLLER NEW SENSORS CPR WITH O RING FUSE DETECTION BOARD", "PCS", 0m },
                    { 35, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8225), "39 X 32 X 21", "COPPER HOSE BENDABLE", "PCS", 0m },
                    { 36, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8226), "40 X 29 X 20", "RECEIVER DRIER 15NF RECEIVER DRIER 20NF", "PCS", 0m },
                    { 37, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8227), "100 X 6 X 4", "CURTAIN ROD", "PCS", 0m },
                    { 38, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8228), "38 X 38 X 23", "PLASTIC CURTAIN", "PCS", 0m },
                    { 39, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8229), "38 X 38 X 23", "ELIMINATOR FILTER DRIER", "PCS", 0m },
                    { 40, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8230), "40 X 29 X 20", "THERMOSTATIC EXPANSION VALVE 15NF THERMOSTATIC EXPANSION VALVE 20NF", "PCS", 0m },
                    { 41, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8231), "27 X 22 X 19", "TANG PWD JCE STRAWBERRY 144/19G", "Carton", 3m },
                    { 42, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8232), "27 X 22 X 19", "TANG PWD JCE MANGO 144/19G", "Carton", 3m },
                    { 43, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8233), "27 X 22 X 19", "TANG PWD JCE I.TEA LEMON 144/19G", "Carton", 3m },
                    { 44, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8234), "27 X 22 X 19", "TANG PWD JCE GRAPE 144/19G", "Carton", 3m },
                    { 45, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8235), "27 X 22 X 19", "TANG PWD JCE ORANGE 12/12/19G", "Carton", 3m },
                    { 46, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8236), "27 X 22 X 19", "TANG PWD JCE FOUR SEASON 144/19G", "Carton", 3m },
                    { 47, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8237), "27 X 22 X 19", "TANG PWD JCE FOUR SEASON 144/19G", "Carton", 3m },
                    { 48, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8238), "27 X 40 X 63", "OISHI FISH CRACKERS UA 90gX30", "Sack", 3m },
                    { 49, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8239), "29 X 49 X 66", "Miggos Sweet Corn Tortilla Chips UA 105gX30", "Sack", 3.5m },
                    { 50, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8240), "60.5 X 43 X 17.5", "DL-2000A DC12V WALL MOUNTED ELECTRIC AIR CONDITIONER", "Carton", 7m },
                    { 51, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8241), "73.5 X 55 X 32.5", "DL-2000F1 DC12V WALL MOUNTED AIR CONDITIONER", "Carton", 25m },
                    { 52, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8242), "61 X 42 X 27", "DL-2600A1 DC24V WALL MOUNTED ELECTRIC AIR CONDITIONER", "Carton", 6m },
                    { 53, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8243), "73.5 X 55 X 32.5", "DL-2600F DC24V WALL MOUNTED AIR CONDITIONER", "Carton", 24m },
                    { 54, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8244), "78 X 50 X 32", "DL-2600FT-BY DC24V WALL MOUNTED AIR CONDITIONER", "Carton", 25m },
                    { 55, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8245), "96 X 80 X 40", "DL-1800 DC12V ROOF AIR CONDITIONER", "Carton", 25m },
                    { 56, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8246), "96 X 80 X 40", "DL-1800BY DC24V ROOF AIR CONDITIONER", "Carton", 25m },
                    { 57, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8247), "96 X 80 X 40", "DL-1800-12V ROOF AIR CONDITIONER", "Carton", 25m },
                    { 58, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8249), "41 X 23 X 17", "Zesto Big 250 Grapes", "Carton", 10.5m },
                    { 59, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8250), "31 X 37 X 21", "KOPIKO BROWN COFFEE POUCH 24x1024x10x27.5G", "Carton", 0m },
                    { 60, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8251), "31 X 37 X 21", "KOPIKO BROWN COFFEE POUCH 24x1024x10x27.5G", "Carton", 7.5m },
                    { 61, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8252), "25 X 36 X 28", "KOPIKO BLANCA POUCH 24X10X30G", "Carton", 9m },
                    { 62, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8253), "24 X 43 X 28", "KOPIKO BLACK 3IN1 POUCH 24X1024X 10 X 30G", "Carton", 8m },
                    { 63, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8254), "30 X 50 X 20", "JUMBO PUSH POP 24 X 12 X 30G", "Carton", 14.5m },
                    { 64, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8255), "17 X 52 X 26", "PUSH POP LOLLIPOP 20 X 20 X 14G", "Carton", 11.5m },
                    { 65, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8256), "21 X 24 X 19", "KOJIE SL CLASSIC SOAP 135G X 24 X 20", "Carton", 7m },
                    { 66, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8257), "18 X 16 X 32", "AJI CRISPY FRY ORIG 24/238G", "Carton", 1m },
                    { 67, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8258), "18 X 16 X 32", "MODESS BODY ADAPT LONGS UT 24/4S", "Carton", 1m },
                    { 68, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8259), "38 X 18 X 37", "MODESS C.SFT LONG W 24/8'S", "Carton", 2m },
                    { 69, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8260), "35 X 18 X 27", "DM PINEAPPLE SLICES 24/432G", "Carton", 12.5m },
                    { 70, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8262), "24 X 18 X 29", "MODESS ALL NIGHT W 24/4'S", "Carton", 1.5m },
                    { 71, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8263), "48 X 31 X 24", "MODESS C.SFT REG MAXI W 12/32/1S", "Carton", 3m },
                    { 72, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8264), "27 X 22 X 19", "TANG PWD JCE LYCHEE 144/19G", "Carton", 3m },
                    { 73, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8266), "17 X 48 X 32", "FIESTA FRT COCKTL 6/3033G", "Carton", 20.5m },
                    { 74, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8266), "27 X 22 X 19", "TANG PWD JCE APPLE 144/19G", "Carton", 3m },
                    { 75, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8267), "27 X 22 X 19", "TANG PWD JCE ORANGE-MANGO 144/19G", "Carton", 3m },
                    { 76, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8268), "19 X 49 X 34", "SKYFLAKES CRCKR SWCH TSOKOLATE 30/10", "Carton", 10m },
                    { 77, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8270), "19 X 49 X 34", "SKYFLAKES CRCKR SWCH CONDENSADA 30/10", "Carton", 10m },
                    { 78, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8270), "33 X 13 X 17", "SELECTA MOO MILK CHOCO 24/245ML", "Carton", 7m },
                    { 79, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8272), "33 X 22 X 27", "SNOWTIME ICE POPS 15/8/90ML", "Carton", 11.5m },
                    { 80, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8273), "37 X 70 X 40", "PARTY PACK SUPER CRUNCH CHEESE RINGS 370G X 12S", "Carton", 5.5m },
                    { 81, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8274), "44 X 30 X 39", "MUNCHER KID'S CHOICE GREEN PEAS CHICKEN", "Carton", 13.5m },
                    { 82, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8275), "40 X 19 X 20", "Muncher G. Peas Orig 70gX10packsX10pcs", "Carton", 3m },
                    { 83, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8276), "72 X 40 X 17", "Super Q Golden Bihon 15x1KG", "Carton", 15m },
                    { 84, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8277), "21 X 10 X 15", "ZEST-O ORANGE 10X200ML", "Carton", 2m },
                    { 85, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8278), "21 X 10 X 15", "ZEST-O MANGO 10X200ML", "Carton", 2m },
                    { 86, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8279), "84 X 36 X 13", "Cheese Ring Snack Cheese 25x60g", "Carton", 2m },
                    { 87, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8280), "78 X 33 X 13", "Snacku Vegetable Snack 30/50G", "Carton", 2m },
                    { 88, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8281), "37 X 34 X 21", "Maya Cornstarch 12x1kg", "Carton", 12.5m },
                    { 89, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8282), "44 X 30 X 21", "American Gumball 24x40", "Carton", 4m },
                    { 90, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8290), "86 X 51 X 39", "Ordinary Mattress 4x36x75", "Carton", 3m },
                    { 91, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8292), "164 X 61 X 33", "Ordinary Mattress 4x54x75", "Carton", 2.5m },
                    { 92, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8293), "54 X 98 X 77", "Jumbo Rack 4 layer", "Carton", 11.5m },
                    { 93, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8294), "30 X 23 X 26", "1339 DM KTCHP TOM(ORG) 12/567G", "Carton", 11m },
                    { 94, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8295), "30 X 23 X 26", "1339 DM KTCHP TOM(ORG) 12/567G", "Carton", 11m },
                    { 95, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8296), "41 X 32 X 26", "30308 MAXX CANDY DALANDAN 40/50S", "Carton", 9m },
                    { 96, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8297), "41 X 32 X 26", "30308 MAXX CANDY CHERRY 40/50S", "Carton", 9m },
                    { 97, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8298), "48 X 31 X 17", "TODAY'S MIXED FRUIT 6/2.9L", "Carton", 20m },
                    { 98, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8300), "43 X 29 X 26", "965 COL.MONAMI STRAW CRM 40/50'S", "Carton", 7m },
                    { 99, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8301), "37 X 15 X 28", "ABSOLUTE DISTILLED WATER 3/5000ML", "Carton", 15m },
                    { 100, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8302), "44 X 13 X 33", "ABSOLUTE DISTILLED WATER 3/6000ML", "Carton", 19m },
                    { 101, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8303), "29 X 24 X 30", "ABSOLUTE DISTILLED WATER 4/4000ML", "Carton", 16m },
                    { 102, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8304), "30 X 22 X 17", "AJINAMOTO GINISA MIX 48/100G", "Carton", 9m },
                    { 103, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8304), "40 X 25 X 24", "AJINAMOTO GINISA MIX 54/16/8G", "Carton", 8m },
                    { 104, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8306), "39 X 28 X 15", "AJINAMOTO VETSIN BLUE 48/250G", "Carton", 13m },
                    { 105, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8307), "35 X 22 X 18", "AJINAMOTO VETSIN RED 8X12X100G", "Carton", 10m },
                    { 106, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8308), "77 X 31 X 13", "CHEESE RING SNACK CHEESE 30/25G", "Carton", 1m },
                    { 107, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8309), "29 X 30 X 32", "DATU PUTI VINEGAR PCON 4/1GAL", "Carton", 16m },
                    { 108, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8310), "44 X 24 X 31", "DATU PUTI VINEGAR 8/1.893", "Carton", 16m },
                    { 109, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8311), "53 X 40 X 20", "FIBISCO COOKIES CHOCO CHIP 36/200G", "Carton", 8m },
                    { 110, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8312), "53 X 40 X 20", "FIBISCO COOKIES CHOCO CHIP 36/200G", "Carton", 8m },
                    { 111, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8313), "51 X 38 X 82", "FITA CRACKER SINGLES 20/15/30G", "Carton", 10m },
                    { 112, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8314), "48 X 24 X 31", "HAPPY TIME BISCUIT ASSORTMENT 4/1.5K", "Carton", 8m },
                    { 113, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8315), "25 X 25 X 20", "KNR MIX SNGNG ORIG 12/12/22G", "Carton", 4m },
                    { 114, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8316), "34 X 14 X 20", "KNR SOUP CRAB & CORN 72/37G", "Carton", 3m },
                    { 115, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8316), "29 X 30 X 35", "MAGGI MAGIC SARAP SEASONING 60/16/8G", "Carton", 9m },
                    { 116, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8317), "29 X 30 X 35", "MAGGI MAGIC SARAP SEASONING 60/16/8G", "Carton", 9m },
                    { 117, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8319), "18 X 14 X 12", "MCCORMICK BLACK PEPPER GRND 12/35G", "Carton", 2m },
                    { 118, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8320), "55 X 41 X 19", "OISHI CHEESE CLUBS 100X23G", "Carton", 3m },
                    { 119, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8321), "57 X 24 X 38", "OISHI PILLOWS CHOCO 100/38G", "Carton", 5m },
                    { 120, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8322), "57 X 24 X 38", "OISHI PILLOWS UBE 100/38G", "Carton", 5m },
                    { 121, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8323), "30 X 18 X 26", "OREO SND.CKIE CHOCO 12/9/27G", "Carton", 4m },
                    { 122, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8325), "41 X 14 X 17", "QUEEN BAKING SODA 48/125G", "Carton", 6.5m },
                    { 123, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8326), "41 X 31 X 22", "WHITE KING FIESTA ELBOW MAC 12/1KG", "Carton", 12m },
                    { 124, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8327), "41 X 31 X 22", "WHITE KING FIESTA ELBOW MAC 12/1KG", "Carton", 12m },
                    { 125, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8328), "40 X 26 X 19", "VIVA CARAMEL CANDY 20/100'S", "Carton", 10m },
                    { 126, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8330), "37 X 25 X 21", "UFC BANANA CATSUP 24/320G", "Carton", 13m },
                    { 127, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8331), "44 X 18 X 69", "SUPER Q GOLDEN BIHON 60/227G", "Carton", 14m },
                    { 128, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8332), "69 X 38 X 18", "SUPER Q GOLDEN BIHON 30/500 G", "Carton", 16m },
                    { 129, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8333), "42 X 33 X 18", "STIK-O STRAW WATER JR 12/380G", "Carton", 5m },
                    { 130, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8334), "42 X 33 X 18", "STIK-O UBE WATER JR 12/380G", "Carton", 5m },
                    { 131, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8335), "42 X 33 X 18", "STIK-O CHOCO WATER JR 12/380G", "Carton", 5m },
                    { 132, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8336), "27 X 26 X 29", "ROYAL SPAGHETTI 18/900G", "Carton", 16m },
                    { 133, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8337), "50 X 37 X 28", "SKYFLAKES REG 30/10/25G", "Carton", 9m },
                    { 134, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8338), "31 X 20 X 17", "STIK-O CHOCO WAFER MINI 30/60G", "Carton", 2m },
                    { 135, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8339), "43 X 18 X 54", "OISHI PRAWN CRACKER 100/24G", "Carton", 3m },
                    { 136, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8340), "68 X 37 X 28", "OISHI PRAWN CRACKER 30/95G", "Carton", 3m },
                    { 137, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8341), "56 X 35 X 40", "OISHI PRAWN CRACKER 50/60G", "Carton", 2m },
                    { 138, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8343), "31 X 20 X 17", "SNACKU VEGETABLE SNACK 25/60G", "Carton", 1m },
                    { 139, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8343), "73 X 33 X 13", "SWEET CORN SNACK 25/60G", "Carton", 1m },
                    { 140, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8344), "31 X 13 X 70", "SWEET CORN SNACK 30/25", "Carton", 1m },
                    { 141, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8345), "52 X 36 X 26", "ZONROX BLEACH FRSH SCNT 24/1000ML", "Carton", 27m },
                    { 142, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8346), "52 X 36 X 26", "ZONROX BLEACH ORIGINAL 24/1000ML", "Carton", 27m },
                    { 143, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8347), "52 X 36 X 26", "ZONROX BLEACH FLORAL 24/1000ML", "Carton", 27m },
                    { 144, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8348), "52 X 36 X 26", "ZONROX BLEACH COLORSAFE 24/900ML", "Carton", 27m },
                    { 145, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8349), "32 X 26 X 32", "MENTOS CANDY TROPICAL MIX 40/50", "Carton", 7m },
                    { 146, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8351), "29 X 15 X 23", "KJSN SOAP SKIN LGHTNNG 24/2/135G", "Carton", 5m },
                    { 147, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8351), "34 X 30 X 11", "TIDE BAR NAT FRSH 36/380G", "Carton", 14m },
                    { 148, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8352), "31 X 22 X 15", "SURF BAR W/FBCN BLOSFRSH", "Carton", 13m },
                    { 149, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8353), "22 X 19 X 24", "KJSN SOAP SKIN LGHTNNG 48/2/65G", "Carton", 6m },
                    { 150, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8354), "36 X 33 X 25", "CHARMEE S.NPKN A.FLW D.NET NW 36X8", "Carton", 3m },
                    { 151, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8355), "36 X 33 X 25", "CHARMEE S.NPKN A.FLW D.NET W 36X8", "Carton", 3m },
                    { 152, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8356), "39 X 19 X 42", "NATURE SPRING 10L PURE", "Carton", 20m },
                    { 153, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8357), "39 X 19 X 42", "NATURE SPRING 10L DISTILLED", "Carton", 20m },
                    { 154, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8358), "50 X 41 X 19", "KENDI MINT CANDY 60/50", "Carton", 14m },
                    { 155, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8359), "43 X 20 X 25", "AJI CRISPY FRY ORIGINAL 13/14/62", "Carton", 12m },
                    { 156, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8360), "32 X 22 X 34", "MIRINDA ORANGE PET BOTTLE 12/1.5L", "Carton", 19m },
                    { 157, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8361), "35 X 26 X 22", "108080 SPRITE REG PET BOT 12/1.5L", "Carton", 19m },
                    { 158, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8362), "46 X 30 X 15", "AJINAMOTO GINISA MIX 120/40G", "Carton", 6m },
                    { 159, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8363), "32 X 22 X 34", "PEPSI REG PET BOTTLE 12/1.5L", "Carton", 19m },
                    { 160, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8364), "38 X 30 X 24", "MENTOS CANDY MINT BAG 40/50", "Carton", 7m },
                    { 161, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8365), "50 X 41 X 19", "VIVA CARAMEL CANDY 60/50", "Carton", 14m },
                    { 162, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8366), "32 X 22 X 34", "MOUNTAIN DEW PET BOTTLE 12/1.5L", "Carton", 19m },
                    { 163, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8367), "33 X 16 X 21", "STING ENERGY DRINK STRAWBERRY 24/320", "Carton", 9m },
                    { 164, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8368), "40 X 23 X 22", "PEPSI REG PET BOT 24/500ML", "Carton", 12m },
                    { 165, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8369), "72 X 40 X 17", "SUPER Q PALABOK 12/500G", "Carton", 6m },
                    { 166, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8370), "33 X 27 X 29", "LORINS PATIS PLASTIC 12/1000ML", "Carton", 15m },
                    { 167, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8371), "37 X 26 X 19", "LORINS PATIS PLASTIC 24/350ML", "Carton", 11m },
                    { 168, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8372), "43 X 20 X 25", "AJI CRISPY FRY GARLIC 13/14/62G", "Carton", 12m },
                    { 169, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8373), "50 X 41 X 19", "WHITE RABBIT CANDY 60/50", "Carton", 14m },
                    { 170, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8374), "39 X 31 X 21", "RICOA FLAT TOPS 12/100", "Carton", 7m },
                    { 171, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8376), "30 X 22 X 17", "SURF BAR KALAMANSI 36/360G", "Carton", 12.5m },
                    { 172, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8377), "32 X 10 X 17", "ZEST-O BIG 250 APPLE 10/250ML", "Carton", 2m },
                    { 173, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8378), "32 X 10 X 17", "ZEST-O BIG 250 GRAPE 10/250ML", "Carton", 2m },
                    { 174, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8379), "32 X 10 X 17", "ZEST-O BIG 250 ORANGE 10/250ML", "Carton", 2m },
                    { 175, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8380), "32 X 10 X 17", "ZEST-O BIG MANGO 10/250ML", "Carton", 2m },
                    { 176, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8381), "32 X 27 X 20", "IODIZED SALT 1KG", "Carton", 20m },
                    { 177, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8382), "32 X 27 X 20", "IODIZED SALT 500G", "Carton", 19m },
                    { 178, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8383), "30 X 14 X 13", "LASAP SINIGANG MIX 20G", "Carton", 4m },
                    { 179, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8384), "28 X 28 X 19", "LASAP VETSIN 100G", "Carton", 10m },
                    { 180, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8385), "28 X 28 X 19", "LASAP VETSIN 100G", "Carton", 10m },
                    { 181, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8386), "33 X 19 X 15", "LASAP SINIGANG MIX W/GABI 22G", "Carton", 3m },
                    { 182, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8387), "32 X 22 X 17", "LASAP OYSTER SAUCE 170 G", "Carton", 8m },
                    { 183, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8388), "32 X 22 X 17", "LASAP KARE KARE MIX 75G", "Carton", 2m },
                    { 184, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8389), "30 X 14 X 13", "LASAP TOCINO MIX", "Carton", 2m },
                    { 185, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8390), "30 X 14 X 13", "LASAP BBQ MIX 50G", "Carton", 1m },
                    { 186, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8391), "59 X 36 X 40", "REGENT TEMPURA SHRIMP 25/100G", "Carton", 3m },
                    { 187, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8392), "59 X 36 X 40", "REGENT LABSTER 25/100G", "Carton", 3m },
                    { 188, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8393), "59 X 36 X 40", "REGENT ISDALICIOUS 25/85G", "Carton", 3m },
                    { 189, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8394), "37 X 35 X 17", "REGENT UBE CAKE 8/10'S", "Carton", 2m },
                    { 190, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8395), "37 X 35 X 17", "REGENT SAND CAKE MELON 8/10S", "Carton", 2m },
                    { 191, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8396), "37 X 35 X 17", "REGENT MOCHA CAKE 8/10'S", "Carton", 2m },
                    { 192, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8397), "44 X 27 X 22", "REGENT JAPANESE UBE CAKE 34G", "Carton", 4m },
                    { 193, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8398), "44 X 27 X 22", "REGENT JAPANESE CHOKORETO CAKE 34G", "Carton", 4m },
                    { 194, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8399), "44 X 27 X 22", "REGENT JAPANESE CHEESECAKE 34G", "Carton", 4m },
                    { 195, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8400), "34 X 27 X 14", "REGENT MOCHI MANGO 240G", "Carton", 2m },
                    { 196, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8401), "34 X 27 X 14", "REGENT MOCHI UBE 240 G", "Carton", 2m },
                    { 197, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8402), "34 X 27 X 14", "REGENT BUKO PANDAN 240G", "Carton", 2m },
                    { 198, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8403), "34 X 27 X 14", "REGENT MOCHI ASSORTED", "Carton", 2m },
                    { 199, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8404), "34 X 27 X 14", "REGENT MOCHI BLACK SESAME 240G", "Carton", 2m },
                    { 200, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8405), "34 X 27 X 14", "REGENT MOCHI BLACK SESAME 240G", "Carton", 2m },
                    { 201, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8406), "50 X 38 X 26", "CRIS P'S SEAWEED 60G", "Carton", 3m },
                    { 202, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8407), "50 X 38 X 26", "CRIS P'S SAL VINEGAR 60G", "Carton", 3m },
                    { 203, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8408), "50 X 38 X 26", "CRIS P'S CHEESE", "Carton", 3m },
                    { 204, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8417), "40 X 21 X 18", "POTATO CRACKERS", "Carton", 3m },
                    { 205, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8418), "61 X 39 X 41", "KING CRAB", "Carton", 3m },
                    { 206, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8419), "60 X 30 X 33", "GOLDEN SWEET CORN", "Carton", 4m },
                    { 207, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8420), "60 X 30 X 33", "CHEESE RING JALAPENO", "Carton", 4m },
                    { 208, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8421), "60 X 30 X 33", "CHEESE RING CHEESE", "Carton", 4m },
                    { 209, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8422), "61 X 39 X 41", "FRENCH FRIES", "Carton", 5m },
                    { 210, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8423), "61 X 39 X 41", "SHRIMP FRITTERS", "Carton", 4m },
                    { 211, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8424), "54 X 35 X 38", "MOBY CARAMEL 90G", "Carton", 3m },
                    { 212, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8425), "64 X 46 X 18", "CHEESE IT CHEESE 60G", "Carton", 3m },
                    { 213, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8426), "63 X 46 X 18", "MOBY CHOCOLATE CHIPS 60G", "Carton", 3m },
                    { 214, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8427), "63 X 46 X 18", "MOBY CARAMEL PUFFS 60G", "Carton", 3m },
                    { 215, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8428), "63 X 46 X 18", "MOBY CHOCOLATE 25G", "Carton", 3m },
                    { 216, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8429), "63 X 46 X 18", "MOBY CARAMEL 25G", "Carton", 3m },
                    { 217, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8433), "63 X 46 X 18", "MOBY CHOCO CUM CHOC BU", "Carton", 3m },
                    { 218, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8434), "58 X 48 X 18", "LOADED CHOCO FILLED 65G", "Carton", 3m },
                    { 219, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8435), "58 X 48 X 18", "LOADED WHITE CHOCO 65G", "Carton", 3m },
                    { 220, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8436), "56 X 36 X 38", "LOADED WHITE CHOCO 32G", "Carton", 3m },
                    { 221, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8437), "56 X 36 X 38", "LOADED WHITE CHOCO 32G", "Carton", 3m },
                    { 222, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8438), "56 X 36 X 38", "LOADED CHOCO 32G", "Carton", 3m },
                    { 223, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8439), "56 X 36 X 38", "LOADED CHOCO 32G", "Carton", 3m },
                    { 224, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8440), "46 X 32 X 52", "TOMI SWEET CORN 110G", "Carton", 6m },
                    { 225, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8441), "46 X 32 X 52", "TOMI SWEET CORN 110G", "Carton", 6m },
                    { 226, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8442), "37 X 35 X 17", "REGENT STRAWBERRY CAKE 8/10S", "Carton", 2m },
                    { 227, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8443), "37 X 35 X 17", "REGENT PANDAN CAKE 8/10S", "Carton", 2m },
                    { 228, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8444), "37 X 35 X 17", "REGENT ASSORTED CAKE 8/10S", "Carton", 2m },
                    { 229, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8445), "44 X 27 X 22", "REGENT BANANA CAKE 34G", "Carton", 4m },
                    { 230, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8446), "46 X 30 X 15", "REGENT BELGIAN WAFFLE 30G", "Carton", 4m },
                    { 231, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8447), "46 X 30 X 15", "REGENT BELGIAN CHOCO", "Carton", 4m },
                    { 232, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8448), "46 X 30 X 15", "REGENT BELGIAN CHOCO", "Carton", 4m },
                    { 233, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8449), "38 X 30 X 18", "FLORENCE MACAPUNO 24/12OZ", "Carton", 12m },
                    { 234, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8450), "38 X 30 X 18", "FLORENCE JACKFRUIT 24/12OZ", "Carton", 12m },
                    { 235, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8451), "42 X 32 X 15", "FLORENCE KAONG RED 24/12OZ", "Carton", 16m },
                    { 236, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8452), "42 X 32 X 15", "FLORENCE NATA DE COCO WHITE 24/12OZ", "Carton", 16m },
                    { 237, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8453), "42 X 32 X 15", "FLORENCE NATA DE COCO GREEN 24/12OZ", "Carton", 16m },
                    { 238, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8455), "42 X 32 X 15", "FLORENCE NATA DE COCO RED 24/12OZ", "Carton", 16m },
                    { 240, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8456), "42 X 32 X 15", "FLORENCE JACKFRUIT 24X12OZ", "Carton", 16m },
                    { 241, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8457), "42 X 32 X 15", "FLORENCE PURPLE YAM 24/12OZ", "Carton", 16m },
                    { 242, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8458), "42 X 32 X 15", "FLORENCE PURPLE YAM 24/12OZ", "Carton", 16m },
                    { 243, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8459), "40 X 27 X 13", "FLORENCE NATA DE COCO WHITE 12/24OZ", "Carton", 10m },
                    { 244, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8459), "40 X 27 X 13", "FLORENCE NATA DE COCO GREEN 12/24OZ", "Carton", 10m },
                    { 245, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8460), "40 X 27 X 13", "FLORENCE NATA DE COCO RED 12/24OZ", "Carton", 10m },
                    { 246, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8461), "42 X 32 X 15", "FLORENCE SALTED SHRIMP 24/340G", "Carton", 16m },
                    { 247, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8462), "40 X 27 X 13", "FLORENCE SAU SHRIMP SWEET", "Carton", 16m },
                    { 248, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8463), "40 X 27 X 13", "FLORENCE SAU SHRIMP REGULAR", "Carton", 10m },
                    { 249, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8464), "40 X 27 X 13", "FLORENCE SAU SHRIMP SPICY", "Carton", 10m },
                    { 250, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8465), "39 X 28 X 13", "FLORENCE BAGOONG BALAYAN", "Carton", 14m },
                    { 251, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8466), "58 X 34 X 38", "ADORABLE CREAM BAR CHOCO", "Carton", 8m },
                    { 252, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8467), "58 X 34 X 38", "ADORABLE CREAM BAR MATHCA", "Carton", 8m },
                    { 253, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8468), "58 X 34 X 38", "ADORABLE CREAM BAR STRAWBERRY", "Carton", 8m },
                    { 254, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8469), "36 X 44 X 23", "MONIEGOLD TAMARIND CHEWY 150G", "Carton", 16m },
                    { 255, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8470), "36 X 44 X 23", "MONIEGOLD TAMARIND CHEWY 150G", "Carton", 16m },
                    { 256, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8471), "36 X 44 X 23", "MONIEGOLD TAMARIND CHEWY 80G", "Carton", 16m },
                    { 257, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8472), "53 X 34 X 30", "COCONUT ENERGY BAR NUTS 24/400", "Carton", 10m },
                    { 258, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8473), "54 X 36 X 16", "COCONUT BLAST ICECREAM CHOCO 24/300", "Carton", 8m },
                    { 259, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8474), "54 X 36 X 16", "COCONUT BLAST ICECREAM STRAWBERRY 24/300", "Carton", 8m },
                    { 260, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8475), "54 X 36 X 16", "COCO CREAM BAR CHOCO 24/300", "Carton", 8m },
                    { 261, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8476), "41 X 24 X 17", "BIG 250 APPLE", "Carton", 10.5m },
                    { 262, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8478), "41 X 24 X 17", "BIG 250 GRAPE", "Carton", 10.5m },
                    { 263, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(8479), "41 X 24 X 17", "BIG 250 ORANGE", "Carton", 10.5m }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Address", "DateAdded", "FloorPlanImage", "Name" },
                values: new object[,]
                {
                    { 1, "NIOG ST BACOOR CAVITE", new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), null, "SKYBEST WAREHOUSE 6" },
                    { 2, "Babanse St, Navotas City", new DateTime(2025, 5, 29, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), null, "Legalas Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Pallets",
                columns: new[] { "Id", "CapacityInCBM", "CapacityInKG", "DateAdded", "PalletDimension", "PalletHashCode", "PalletNumber", "WarehouseId" },
                values: new object[,]
                {
                    { 1, 0.0m, 0.0m, new DateTime(2025, 1, 25, 1, 53, 4, 220, DateTimeKind.Unspecified).AddTicks(6900), "", -33700796, 1, 1 },
                    { 2, 0.0m, 0.0m, new DateTime(2025, 1, 25, 2, 0, 59, 445, DateTimeKind.Unspecified).AddTicks(1160), "", 554322328, 2, 1 },
                    { 3, 0.0m, 0.0m, new DateTime(2025, 1, 25, 2, 11, 15, 640, DateTimeKind.Unspecified).AddTicks(6390), "", -1258735642, 3, 1 },
                    { 4, 0.0m, 0.0m, new DateTime(2025, 2, 13, 5, 50, 0, 627, DateTimeKind.Unspecified).AddTicks(3370), "", 1639556679, 4, 1 },
                    { 5, 0.0m, 0.0m, new DateTime(2025, 2, 13, 5, 53, 51, 126, DateTimeKind.Unspecified).AddTicks(3870), "", -389457843, 5, 1 },
                    { 7, 0.0m, 0.0m, new DateTime(2025, 2, 13, 5, 56, 40, 703, DateTimeKind.Unspecified).AddTicks(6060), "", 1698320526, 6, 1 },
                    { 8, 0.0m, 0.0m, new DateTime(2025, 2, 13, 5, 56, 41, 223, DateTimeKind.Unspecified).AddTicks(4700), "", 448084449, 7, 1 },
                    { 10, 0.0m, 0.0m, new DateTime(2025, 2, 13, 5, 58, 8, 366, DateTimeKind.Unspecified).AddTicks(7580), "", 82261761, 8, 1 },
                    { 11, 0.0m, 0.0m, new DateTime(2025, 2, 13, 5, 58, 9, 871, DateTimeKind.Unspecified).AddTicks(6570), "", -987980297, 9, 1 },
                    { 13, 0.0m, 0.0m, new DateTime(2025, 2, 13, 6, 5, 10, 996, DateTimeKind.Unspecified).AddTicks(5640), "", 940111660, 10, 1 },
                    { 14, 0.0m, 0.0m, new DateTime(2025, 2, 13, 6, 5, 48, 30, DateTimeKind.Unspecified).AddTicks(4240), "", 1045470907, 11, 1 },
                    { 15, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 37, 46, 701, DateTimeKind.Unspecified).AddTicks(1180), "", 883864395, 12, 1 },
                    { 16, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 39, 7, 408, DateTimeKind.Unspecified).AddTicks(1130), "", -2017262582, 13, 1 },
                    { 17, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 39, 29, 391, DateTimeKind.Unspecified).AddTicks(3380), "", 52399103, 14, 1 },
                    { 18, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 2, 375, DateTimeKind.Unspecified).AddTicks(2540), "", 213701906, 15, 1 },
                    { 19, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 29, 569, DateTimeKind.Unspecified).AddTicks(1800), "", 688679917, 16, 1 },
                    { 20, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 33, 428, DateTimeKind.Unspecified).AddTicks(1970), "", 1124358483, 17, 1 },
                    { 21, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 33, 828, DateTimeKind.Unspecified).AddTicks(7760), "", -200130887, 18, 1 },
                    { 22, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 34, 822, DateTimeKind.Unspecified).AddTicks(8470), "", 1861152145, 19, 1 },
                    { 23, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 36, 287, DateTimeKind.Unspecified).AddTicks(7330), "", -780089336, 20, 1 },
                    { 24, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 36, 920, DateTimeKind.Unspecified).AddTicks(5230), "", -898088727, 21, 1 },
                    { 25, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 43, 742, DateTimeKind.Unspecified).AddTicks(1780), "", -1301624443, 22, 1 },
                    { 26, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 44, 597, DateTimeKind.Unspecified).AddTicks(5980), "", 2126330677, 23, 1 },
                    { 27, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 45, 152, DateTimeKind.Unspecified).AddTicks(8810), "", -2027656597, 24, 1 },
                    { 28, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 45, 433, DateTimeKind.Unspecified).AddTicks(7570), "", 298456068, 25, 1 },
                    { 29, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 46, 487, DateTimeKind.Unspecified).AddTicks(2580), "", 1310428199, 26, 1 },
                    { 30, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 47, 289, DateTimeKind.Unspecified).AddTicks(6000), "", -1430758289, 27, 1 },
                    { 31, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 49, 138, DateTimeKind.Unspecified).AddTicks(6920), "", -1062054023, 28, 1 },
                    { 32, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 49, 216, DateTimeKind.Unspecified).AddTicks(6680), "", 830267492, 29, 1 },
                    { 33, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 50, 794, DateTimeKind.Unspecified).AddTicks(7930), "", 947622953, 30, 1 },
                    { 34, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 52, 247, DateTimeKind.Unspecified).AddTicks(9830), "", 1470711854, 31, 1 },
                    { 35, 0.0m, 0.0m, new DateTime(2025, 2, 13, 7, 40, 53, 529, DateTimeKind.Unspecified).AddTicks(2290), "", -1146058639, 32, 1 },
                    { 398, 0.0m, 0.0m, new DateTime(2025, 4, 8, 1, 39, 21, 701, DateTimeKind.Unspecified).AddTicks(3010), "", 1322963265, 33, 1 },
                    { 399, 0.0m, 0.0m, new DateTime(2025, 4, 8, 1, 39, 23, 937, DateTimeKind.Unspecified).AddTicks(1720), "", 1928472044, 34, 1 },
                    { 400, 0.0m, 0.0m, new DateTime(2025, 4, 8, 1, 39, 24, 940, DateTimeKind.Unspecified).AddTicks(8650), "", -988118190, 35, 1 },
                    { 401, 0.0m, 0.0m, new DateTime(2025, 4, 8, 1, 39, 25, 724, DateTimeKind.Unspecified).AddTicks(7870), "", -1775459348, 36, 1 },
                    { 402, 0.0m, 0.0m, new DateTime(2025, 4, 8, 1, 39, 27, 496, DateTimeKind.Unspecified).AddTicks(1200), "", -1648659206, 37, 1 },
                    { 403, 0.0m, 0.0m, new DateTime(2025, 4, 8, 1, 39, 28, 498, DateTimeKind.Unspecified).AddTicks(6510), "", 987426499, 38, 1 },
                    { 404, 0.0m, 0.0m, new DateTime(2025, 5, 9, 2, 6, 41, 344, DateTimeKind.Unspecified).AddTicks(9590), "", -818280427, 39, 1 },
                    { 405, 0.0m, 0.0m, new DateTime(2025, 5, 9, 2, 6, 42, 565, DateTimeKind.Unspecified).AddTicks(4090), "", 1728123643, 40, 1 },
                    { 406, 0.0m, 0.0m, new DateTime(2025, 5, 9, 2, 6, 43, 276, DateTimeKind.Unspecified).AddTicks(4300), "", -1544750712, 41, 1 },
                    { 407, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 41, 725, DateTimeKind.Unspecified).AddTicks(4590), "", 2067686016, 42, 1 },
                    { 408, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 42, 666, DateTimeKind.Unspecified).AddTicks(2850), "", -1158230228, 43, 1 },
                    { 409, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 43, 329, DateTimeKind.Unspecified).AddTicks(6670), "", 875334534, 44, 1 },
                    { 410, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 43, 881, DateTimeKind.Unspecified).AddTicks(8140), "", 1121125081, 45, 1 },
                    { 411, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 44, 516, DateTimeKind.Unspecified).AddTicks(3080), "", -1251831711, 46, 1 },
                    { 412, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 45, 119, DateTimeKind.Unspecified).AddTicks(8700), "", 1844250616, 47, 1 },
                    { 413, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 45, 745, DateTimeKind.Unspecified).AddTicks(4470), "", -638388577, 48, 1 },
                    { 414, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 46, 289, DateTimeKind.Unspecified).AddTicks(8570), "", 1232753550, 49, 1 },
                    { 415, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 46, 921, DateTimeKind.Unspecified).AddTicks(2700), "", 968628869, 50, 1 },
                    { 416, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 47, 531, DateTimeKind.Unspecified).AddTicks(9730), "", -541687618, 51, 1 },
                    { 417, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 48, 241, DateTimeKind.Unspecified).AddTicks(1620), "", -1006330990, 52, 1 },
                    { 418, 0.0m, 0.0m, new DateTime(2025, 5, 9, 3, 48, 48, 963, DateTimeKind.Unspecified).AddTicks(2660), "", -1093198325, 53, 1 },
                    { 419, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 1, 9, 515, DateTimeKind.Unspecified).AddTicks(1830), "", 1419325850, 54, 1 },
                    { 420, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 1, 27, 106, DateTimeKind.Unspecified).AddTicks(6090), "", -918901900, 55, 1 },
                    { 421, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 2, 47, 222, DateTimeKind.Unspecified).AddTicks(5830), "", -1592032269, 56, 1 },
                    { 422, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 2, 47, 905, DateTimeKind.Unspecified).AddTicks(4450), "", 84102366, 57, 1 },
                    { 423, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 13, 421, DateTimeKind.Unspecified).AddTicks(2070), "", -1984909184, 58, 1 },
                    { 424, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 14, 90, DateTimeKind.Unspecified).AddTicks(3680), "", -1708716433, 59, 1 },
                    { 425, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 14, 698, DateTimeKind.Unspecified).AddTicks(1390), "", -1075112334, 60, 1 },
                    { 426, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 15, 241, DateTimeKind.Unspecified).AddTicks(7980), "", 1100049074, 61, 1 },
                    { 427, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 15, 947, DateTimeKind.Unspecified).AddTicks(7510), "", 493226735, 62, 1 },
                    { 428, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 16, 735, DateTimeKind.Unspecified).AddTicks(900), "", -903709873, 63, 1 },
                    { 429, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 17, 378, DateTimeKind.Unspecified).AddTicks(3380), "", -286430102, 64, 1 },
                    { 430, 0.0m, 0.0m, new DateTime(2025, 5, 9, 4, 13, 18, 28, DateTimeKind.Unspecified).AddTicks(9710), "", 1248401289, 65, 1 },
                    { 431, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 15, 1, 314, DateTimeKind.Unspecified).AddTicks(8510), "", -366353798, 66, 1 },
                    { 432, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 15, 2, 242, DateTimeKind.Unspecified).AddTicks(3890), "", -1308736711, 67, 1 },
                    { 433, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 15, 19, 799, DateTimeKind.Unspecified).AddTicks(8640), "", -1491205212, 68, 1 },
                    { 434, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 19, 11, 998, DateTimeKind.Unspecified).AddTicks(2430), "", -117315512, 69, 1 },
                    { 435, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 19, 12, 630, DateTimeKind.Unspecified).AddTicks(2070), "", -1640463658, 70, 1 },
                    { 436, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 19, 13, 177, DateTimeKind.Unspecified).AddTicks(2230), "", 344486730, 71, 1 },
                    { 437, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 28, 58, 192, DateTimeKind.Unspecified).AddTicks(7760), "", 1803160397, 72, 1 },
                    { 438, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 28, 58, 204, DateTimeKind.Unspecified).AddTicks(3250), "", -78804368, 73, 1 },
                    { 439, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 32, 43, 415, DateTimeKind.Unspecified).AddTicks(3910), "", -639457660, 74, 1 },
                    { 440, 0.0m, 0.0m, new DateTime(2025, 5, 10, 0, 32, 44, 44, DateTimeKind.Unspecified).AddTicks(9640), "", 1253061109, 75, 1 },
                    { 441, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 4, 16, 957, DateTimeKind.Unspecified).AddTicks(1760), "", 1587695327, 76, 1 },
                    { 442, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 4, 17, 641, DateTimeKind.Unspecified).AddTicks(4790), "", 1283534201, 77, 1 },
                    { 443, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 4, 18, 187, DateTimeKind.Unspecified).AddTicks(6000), "", -1751487474, 78, 1 },
                    { 444, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 24, 13, 304, DateTimeKind.Unspecified).AddTicks(1000), "", -2132370207, 79, 1 },
                    { 445, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 24, 14, 1, DateTimeKind.Unspecified).AddTicks(5690), "", 1293335126, 80, 1 },
                    { 446, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 24, 14, 550, DateTimeKind.Unspecified).AddTicks(2530), "", -2021949144, 81, 1 },
                    { 447, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 31, 38, 511, DateTimeKind.Unspecified).AddTicks(7570), "", 506545946, 82, 1 },
                    { 448, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 33, 54, 479, DateTimeKind.Unspecified).AddTicks(2090), "", 864506760, 83, 1 },
                    { 449, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 36, 53, 34, DateTimeKind.Unspecified).AddTicks(490), "", -2071640792, 84, 1 },
                    { 450, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 36, 53, 777, DateTimeKind.Unspecified).AddTicks(1910), "", -624568661, 85, 1 },
                    { 451, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 39, 57, 221, DateTimeKind.Unspecified).AddTicks(4660), "", -1770212507, 86, 1 },
                    { 452, 0.0m, 0.0m, new DateTime(2025, 5, 13, 4, 47, 45, 8, DateTimeKind.Unspecified).AddTicks(5410), "", -1835966192, 87, 1 },
                    { 453, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 20, 28, 415, DateTimeKind.Unspecified).AddTicks(7580), "", 1709001057, 88, 1 },
                    { 454, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 20, 29, 79, DateTimeKind.Unspecified).AddTicks(4410), "", 2145972794, 89, 1 },
                    { 455, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 20, 29, 680, DateTimeKind.Unspecified).AddTicks(540), "", 793258737, 90, 1 },
                    { 456, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 20, 30, 286, DateTimeKind.Unspecified).AddTicks(7300), "", -107742489, 91, 1 },
                    { 457, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 21, 7, 787, DateTimeKind.Unspecified).AddTicks(6180), "", -948700273, 92, 1 },
                    { 458, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 21, 8, 382, DateTimeKind.Unspecified).AddTicks(2870), "", -2138826242, 93, 1 },
                    { 459, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 21, 8, 942, DateTimeKind.Unspecified).AddTicks(1350), "", 1203984678, 94, 1 },
                    { 460, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 21, 9, 446, DateTimeKind.Unspecified).AddTicks(2240), "", 2102274075, 95, 1 },
                    { 461, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 28, 55, 69, DateTimeKind.Unspecified).AddTicks(4390), "", 1978421488, 96, 1 },
                    { 462, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 28, 55, 726, DateTimeKind.Unspecified).AddTicks(300), "", -2077826128, 97, 1 },
                    { 463, 0.0m, 0.0m, new DateTime(2025, 5, 13, 5, 28, 56, 345, DateTimeKind.Unspecified).AddTicks(5070), "", 168619599, 98, 1 },
                    { 464, 0.0m, 0.0m, new DateTime(2025, 5, 15, 1, 27, 30, 993, DateTimeKind.Unspecified).AddTicks(2060), "", -227632277, 99, 1 },
                    { 465, 0.0m, 0.0m, new DateTime(2025, 5, 15, 1, 27, 31, 144, DateTimeKind.Unspecified).AddTicks(5080), "", 195446675, 100, 1 },
                    { 466, 0.0m, 0.0m, new DateTime(2025, 5, 15, 3, 13, 5, 14, DateTimeKind.Unspecified).AddTicks(2330), "", -1544316081, 101, 1 },
                    { 467, 0.0m, 0.0m, new DateTime(2025, 5, 15, 3, 13, 5, 747, DateTimeKind.Unspecified).AddTicks(7000), "", 1207792905, 102, 1 },
                    { 468, 0.0m, 0.0m, new DateTime(2025, 5, 16, 23, 27, 33, 839, DateTimeKind.Unspecified).AddTicks(7850), "", 1851213644, 103, 1 },
                    { 469, 0.0m, 0.0m, new DateTime(2025, 5, 16, 23, 27, 40, 895, DateTimeKind.Unspecified).AddTicks(7700), "", 170631668, 104, 1 },
                    { 470, 0.0m, 0.0m, new DateTime(2025, 5, 16, 23, 27, 41, 626, DateTimeKind.Unspecified).AddTicks(650), "", 1855668163, 105, 1 },
                    { 471, 0.0m, 0.0m, new DateTime(2025, 5, 16, 23, 27, 42, 503, DateTimeKind.Unspecified).AddTicks(2360), "", 1528483809, 106, 1 },
                    { 472, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 19, 20, 901, DateTimeKind.Unspecified).AddTicks(490), "", 1230682969, 1, 2 },
                    { 473, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 25, 52, 939, DateTimeKind.Unspecified).AddTicks(8840), "", 645972440, 2, 2 },
                    { 474, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 25, 53, 145, DateTimeKind.Unspecified).AddTicks(5070), "", 862020548, 3, 2 },
                    { 475, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 30, 55, 732, DateTimeKind.Unspecified).AddTicks(3100), "", 275006179, 4, 2 },
                    { 476, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 30, 56, 413, DateTimeKind.Unspecified).AddTicks(9190), "", 755024394, 5, 2 },
                    { 477, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 33, 13, 372, DateTimeKind.Unspecified).AddTicks(9820), "", 2022406575, 6, 2 },
                    { 478, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 33, 14, 5, DateTimeKind.Unspecified).AddTicks(2300), "", 1778447279, 7, 2 },
                    { 479, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 38, 18, 57, DateTimeKind.Unspecified).AddTicks(4180), "", 1552646244, 8, 2 },
                    { 480, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 43, 3, 647, DateTimeKind.Unspecified).AddTicks(3310), "", -1197801003, 9, 2 },
                    { 481, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 50, 58, 20, DateTimeKind.Unspecified).AddTicks(5730), "", 2031492700, 10, 2 },
                    { 482, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 58, 55, 101, DateTimeKind.Unspecified).AddTicks(8280), "", -1460276000, 11, 2 },
                    { 483, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 58, 55, 942, DateTimeKind.Unspecified).AddTicks(6570), "", -675629490, 12, 2 },
                    { 484, 0.0m, 0.0m, new DateTime(2025, 5, 29, 8, 59, 3, 783, DateTimeKind.Unspecified).AddTicks(8020), "", -761185692, 13, 2 },
                    { 485, 0.0m, 0.0m, new DateTime(2025, 5, 29, 9, 4, 5, 911, DateTimeKind.Unspecified).AddTicks(8480), "", 1262109008, 14, 2 },
                    { 486, 0.0m, 0.0m, new DateTime(2025, 5, 29, 9, 4, 8, 50, DateTimeKind.Unspecified).AddTicks(550), "", -63643778, 15, 2 },
                    { 487, 0.0m, 0.0m, new DateTime(2025, 5, 31, 2, 42, 3, 626, DateTimeKind.Unspecified).AddTicks(7980), "", -553881046, 16, 2 },
                    { 488, 0.0m, 0.0m, new DateTime(2025, 5, 31, 2, 42, 4, 30, DateTimeKind.Unspecified).AddTicks(740), "", 686271052, 17, 2 },
                    { 489, 0.0m, 0.0m, new DateTime(2025, 5, 31, 2, 42, 4, 604, DateTimeKind.Unspecified).AddTicks(1440), "", -176856354, 18, 2 },
                    { 490, 0.0m, 0.0m, new DateTime(2025, 5, 31, 3, 4, 20, 120, DateTimeKind.Unspecified).AddTicks(8300), "", 532330216, 19, 2 },
                    { 491, 0.0m, 0.0m, new DateTime(2025, 6, 2, 2, 16, 45, 746, DateTimeKind.Unspecified).AddTicks(5190), "", -1066189881, 20, 2 },
                    { 492, 0.0m, 0.0m, new DateTime(2025, 6, 2, 2, 16, 46, 446, DateTimeKind.Unspecified).AddTicks(7320), "", 1558556560, 21, 2 },
                    { 493, 0.0m, 0.0m, new DateTime(2025, 6, 2, 2, 16, 47, 262, DateTimeKind.Unspecified).AddTicks(8470), "", 1141022357, 22, 2 },
                    { 494, 0.0m, 0.0m, new DateTime(2025, 6, 2, 2, 16, 47, 844, DateTimeKind.Unspecified).AddTicks(7390), "", 1904293152, 23, 2 },
                    { 495, 0.0m, 0.0m, new DateTime(2025, 6, 2, 2, 16, 48, 413, DateTimeKind.Unspecified).AddTicks(9950), "", 1213235935, 24, 2 },
                    { 496, 0.0m, 0.0m, new DateTime(2025, 6, 2, 2, 30, 18, 970, DateTimeKind.Unspecified).AddTicks(7860), "", 1615510191, 25, 2 },
                    { 497, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 29, 11, 182, DateTimeKind.Unspecified).AddTicks(2040), "", -321333027, 26, 2 },
                    { 498, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 29, 11, 954, DateTimeKind.Unspecified).AddTicks(6360), "", 414654264, 27, 2 },
                    { 499, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 29, 12, 6, DateTimeKind.Unspecified).AddTicks(7280), "", -1656828590, 28, 2 },
                    { 500, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 29, 12, 515, DateTimeKind.Unspecified).AddTicks(2380), "", 512975954, 29, 2 },
                    { 501, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 40, 46, 237, DateTimeKind.Unspecified).AddTicks(470), "", -675204134, 30, 2 },
                    { 502, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 45, 24, 699, DateTimeKind.Unspecified).AddTicks(6580), "", 690737558, 31, 2 },
                    { 503, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 45, 25, 372, DateTimeKind.Unspecified).AddTicks(2720), "", -1765415085, 32, 2 },
                    { 504, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 45, 25, 826, DateTimeKind.Unspecified).AddTicks(7710), "", -1564917424, 33, 2 },
                    { 505, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 45, 26, 241, DateTimeKind.Unspecified).AddTicks(5380), "", -1669243508, 34, 2 },
                    { 506, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 45, 35, 219, DateTimeKind.Unspecified).AddTicks(7000), "", 1631107571, 35, 2 },
                    { 507, 0.0m, 0.0m, new DateTime(2025, 6, 2, 7, 54, 10, 299, DateTimeKind.Unspecified).AddTicks(6500), "", -1304223134, 36, 2 },
                    { 508, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 2, 1, 408, DateTimeKind.Unspecified).AddTicks(3860), "", 769544500, 37, 2 },
                    { 509, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 2, 1, 571, DateTimeKind.Unspecified).AddTicks(9770), "", -578092697, 38, 2 },
                    { 510, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 2, 1, 717, DateTimeKind.Unspecified).AddTicks(1850), "", 1122287383, 39, 2 },
                    { 511, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 2, 1, 863, DateTimeKind.Unspecified).AddTicks(9490), "", -599974417, 40, 2 },
                    { 512, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 2, 2, 9, DateTimeKind.Unspecified).AddTicks(20), "", 326031833, 41, 2 },
                    { 513, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 2, 2, 118, DateTimeKind.Unspecified).AddTicks(1490), "", -1970342949, 42, 2 },
                    { 514, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 16, 40, 319, DateTimeKind.Unspecified).AddTicks(2610), "", -1757987509, 43, 2 },
                    { 515, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 16, 40, 321, DateTimeKind.Unspecified).AddTicks(7820), "", 32544192, 43, 2 },
                    { 516, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 16, 40, 332, DateTimeKind.Unspecified).AddTicks(5490), "", 1307011447, 44, 2 },
                    { 517, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 16, 40, 451, DateTimeKind.Unspecified).AddTicks(9000), "", 361983424, 45, 2 },
                    { 518, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 16, 40, 614, DateTimeKind.Unspecified).AddTicks(2460), "", 1465950619, 46, 2 },
                    { 519, 0.0m, 0.0m, new DateTime(2025, 6, 2, 8, 16, 40, 779, DateTimeKind.Unspecified).AddTicks(5720), "", 418578155, 47, 2 },
                    { 520, 0.0m, 0.0m, new DateTime(2025, 6, 2, 9, 14, 58, 352, DateTimeKind.Unspecified).AddTicks(7130), "", 1053663059, 48, 2 },
                    { 521, 0.0m, 0.0m, new DateTime(2025, 6, 2, 9, 14, 58, 959, DateTimeKind.Unspecified).AddTicks(4690), "", -1285554869, 49, 2 },
                    { 522, 0.0m, 0.0m, new DateTime(2025, 6, 2, 9, 14, 59, 502, DateTimeKind.Unspecified).AddTicks(3820), "", -434008255, 50, 2 },
                    { 523, 0.0m, 0.0m, new DateTime(2025, 6, 2, 9, 15, 0, 121, DateTimeKind.Unspecified).AddTicks(8980), "", -136993850, 51, 2 },
                    { 524, 0.0m, 0.0m, new DateTime(2025, 6, 2, 9, 15, 0, 783, DateTimeKind.Unspecified).AddTicks(6450), "", 1593846227, 52, 2 },
                    { 525, 0.0m, 0.0m, new DateTime(2025, 6, 2, 9, 15, 1, 293, DateTimeKind.Unspecified).AddTicks(5830), "", -1061727491, 53, 2 },
                    { 526, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 5, 50, 549, DateTimeKind.Unspecified).AddTicks(8030), "", 326525530, 54, 2 },
                    { 527, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 5, 50, 787, DateTimeKind.Unspecified).AddTicks(8510), "", -882891001, 55, 2 },
                    { 528, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 5, 51, 460, DateTimeKind.Unspecified).AddTicks(4900), "", -50908549, 56, 2 },
                    { 529, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 5, 51, 991, DateTimeKind.Unspecified).AddTicks(8670), "", -928289621, 57, 2 },
                    { 530, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 36, 58, 820, DateTimeKind.Unspecified).AddTicks(4440), "", 1777516658, 58, 2 },
                    { 531, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 36, 59, 231, DateTimeKind.Unspecified).AddTicks(3770), "", 1194968779, 59, 2 },
                    { 532, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 36, 59, 667, DateTimeKind.Unspecified).AddTicks(4940), "", -988036519, 60, 2 },
                    { 533, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 37, 0, 196, DateTimeKind.Unspecified).AddTicks(7750), "", -174670964, 61, 2 },
                    { 534, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 45, 42, 240, DateTimeKind.Unspecified).AddTicks(9870), "", -1315868896, 62, 2 },
                    { 535, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 45, 42, 645, DateTimeKind.Unspecified).AddTicks(4900), "", 874889837, 63, 2 },
                    { 536, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 45, 43, 256, DateTimeKind.Unspecified).AddTicks(4190), "", 1746866050, 64, 2 },
                    { 537, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 53, 58, 461, DateTimeKind.Unspecified).AddTicks(1310), "", 213426622, 65, 2 },
                    { 538, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 53, 59, 286, DateTimeKind.Unspecified).AddTicks(2820), "", 47068616, 66, 2 },
                    { 539, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 54, 0, 184, DateTimeKind.Unspecified).AddTicks(6540), "", 1119574873, 67, 2 },
                    { 540, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 54, 1, 48, DateTimeKind.Unspecified).AddTicks(8670), "", -2103654151, 68, 2 },
                    { 541, 0.0m, 0.0m, new DateTime(2025, 6, 4, 7, 55, 23, 938, DateTimeKind.Unspecified).AddTicks(7960), "", -1894574697, 69, 2 },
                    { 542, 0.0m, 0.0m, new DateTime(2025, 6, 4, 8, 29, 22, 430, DateTimeKind.Unspecified).AddTicks(5830), "", 993286031, 70, 2 },
                    { 543, 0.0m, 0.0m, new DateTime(2025, 6, 4, 8, 29, 22, 539, DateTimeKind.Unspecified).AddTicks(4710), "", 1581696992, 71, 2 },
                    { 544, 0.0m, 0.0m, new DateTime(2025, 6, 4, 8, 29, 22, 671, DateTimeKind.Unspecified).AddTicks(1540), "", 266727393, 72, 2 },
                    { 545, 0.0m, 0.0m, new DateTime(2025, 6, 4, 8, 29, 22, 828, DateTimeKind.Unspecified).AddTicks(7580), "", 296251884, 73, 2 },
                    { 546, 0.0m, 0.0m, new DateTime(2025, 6, 4, 8, 29, 22, 915, DateTimeKind.Unspecified).AddTicks(8040), "", 621624807, 74, 2 },
                    { 547, 0.0m, 0.0m, new DateTime(2025, 6, 11, 2, 41, 23, 42, DateTimeKind.Unspecified).AddTicks(3990), "", -434295120, 75, 2 },
                    { 548, 0.0m, 0.0m, new DateTime(2025, 6, 11, 2, 52, 32, 645, DateTimeKind.Unspecified).AddTicks(2440), "", 516645270, 76, 2 },
                    { 549, 0.0m, 0.0m, new DateTime(2025, 6, 11, 5, 24, 27, 23, DateTimeKind.Unspecified).AddTicks(520), "", 294699678, 77, 2 },
                    { 550, 0.0m, 0.0m, new DateTime(2025, 6, 11, 5, 30, 41, 258, DateTimeKind.Unspecified).AddTicks(3790), "", 422744706, 78, 2 },
                    { 551, 0.0m, 0.0m, new DateTime(2025, 6, 11, 7, 13, 4, 480, DateTimeKind.Unspecified).AddTicks(8490), "", -454382323, 79, 2 },
                    { 552, 0.0m, 0.0m, new DateTime(2025, 6, 11, 7, 13, 5, 761, DateTimeKind.Unspecified).AddTicks(7270), "", 1796171563, 80, 2 },
                    { 553, 0.0m, 0.0m, new DateTime(2025, 6, 11, 7, 42, 32, 863, DateTimeKind.Unspecified).AddTicks(5760), "", -135340982, 81, 2 },
                    { 554, 0.0m, 0.0m, new DateTime(2025, 6, 11, 8, 13, 54, 637, DateTimeKind.Unspecified).AddTicks(8000), "", 228727657, 82, 2 },
                    { 555, 0.0m, 0.0m, new DateTime(2025, 6, 11, 8, 37, 8, 330, DateTimeKind.Unspecified).AddTicks(9360), "", 73233165, 83, 2 },
                    { 556, 0.0m, 0.0m, new DateTime(2025, 6, 18, 2, 4, 0, 586, DateTimeKind.Unspecified).AddTicks(9700), "", 1621056683, 107, 1 },
                    { 557, 0.0m, 0.0m, new DateTime(2025, 6, 18, 2, 4, 1, 142, DateTimeKind.Unspecified).AddTicks(5240), "", -517273955, 108, 1 },
                    { 558, 0.0m, 0.0m, new DateTime(2025, 6, 18, 2, 4, 1, 614, DateTimeKind.Unspecified).AddTicks(7510), "", -276464502, 109, 1 },
                    { 559, 0.0m, 0.0m, new DateTime(2025, 6, 18, 2, 4, 2, 37, DateTimeKind.Unspecified).AddTicks(9330), "", 414054040, 110, 1 }
                });

            migrationBuilder.InsertData(
                table: "Racks",
                columns: new[] { "Id", "BayId", "DateAdded", "IsFloorDocking", "LevelId", "Name", "WarehouseId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7169), false, 3, "Metal Shelving 1", 1 },
                    { 2, 1, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7183), false, 5, "Metal Shelving 2", 1 },
                    { 3, 3, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7184), false, 4, "Pallet Racking 1", 1 },
                    { 4, 6, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7185), false, 4, "Pallet Racking 2", 1 },
                    { 5, 3, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7186), false, 4, "Pallet Racking 3", 1 },
                    { 6, 2, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7187), false, 7, "Crossdocking 1", 1 },
                    { 7, 2, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7188), false, 7, "Crossdocking 2", 1 },
                    { 8, 2, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7189), false, 7, "Crossdocking 3", 1 },
                    { 9, 1, new DateTime(2025, 7, 3, 13, 50, 33, 855, DateTimeKind.Local).AddTicks(7190), false, 7, "Crossdocking 4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Receivings",
                columns: new[] { "Id", "CheckerName", "ClientRepresentative", "Consignee", "DateAdded", "DateReceived", "DateTime", "DriverName", "PlateNumber", "Reference", "Series", "Shipper", "TimeEnd", "TimeStart", "TransportCompany", "WarehouseId" },
                values: new object[,]
                {
                    { 1, "VAN VERGEL CORTE", "", "", new DateTime(2025, 1, 22, 1, 48, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 8, 33, 0, 0, DateTimeKind.Unspecified), "NORBERTO TAMON", "NAQ9905", "BS23580", "SLCWH-00001-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 10, 10, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 8, 33, 0, 0, DateTimeKind.Unspecified), "REGENT FOOD CORPORATION", 1 },
                    { 2, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 48, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", "NAQ3433", "SI8100009660", "SLCWH-00002-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 12, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 3, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 1, 58, 1, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "JOEY ANASTACIO", "NAM4312", "SI8100009350", "SLCWH-00003-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING COPORATION", 1 },
                    { 4, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 17, 0, 0, DateTimeKind.Unspecified), "JANWARREN REYES", "NHF7527", "SI8100009681", "SLCWH-00004-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 13, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 17, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 5, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 1, 27, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 43, 0, 0, DateTimeKind.Unspecified), "RANDOLPH MAGDAMIT", "CAJ8292", "SI8100009680", "SLCWH-00005-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 14, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 43, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING COPORATION", 1 },
                    { 6, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 18, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 9, 0, 0, DateTimeKind.Unspecified), "JANVIE CABALE", "XTB145", "SI8100009707", "SLCWH-00006-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 14, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 9, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 7, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 20, 34, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 35, 0, 0, DateTimeKind.Unspecified), "JAYNARD CLAVO", "NIO8373", "SI8100009711", "SLCWH-00007-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 35, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 8, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 24, 44, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 52, 0, 0, DateTimeKind.Unspecified), "ALLAN BARREDO", "NBS2417", "SI8100009713", "SLCWH-00008-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 52, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 9, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 27, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 11, 0, 0, DateTimeKind.Unspecified), "MARK EDISON REGENCIA", "NBR9810", "SI8100009712", "SLCWH-00009-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 15, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 11, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 10, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 29, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 11, 45, 0, 0, DateTimeKind.Unspecified), "JEYVIN HELIS", "XTK237", "SI8100010505", "SLCWH-00010-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 16, 12, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 11, 45, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 11, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 35, 41, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 12, 8, 0, 0, DateTimeKind.Unspecified), "JOHANSON OLIVEROS", "NAO9918", "SI8100010504", "SLCWH-00011-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 16, 12, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 12, 8, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 12, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 38, 14, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 13, 45, 0, 0, DateTimeKind.Unspecified), "RANDOLPH MAGDAMIT", "CAJ8292", "SI8100010518", "SLCWH-00012-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 16, 14, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 45, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 13, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 40, 45, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "JOEY ANASTACIO", "NAM4312", "SI8100011269", "SLCWH-00013-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 17, 10, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / VONE TRUCKING", 1 },
                    { 14, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 44, 46, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "JOEY ANASTACIO", "NAM4312", "SI8100011267", "SLCWH-00014-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 7, 10, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / VONE TRUCKING", 1 },
                    { 18, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 25, 2, 30, 20, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV 103001428147", "SLCWH-00015-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 19, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 25, 2, 33, 39, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV 103001428148", "SLCWH-00016-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 20, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 25, 2, 36, 43, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV 103001428146", "SLCWH-00017-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 21, "VAN VERGEL CONTE", "", "BESTCHILL INC", new DateTime(2025, 1, 25, 3, 25, 23, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "ASDAD", "ABC1234", "INV AA-1111001", "SLCWH-00018-25", "FLUTAI COMPANY LIMITED", new DateTime(2022, 11, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "SKYBEST LOGISTICS CORPORATION", 1 },
                    { 22, "VAN VERGEL CONTE", "", "", new DateTime(2025, 3, 7, 10, 0, 34, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 1, 10, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 8, 34, 0, 0, DateTimeKind.Unspecified), "Samuel Ramos", "NBE7478", "1106083", "SLCWH-00019-25", "EAST RIZAL TRADING", new DateTime(2025, 2, 25, 9, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 8, 34, 0, 0, DateTimeKind.Unspecified), "REGENT FOODS CORP / JWDC TRUCKING", 1 },
                    { 23, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 2, 50, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 8, 35, 0, 0, DateTimeKind.Unspecified), "RINATO LOPEZ", "CBB4965", "8100047950", "SLCWH-00020-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 9, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 8, 35, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 24, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 9, 7, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 9, 24, 0, 0, DateTimeKind.Unspecified), "Jaynard Clavo", "NIO 8373", "8100047812", "SLCWH-00021-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 9, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 9, 24, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 25, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 11, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 15, 0, 0, DateTimeKind.Unspecified), "JOHANSON OLIVEROS", "NAO 9915", "8100047630", "SLCWH-00022-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 10, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 15, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 26, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 17, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", "NBT 8366", "8100047625", "SLCWH-00023-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 27, "", "", "", new DateTime(2025, 3, 5, 1, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 1, 17, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", "NBT 8366", "8100047587", "SLCWH-00024-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 28, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 26, 18, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 11, 0, 0, DateTimeKind.Unspecified), "MICHAEL GARLANDO", "NAQ 3433", "8100047808", "SLCWH-00025-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 11, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 29, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 28, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), "ELWEN ACOS", "NBR 9963", "8100047804", "SLCWH-00026-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 30, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 2, 28, 9, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 2, 21, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 8, 31, 0, 0, DateTimeKind.Unspecified), "JOHANSON OLIVEROS", "RHE 512", "8100048625", "SLCWH-00027-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 8, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 8, 31, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 31, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 2, 33, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 2, 30, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "J. DELA CERNA", "NAQ 3433", "8100048620", "SLCWH-00028-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 9, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 32, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 3, 37, 27, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 3, 30, 54, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 10, 59, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", "NBT 8366", "8100048619", "SLCWH-00029-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 11, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 10, 59, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 33, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 6, 32, 30, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 5, 59, 58, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 1, 35, 0, 0, DateTimeKind.Unspecified), "ERNESTO JAMERO", "XTB145", "8100048629", "SLCWH-00030-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 1, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 1, 35, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 34, "VAN VERGEL CONTE", "", "BESTCHILL INC", new DateTime(2025, 3, 13, 2, 26, 56, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 13, 10, 0, 0, DateTimeKind.Unspecified), "JERSON", "ABC1234", "INV: 20221118", "SLCWH-00031-25", "DONGGUAN TONGDA STORAGE SERVE CO., LTD.", new DateTime(2025, 3, 7, 13, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 13, 10, 0, 0, DateTimeKind.Unspecified), "SKYBEST LOGISTICS CORPORATION", 1 },
                    { 35, "JAN MICHAEL LARDIZABAL", "", "", new DateTime(2025, 4, 8, 1, 45, 52, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 1, 38, 26, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "JANCARL DEL ROSARIO", "NKF2611", "ZMC-0010", "SLCWH-00032-25", "EAST RIZAL TRADING", new DateTime(2025, 8, 4, 9, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "Zesto Corporation", 1 },
                    { 36, "VAN VERGEL CONTE", "", "", new DateTime(2025, 5, 9, 2, 10, 52, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 2, 6, 5, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "JOHN CUTAMORA", "NBY 4315", "SI8100093852", "SLCWH-00033-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 9, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 37, "VAN VERGEL CONTE", "", "", new DateTime(2025, 5, 9, 2, 14, 1, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 2, 11, 14, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "JOHN CUTAMORA", "NBY 4315", "SI8100093853", "SLCWH-00034-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 9, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 38, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 9, 2, 19, 18, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 2, 14, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 9, 44, 0, 0, DateTimeKind.Unspecified), "JONVIE CABALE", "ABK 6586", "SI8100093854", "SLCWH-00035-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 10, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 9, 44, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 39, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 9, 3, 58, 40, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 3, 27, 8, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 10, 34, 0, 0, DateTimeKind.Unspecified), "ALEX QUERIZA", "NBX 7265", "SI8100093962", "SLCWH-00036-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 11, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 10, 34, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 40, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 9, 4, 20, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 4, 12, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 11, 55, 0, 0, DateTimeKind.Unspecified), "JEFERSON URCIA", "CCO 5221", "SI8100094566", "SLCWH-00037-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 0, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 11, 55, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 41, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 10, 0, 22, 30, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 0, 19, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 31, 0, 0, DateTimeKind.Unspecified), "ANGELO PADRE", "GAK 2456", "26887", "SLCWH-00038-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 10, 7, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 31, 0, 0, DateTimeKind.Unspecified), "MAGIS DISTRIBUTION INC", 1 },
                    { 42, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 10, 0, 34, 35, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 0, 32, 14, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 49, 0, 0, DateTimeKind.Unspecified), "ALEX ENCISO", "UIX 617", "10068437", "SLCWH-00039-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 10, 7, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 49, 0, 0, DateTimeKind.Unspecified), "JARCFMCG DISTRIBUTIONG CORP.", 1 },
                    { 43, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 2, 25, 33, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 2, 21, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 8, 43, 0, 0, DateTimeKind.Unspecified), "JERIC ZETA", "NEG 4134", "BS 239266", "SLCWH-00040-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 10, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 8, 43, 0, 0, DateTimeKind.Unspecified), "REGENT FOOD CORPORATION / JWDS", 1 },
                    { 44, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 30, 49, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 23, 30, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH 3355", "INV: 103001724905", "SLCWH-00041-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 45, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 44, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 31, 7, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV: 103001724906", "SLCWH-00042-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 46, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 35, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 33, 20, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV: 103001724908", "SLCWH-00043-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 47, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 39, 12, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 35, 16, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV: 103001724910", "SLCWH-00044-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 48, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 46, 40, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 39, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV: 103001724911", "SLCWH-00045-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 49, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 48, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 47, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", "CAH3355", "INV: 103001724912", "SLCWH-00046-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 50, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 5, 28, 6, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 5, 20, 48, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "ELIAZAR UMOQUIT", "CAL 3472", "INV: 103001724907", "SLCWH-00047-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 13, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 51, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 5, 31, 57, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 5, 28, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "ELIAZAR UMOQUIT", "CAL 3472", "INV: 103001724909", "SLCWH-00048-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 13, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 52, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 15, 1, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 1, 27, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 9, 11, 0, 0, DateTimeKind.Unspecified), "RISER SORIANO", "NAN2206", "264051", "SLCWH-00049-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 15, 9, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 9, 11, 0, 0, DateTimeKind.Unspecified), "PRIFOOD CORPORATION", 1 },
                    { 53, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 15, 3, 16, 17, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 3, 12, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 10, 58, 0, 0, DateTimeKind.Unspecified), "EDWIN PADEROS", "NKF3224", "0", "SLCWH-00050-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 15, 11, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 10, 58, 0, 0, DateTimeKind.Unspecified), "WL FOODS (LALAMOVE)", 1 },
                    { 54, "JAN MICHAEL LARDIZABAL", "", "", new DateTime(2025, 5, 16, 23, 35, 34, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 16, 23, 27, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 17, 7, 20, 0, 0, DateTimeKind.Unspecified), "ROBERT DOMINGO JR", "CCB6518", "DR01319916", "SLCWH-00051-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 17, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 17, 7, 20, 0, 0, DateTimeKind.Unspecified), "WL FOODS PRODUCTS", 1 },
                    { 55, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 23, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "LYMART BONGAHOY", "CAZ 1482", "104001000000", "SLCWH-00052-25", "RCV", new DateTime(2025, 5, 28, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "SUY SING / VILLALIMA", 2 },
                    { 56, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 30, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 32, 36, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 7, 50, 0, 0, DateTimeKind.Unspecified), "MARK ANTHONY PADILLA", "CAB 5802", "178615", "SLCWH-00053-25", "RCV", new DateTime(2025, 5, 29, 8, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 7, 50, 0, 0, DateTimeKind.Unspecified), "ZESTO CORPORATION / 2K2J-2", 2 },
                    { 57, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 8, 47, 43, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 42, 53, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 12, 15, 0, 0, DateTimeKind.Unspecified), "LESTER SANCHEZ", "DBM 4751", "14021", "SLCWH-00054-25", "RCV", new DateTime(2025, 5, 29, 12, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 12, 15, 0, 0, DateTimeKind.Unspecified), "LIANA'S DAILY MART", 2 },
                    { 58, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 8, 52, 53, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 49, 16, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 14, 49, 0, 0, DateTimeKind.Unspecified), "LARRY BULAGNER", "NHC 5016", "52422", "SLCWH-00055-25", "RCV", new DateTime(2025, 5, 29, 14, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 14, 49, 0, 0, DateTimeKind.Unspecified), "AZUCAR DISTRIBUTION", 2 },
                    { 59, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 3, 20, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 58, 9, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 14, 37, 0, 0, DateTimeKind.Unspecified), "RYAN ARTUGUE", "NKP 4704", "314", "SLCWH-00056-25", "RCV", new DateTime(2025, 5, 28, 14, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 14, 37, 0, 0, DateTimeKind.Unspecified), "BESTMART", 2 },
                    { 60, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 5, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 9, 3, 50, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "DOMINIC BALUYOT", "NKH 1349", "316", "SLCWH-00057-25", "RCV", new DateTime(2025, 5, 28, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "BESTMART", 2 },
                    { 62, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 2, 7, 44, 15, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 9, 1, 0, 0, DateTimeKind.Unspecified), "MAG MINOZA", "NCK 9038", "104001000000", "SLCWH-00058-25", "RCV", new DateTime(2025, 5, 28, 9, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 9, 1, 0, 0, DateTimeKind.Unspecified), "SUY SING", 2 },
                    { 63, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 2, 9, 33, 53, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 8, 15, 0, 0, DateTimeKind.Unspecified), "ALEX BORIGAS", "CBS 2980", "104001000000", "SLCWH-00059-25", "RCV", new DateTime(2025, 5, 28, 8, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 8, 15, 0, 0, DateTimeKind.Unspecified), "SUYSING", 2 },
                    { 64, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 4, 7, 43, 40, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 7, 36, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 8, 50, 0, 0, DateTimeKind.Unspecified), "JOEL EDEM", "PQD 200", "104001000000", "SLCWH-00060-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 4, 9, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 8, 50, 0, 0, DateTimeKind.Unspecified), "SUYSING / TSM TRUCKING", 2 },
                    { 65, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 4, 7, 52, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 7, 44, 7, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 9, 45, 0, 0, DateTimeKind.Unspecified), "ARTHUR ROJAS", "GAA 5050", "11505", "SLCWH-00061-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 4, 10, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 9, 45, 0, 0, DateTimeKind.Unspecified), "PSWRI", 2 },
                    { 66, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 4, 8, 43, 33, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 8, 28, 36, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 10, 47, 0, 0, DateTimeKind.Unspecified), "RUPERTO CHERRY", "NAF 7231", "104001000000", "SLCWH-00062-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 4, 11, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 10, 47, 0, 0, DateTimeKind.Unspecified), "SUYSING / TSM TRUCKING", 2 },
                    { 67, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 2, 44, 27, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 11, 2, 39, 1, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), "VICSON CUDAL", "NHL 5003", "2024-0080", "SLCWH-00063-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 5, 8, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), "EJJC-3 TRUCKING", 2 },
                    { 68, "", "", "", new DateTime(2025, 6, 11, 3, 39, 18, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "MARK VALENUEVA", "XPL 733", "73251", "SLCWH-00064-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 5, 9, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "BILLIES", 2 },
                    { 69, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 3, 39, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "MARK VALENUEVA", "XPL 733", "73251", "SLCWH-00065-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 5, 9, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "BILLIES", 2 },
                    { 70, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 5, 44, 17, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 13, 2, 0, 0, DateTimeKind.Unspecified), "JIMMY BOB VISTAL", "NEV 4353", "239091", "SLCWH-00066-25", "SUNRISE TRADING", new DateTime(2025, 6, 5, 13, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 13, 2, 0, 0, DateTimeKind.Unspecified), "MANIMALIX", 2 },
                    { 71, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 7, 32, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 10, 48, 0, 0, DateTimeKind.Unspecified), "JOHN CABILLO", "NAB 080", "1427", "SLCWH-00067-25", "SUNRISE TRADING", new DateTime(2025, 6, 9, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 10, 48, 0, 0, DateTimeKind.Unspecified), "OGB FOOD", 2 },
                    { 72, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 7, 46, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), "JIMMY BOB VISTAL", "NEV 4353", "239091", "SLCWH-00068-25", "SUNRISE TRADING", new DateTime(2025, 6, 9, 8, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), "MANIMALIX", 2 },
                    { 73, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 8, 21, 5, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "FLORO NOFIES", "RES 126", "55384", "SLCWH-00069-25", "SUNRISE TRADING", new DateTime(2025, 6, 7, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "PIXCEL", 2 },
                    { 74, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 8, 42, 23, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 10, 28, 0, 0, DateTimeKind.Unspecified), "NANTE MABINI", "ABC 123", "1", "SLCWH-00070-25", "SUNRISE TRADING", new DateTime(2025, 6, 10, 10, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 10, 28, 0, 0, DateTimeKind.Unspecified), "VIA LALAMOVE", 2 },
                    { 75, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 18, 2, 6, 37, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 2, 2, 55, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 9, 33, 0, 0, DateTimeKind.Unspecified), "MAGPILI WILLIAM MADRID", "NAA 1320", "Z-MCPPG-0011", "SLCWH-00071-25", "EAST RIZAL TRADING", new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 9, 33, 0, 0, DateTimeKind.Unspecified), "ZESTO CORPORATION / JHEAIN-6", 1 }
                });

            migrationBuilder.InsertData(
                table: "Bins",
                columns: new[] { "Id", "BayId", "BinHashCode", "BinNamesId", "DateAdded", "LevelId", "RackId" },
                values: new object[,]
                {
                    { 1, 1, 976636213, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 1 },
                    { 2, 1, -1979248654, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 1 },
                    { 3, 1, 1673490748, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 1 },
                    { 4, 2, 1701384564, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 1 },
                    { 5, 2, 196724902, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 1 },
                    { 6, 2, -484174977, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 1 },
                    { 7, 3, -1790539235, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 1 },
                    { 8, 3, 642809004, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 1 },
                    { 9, 3, -1992005959, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 1 },
                    { 10, 1, -902286026, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 2 },
                    { 11, 1, 485716536, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 2 },
                    { 12, 1, 120754032, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 2 },
                    { 13, 1, -767892144, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 2 },
                    { 14, 1, -105527948, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 5, 2 },
                    { 15, 1, -1285803628, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 3 },
                    { 16, 1, 800775118, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 3 },
                    { 17, 1, 1019046532, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 3 },
                    { 18, 1, 719689299, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 3 },
                    { 19, 1, 276386526, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 3 },
                    { 20, 1, 1871078101, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 3 },
                    { 21, 1, -341256051, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 3 },
                    { 22, 1, 641176255, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 3 },
                    { 23, 2, -1555901299, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 3 },
                    { 24, 2, -1585561989, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 3 },
                    { 25, 2, 1053115519, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 3 },
                    { 26, 2, -479592046, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 3 },
                    { 27, 2, -1228370061, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 3 },
                    { 28, 2, 1245142399, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 3 },
                    { 29, 2, -652623830, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 3 },
                    { 30, 2, 1485157462, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 3 },
                    { 31, 3, -1358792930, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 3 },
                    { 32, 3, -346485753, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 3 },
                    { 33, 3, 1185566390, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 3 },
                    { 34, 3, -1450237118, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 3 },
                    { 35, 3, 1150083063, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 3 },
                    { 36, 3, -1122546266, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 3 },
                    { 37, 3, -1317167336, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 3 },
                    { 38, 3, 187127893, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 3 },
                    { 39, 1, -1850022207, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 40, 1, 1318415253, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 41, 1, -18621311, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 42, 1, 1420536157, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 43, 1, 1062200443, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 44, 1, -1512804114, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 45, 1, 527966408, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 46, 1, 511745895, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 47, 2, 116982465, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 48, 2, 1654232790, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 49, 2, 334109798, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 50, 2, 1123410421, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 51, 2, -2108006358, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 52, 2, 395006760, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 53, 2, 2010979598, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 54, 2, -40662049, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 55, 3, -1084611347, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 56, 3, -1787215891, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 57, 3, -1643181944, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 58, 3, 1321412513, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 59, 3, -763942232, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 60, 3, -2056561571, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 61, 3, -2118881999, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 62, 3, -470185763, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 63, 4, -1658049340, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 64, 4, 844845106, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 65, 4, -1669224409, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 66, 4, -358179989, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 67, 4, -1955242011, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 68, 4, 1958354202, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 69, 4, 1825131077, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 70, 4, -169292521, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 71, 5, -1517118774, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 72, 5, 1886512625, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 73, 5, -1449568076, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 74, 5, -343470659, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 75, 5, -1614793922, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 76, 5, -56520126, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 77, 5, 692756103, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 78, 5, 1833364874, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 79, 6, 2005043736, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 80, 6, 2046651153, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 4 },
                    { 81, 6, -933943777, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 82, 6, 291972557, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 4 },
                    { 83, 6, -863513047, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 84, 6, -573098862, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 4 },
                    { 85, 6, -326151564, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 86, 6, 997413098, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 4 },
                    { 87, 1, 1638846713, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 5 },
                    { 88, 1, 1543093550, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 5 },
                    { 89, 1, -1128665772, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 5 },
                    { 90, 1, 486148647, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 5 },
                    { 91, 1, -1264708691, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 5 },
                    { 92, 1, 2026885023, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 5 },
                    { 93, 1, 979658065, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 5 },
                    { 94, 1, 1465100942, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 5 },
                    { 95, 2, -1984800236, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 5 },
                    { 96, 2, -1216511168, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 5 },
                    { 97, 2, -456683100, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 5 },
                    { 98, 2, -317063528, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 5 },
                    { 99, 2, -87416372, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 5 },
                    { 100, 2, 411003153, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 5 },
                    { 101, 2, -1884306233, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 5 },
                    { 102, 2, -340554057, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 5 },
                    { 103, 3, -1690893460, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 5 },
                    { 104, 3, -1153602774, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, 5 },
                    { 105, 3, 1710903346, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 5 },
                    { 106, 3, 773588751, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, 5 },
                    { 107, 3, -1603994513, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 5 },
                    { 108, 3, 1282473269, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, 5 },
                    { 109, 3, -57269117, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 5 },
                    { 110, 3, 839865094, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "ReceivedProducts",
                columns: new[] { "Id", "CBM", "ContainerName", "ExpirationDate", "PalletId", "ProductId", "Quantity", "ReceivingId", "Remarks", "TotalWeight" },
                values: new object[,]
                {
                    { 1, "15.51", "", new DateOnly(2026, 1, 20), null, 30, 400, 1, "GOOD CONDITION", "1400" },
                    { 2, "7.75", "", new DateOnly(2026, 1, 10), null, 31, 200, 1, "GOOD CONDITION", "700" },
                    { 3, "23.26", "", new DateOnly(2026, 1, 10), null, 32, 600, 1, "GOOD CONDITION", "2100" },
                    { 4, "15.48", "", new DateOnly(2026, 1, 15), null, 17, 288, 2, "GOOD CONDITION", "1008" },
                    { 5, "2.69", "", new DateOnly(2026, 1, 15), null, 4, 50, 3, "GOOD CONDITION", "175" },
                    { 6, "2.69", "", new DateOnly(2026, 1, 15), null, 6, 50, 3, "GOOD CONDITION", "175" },
                    { 7, "11.61", "", new DateOnly(2026, 1, 15), null, 17, 216, 4, "GOOD CONDITION", "756" },
                    { 8, "12.47", "", new DateOnly(2026, 1, 15), null, 17, 232, 5, "GOOD CONDITION", "812" },
                    { 10, "16.13", "", new DateOnly(2026, 1, 15), null, 11, 300, 6, "GOOD CONDITION", "1050" },
                    { 11, "5.91", "", new DateOnly(2026, 1, 15), null, 2, 171, 6, "GOOD CONDITION", "598.5" },
                    { 12, "5.38", "", new DateOnly(2026, 1, 15), null, 15, 100, 7, "GOOD CONDITION", "350" },
                    { 13, "7.74", "", new DateOnly(2026, 1, 15), null, 17, 144, 7, "GOOD CONDITION", "504" },
                    { 14, "0.66", "", new DateOnly(2026, 1, 15), null, 2, 19, 8, "GOOD CONDITION", "66.5" },
                    { 15, "5.38", "", new DateOnly(2025, 1, 22), null, 13, 100, 8, "GOOD CONDITION", "350" },
                    { 16, "5.38", "", new DateOnly(2026, 1, 15), null, 14, 100, 8, "GOOD CONDITION", "350" },
                    { 17, "6.45", "", new DateOnly(2026, 1, 15), null, 17, 120, 9, "GOOD CONDITION", "420" },
                    { 18, "5.38", "", new DateOnly(2026, 1, 15), null, 12, 100, 9, "GOOD CONDITION", "350" },
                    { 19, "17.1", "", new DateOnly(2026, 1, 16), null, 7, 318, 10, "GOOD CONDITION", "1113" },
                    { 20, "6.91", "", new DateOnly(2026, 1, 16), null, 1, 200, 11, "GOOD CONDITION", "700" },
                    { 21, "10.75", "", new DateOnly(2026, 1, 16), null, 24, 200, 11, "GOOD CONDITION", "700" },
                    { 22, "0.35", "", new DateOnly(2026, 1, 16), null, 2, 10, 11, "GOOD CONDITION", "35" },
                    { 23, "13.28", "", new DateOnly(2026, 1, 16), null, 7, 247, 12, "GOOD CONDITION", "864.5" },
                    { 24, "2.69", "", new DateOnly(2026, 1, 17), null, 18, 50, 13, "GOOD CONDITION", "175" },
                    { 25, "2.69", "", new DateOnly(2026, 1, 17), null, 19, 50, 13, "GOOD CONDITION", "175" },
                    { 26, "2.69", "", new DateOnly(2026, 1, 17), null, 20, 50, 13, "GOOD CONDITION", "175" },
                    { 27, "2.69", "", new DateOnly(2026, 1, 17), null, 3, 50, 14, "GOOD CONDITION", "175" },
                    { 28, "1.88", "", new DateOnly(2026, 1, 17), null, 7, 35, 14, "GOOD CONDITION", "122.5" },
                    { 29, "2.69", "", new DateOnly(2026, 1, 17), null, 22, 50, 14, "GOOD CONDITION", "175" },
                    { 30, "0.65", "", new DateOnly(2026, 1, 17), null, 23, 12, 14, "GOOD CONDITION", "42" },
                    { 37, "0.56", "", new DateOnly(2025, 10, 10), 1, 41, 50, 18, "GOOD CONDITION", "150" },
                    { 38, "0.55", "", new DateOnly(2025, 9, 20), 1, 42, 49, 18, "GOOD CONDITION", "147" },
                    { 39, "0.56", "", new DateOnly(2025, 9, 19), 2, 45, 50, 19, "GOOD CONDITION", "150" },
                    { 40, "0.56", "", new DateOnly(2025, 10, 4), 2, 46, 50, 19, "GOOD CONDITION", "150" },
                    { 41, "0.52", "", new DateOnly(2025, 10, 24), 3, 43, 46, 20, "GOOD CONDITION", "138" },
                    { 42, "0.56", "", new DateOnly(2025, 10, 29), 3, 44, 50, 20, "GOOD CONDITION", "150" },
                    { 43, "0.13", "", new DateOnly(2025, 1, 25), null, 33, 1, 21, "CONTROLLER-3PCS", "0" },
                    { 44, "0.03", "", new DateOnly(2025, 1, 25), null, 34, 1, 21, "CIRCUIT BOARD(TS26F)-10PCS\r\n                  CONTROLLER-3PCS\r\n                  CONTROLLER(NEW)-3PCS\r\n                  SENSORS-18PCS\r\n                  CPR(WITH O-RING)-3PCS\r\n                  FUSE DETECTION BOARD(TS55F)-5PCS", "0" },
                    { 45, "0.27", "", new DateOnly(2025, 1, 25), null, 38, 8, 21, "16SETS", "0" },
                    { 46, "0", "", new DateOnly(2025, 1, 25), null, 37, 1, 21, "6SET - 3SETS OF BY 3's AND 3SETS OF BY 2's", "0" },
                    { 47, "23.26", "", new DateOnly(2026, 2, 25), null, 32, 600, 22, "Good Condition", "2100" },
                    { 48, "15.51", "", new DateOnly(2026, 2, 25), null, 30, 400, 22, "Good Condition", "1400" },
                    { 49, "7.75", "", new DateOnly(2026, 2, 25), null, 31, 200, 22, "Good Condition", "700" },
                    { 50, "40.16", "", new DateOnly(2026, 2, 14), null, 17, 747, 23, "GOOD CONDITION", "2614.5" },
                    { 51, "0.81", "", new DateOnly(2026, 2, 10), null, 11, 15, 23, "GOOD CONDITION", "52.5" },
                    { 52, "1.08", "", new DateOnly(2026, 2, 13), null, 17, 20, 24, "GOOD CONDITION", "70" },
                    { 53, "5.38", "", new DateOnly(2026, 2, 9), null, 12, 100, 24, "GOOD CONDITION", "350" },
                    { 54, "6.72", "", new DateOnly(2026, 2, 18), null, 7, 125, 24, "GOOD CONDITION", "437.5" },
                    { 55, "14.52", "", new DateOnly(2026, 2, 18), null, 7, 270, 25, "GOOD CONDITION", "945" },
                    { 56, "11.02", "", new DateOnly(2026, 2, 18), null, 7, 205, 26, "GOOD CONDITION", "717.5" },
                    { 57, "4.3", "", new DateOnly(2026, 2, 7), 4, 18, 80, 27, "GOOD CONDITION", "280" },
                    { 58, "4.3", "", new DateOnly(2026, 2, 19), 5, 20, 80, 27, "GOOD CONDITION", "280" },
                    { 59, "4.3", "", new DateOnly(2025, 12, 16), 7, 19, 80, 27, "GOOD CONDITION", "280" },
                    { 60, "15.32", "", new DateOnly(2026, 2, 10), null, 11, 285, 28, "GOOD CONDITION", "997.5" },
                    { 61, "12.53", "", new DateOnly(2026, 2, 14), null, 17, 233, 29, "GOOD CONDITION", "815.5" },
                    { 62, "2.1", "", new DateOnly(2026, 2, 21), 8, 24, 39, 30, "GOOD CONDITION", "136.5" },
                    { 63, "0.81", "", new DateOnly(2026, 2, 21), 10, 23, 15, 30, "GOOD CONDITION", "52.5" },
                    { 64, "0.81", "", new DateOnly(2026, 2, 21), 11, 23, 15, 30, "GOOD CONDITION", "52.5" },
                    { 65, "1.08", "", new DateOnly(2026, 2, 21), 13, 23, 20, 30, "GOOD CONDITION", "70" },
                    { 66, "0.11", "", new DateOnly(2026, 2, 27), 14, 21, 2, 30, "GOOD CONDITION", "7" },
                    { 67, "1.34", "", new DateOnly(2026, 2, 5), 15, 4, 25, 30, "GOOD CONDITION", "87.5" },
                    { 68, "1.34", "", new DateOnly(2026, 2, 5), 16, 4, 25, 30, "GOOD CONDITION", "87.5" },
                    { 69, "1.34", "", new DateOnly(2026, 2, 6), 17, 6, 25, 30, "GOOD CONDITION", "87.5" },
                    { 70, "1.34", "", new DateOnly(2026, 2, 6), 18, 6, 25, 30, "GOOD CONDITION", "87.5" },
                    { 71, "1.34", "", new DateOnly(2026, 2, 13), 19, 3, 25, 30, "GOOD CONDITION", "87.5" },
                    { 72, "1.34", "", new DateOnly(2026, 2, 13), 20, 3, 25, 30, "GOOD CONDITION", "87.5" },
                    { 73, "3.87", "", new DateOnly(2026, 2, 18), null, 13, 72, 31, "GOOD CONDITION", "252" },
                    { 74, "5.38", "", new DateOnly(2026, 2, 7), null, 14, 100, 31, "GOOD CONDITION", "350" },
                    { 75, "5.38", "", new DateOnly(2026, 2, 6), null, 15, 100, 31, "GOOD CONDITION", "350" },
                    { 76, "1.51", "", new DateOnly(2026, 2, 18), null, 13, 28, 32, "GOOD CONDITION", "98" },
                    { 77, "1.73", "", new DateOnly(2026, 2, 5), 21, 2, 50, 32, "GOOD CONDITION", "175" },
                    { 78, "1.73", "", new DateOnly(2026, 3, 5), 22, 2, 50, 32, "GOOD CONDITION", "175" },
                    { 79, "1.73", "", new DateOnly(2026, 3, 5), 23, 2, 50, 32, "GOOD CONDITION", "175" },
                    { 80, "1.73", "", new DateOnly(2026, 3, 5), 24, 2, 50, 32, "GOOD CONDITION", "175" },
                    { 81, "1.73", "", new DateOnly(2026, 3, 6), 25, 1, 50, 32, "GOOD CONDITION", "175" },
                    { 82, "1.73", "", new DateOnly(2026, 3, 6), 26, 1, 50, 32, "GOOD CONDITION", "175" },
                    { 83, "1.73", "", new DateOnly(2026, 3, 6), 27, 1, 50, 32, "GOOD CONDITION", "175" },
                    { 84, "1.73", "", new DateOnly(2026, 3, 6), 28, 1, 50, 32, "GOOD CONDITION", "175" },
                    { 85, "3.28", "", new DateOnly(2025, 3, 5), 29, 24, 61, 33, "GOOD CONDITION", "213.5" },
                    { 86, "3.23", "", new DateOnly(2025, 3, 5), 30, 24, 60, 33, "GOOD CONDITION", "210" },
                    { 87, "2.15", "", new DateOnly(2025, 3, 5), 31, 24, 40, 33, "GOOD CONDITION", "140" },
                    { 88, "6.8", "", new DateOnly(2026, 2, 12), null, 48, 100, 33, "GOOD CONDITION", "300" },
                    { 89, "9.38", "", new DateOnly(2026, 2, 18), null, 49, 100, 33, "WRONG FLAVOR ON INVOICE ORDER MUST BE MIGGOS SWEETCORN 105G", "350" },
                    { 90, "0.05", "", new DateOnly(2025, 3, 11), null, 50, 1, 34, "A20221125002", "7" },
                    { 91, "0.13", "", new DateOnly(2025, 3, 13), null, 51, 1, 34, "A20221125028", "25" },
                    { 92, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117020", "6" },
                    { 93, "0.13", "", new DateOnly(2025, 3, 13), null, 53, 1, 34, "A20221122003", "24" },
                    { 94, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117003", "6" },
                    { 95, "0.13", "", new DateOnly(2025, 3, 13), null, 54, 1, 34, "A20221114003", "25" },
                    { 96, "0.28", "", new DateOnly(2025, 3, 13), null, 55, 1, 34, "20211115003", "25" },
                    { 97, "0.28", "", new DateOnly(2025, 3, 13), null, 55, 1, 34, "20211115008", "25" },
                    { 98, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20231129001", "6" },
                    { 99, "0.13", "", new DateOnly(2025, 3, 13), null, 54, 1, 34, "A20231129001", "25" },
                    { 100, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117016", "6" },
                    { 101, "0.13", "", new DateOnly(2025, 3, 13), null, 53, 1, 34, "A20221122001", "24" },
                    { 102, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117016", "6" },
                    { 103, "0.13", "", new DateOnly(2025, 3, 13), null, 53, 1, 34, "A20221122001", "24" },
                    { 104, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117018", "6" },
                    { 105, "0.13", "", new DateOnly(2025, 3, 13), null, 53, 1, 34, "A20221122002", "24" },
                    { 106, "0.28", "", new DateOnly(2025, 3, 13), null, 55, 1, 34, "20211115005", "25" },
                    { 107, "0.28", "", new DateOnly(2025, 3, 13), null, 56, 1, 34, "20201112003", "25" },
                    { 108, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117021", "6" },
                    { 109, "0.13", "", new DateOnly(2025, 3, 13), null, 53, 1, 34, "A20221122004", "24" },
                    { 110, "0.05", "", new DateOnly(2025, 3, 13), null, 50, 1, 34, "A20221125001", "7" },
                    { 111, "0.13", "", new DateOnly(2025, 3, 13), null, 51, 1, 34, "A20221125027", "25" },
                    { 112, "0.05", "", new DateOnly(2025, 3, 13), null, 52, 1, 34, "A20221117022", "6" },
                    { 113, "0.13", "", new DateOnly(2025, 3, 13), null, 53, 1, 34, "A20221122005", "24" },
                    { 114, "0.28", "", new DateOnly(2025, 3, 13), null, 56, 1, 34, "20201112002", "25" },
                    { 115, "0.28", "", new DateOnly(2025, 3, 13), null, 56, 1, 34, "20201112004", "25" },
                    { 116, "0.28", "", new DateOnly(2025, 3, 13), null, 57, 1, 34, "20240604001", "25" },
                    { 117, "0.28", "", new DateOnly(2025, 3, 13), null, 57, 1, 34, "20240604002", "25" },
                    { 118, "0.28", "", new DateOnly(2025, 3, 13), null, 57, 1, 34, "20240604003", "25" },
                    { 119, "0.28", "", new DateOnly(2025, 3, 13), null, 55, 1, 34, "20211115006", "25" },
                    { 120, "0.28", "", new DateOnly(2025, 3, 13), null, 56, 1, 34, "20201112009", "25" },
                    { 121, "0.28", "", new DateOnly(2025, 3, 13), null, 55, 1, 34, "20211115007", "25" },
                    { 122, "0", "", new DateOnly(2025, 12, 6), 398, 58, 30, 35, "GOOD CONDITION", "315" },
                    { 123, "0", "", new DateOnly(2025, 12, 6), 399, 58, 30, 35, "GOOD CONDITION", "315" },
                    { 124, "0", "", new DateOnly(2025, 6, 12), 400, 58, 30, 35, "GOOD CONDITION", "315" },
                    { 125, "0", "", new DateOnly(2025, 6, 12), 401, 58, 30, 35, "GOOD CONDITION", "315" },
                    { 126, "0", "", new DateOnly(2025, 6, 12), 402, 58, 30, 35, "GOOD CONDITION", "315" },
                    { 127, "0", "", new DateOnly(2025, 6, 12), 403, 58, 30, 35, "GOOD CONDITION", "315" },
                    { 128, "4.3", "", new DateOnly(2026, 5, 5), 404, 18, 80, 36, "GOOD CONDITION", "280" },
                    { 129, "4.3", "", new DateOnly(2026, 5, 7), 405, 20, 80, 36, "GOOD CONDITION", "280" },
                    { 130, "4.3", "", new DateOnly(2026, 5, 6), 406, 19, 80, 36, "GOOD CONDITION", "280" },
                    { 131, "26.88", "", new DateOnly(2026, 4, 25), null, 17, 500, 37, "GOOD CONDITION", "1750" },
                    { 132, "9.38", "", new DateOnly(2026, 4, 25), null, 49, 100, 37, "GOOD CONDITION", "350" },
                    { 133, "2.69", "", new DateOnly(2026, 4, 26), null, 11, 50, 37, "GOOD CONDITION", "175" },
                    { 134, "1.51", "", new DateOnly(2026, 4, 27), null, 12, 28, 38, "GOOD CONDITION", "98" },
                    { 135, "8.06", "", new DateOnly(2026, 4, 26), null, 11, 150, 38, "GOOD CONDITION", "525" },
                    { 136, "5.38", "", new DateOnly(2026, 4, 27), null, 13, 100, 38, "GOOD CONDITION", "350" },
                    { 137, "5.38", "", new DateOnly(2026, 4, 22), null, 14, 100, 38, "GOOD CONDITION", "350" },
                    { 138, "5.38", "", new DateOnly(2026, 4, 25), null, 15, 100, 38, "GOOD CONDITION", "350" },
                    { 139, "2.69", "", new DateOnly(2026, 4, 23), 407, 6, 50, 39, "GOOD CONDITION", "175" },
                    { 140, "2.69", "", new DateOnly(2026, 4, 23), 408, 4, 50, 39, "GOOD CONDITION", "175" },
                    { 141, "2.69", "", new DateOnly(2026, 4, 28), 409, 3, 50, 39, "GOOD CONDITION", "175" },
                    { 142, "16.13", "", new DateOnly(2026, 4, 28), null, 25, 300, 39, "GOOD CONDITION", "1050" },
                    { 143, "3.87", "", new DateOnly(2026, 4, 27), null, 12, 72, 39, "GOOD CONDITION", "252" },
                    { 144, "1.73", "", new DateOnly(2026, 4, 23), 410, 1, 50, 39, "GOOD CONDITION", "175" },
                    { 145, "1.73", "", new DateOnly(2026, 4, 23), 411, 1, 50, 39, "GOOD CONDITION", "175" },
                    { 146, "1.73", "", new DateOnly(2026, 4, 23), 412, 1, 50, 39, "GOOD CONDITION", "175" },
                    { 147, "1.73", "", new DateOnly(2026, 4, 23), 413, 1, 50, 39, "GOOD CONDITION", "175" },
                    { 148, "1.73", "", new DateOnly(2026, 4, 24), 414, 2, 50, 39, "GOOD CONDITION", "175" },
                    { 149, "1.73", "", new DateOnly(2026, 4, 24), 415, 2, 50, 39, "GOOD CONDITION", "175" },
                    { 150, "1.73", "", new DateOnly(2026, 4, 24), 416, 2, 50, 39, "GOOD CONDITION", "175" },
                    { 151, "1.73", "", new DateOnly(2026, 4, 24), 417, 2, 50, 39, "GOOD CONDITION", "175" },
                    { 152, "1.7", "", new DateOnly(2026, 4, 25), 423, 48, 25, 40, "GOOD CONDITION", "75" },
                    { 153, "1.7", "", new DateOnly(2026, 4, 25), 424, 48, 25, 40, "GOOD CONDITION", "75" },
                    { 154, "1.7", "", new DateOnly(2026, 4, 25), 425, 48, 25, 40, "GOOD CONDITION", "75" },
                    { 155, "1.7", "", new DateOnly(2026, 4, 25), 426, 48, 25, 40, "GOOD CONDITION", "75" },
                    { 156, "0.22", "", new DateOnly(2026, 4, 27), 427, 21, 4, 40, "GOOD CONDITION", "14" },
                    { 157, "1.34", "", new DateOnly(2026, 4, 26), 428, 23, 25, 40, "GOOD CONDITION", "87.5" },
                    { 158, "1.34", "", new DateOnly(2026, 4, 26), 429, 23, 25, 40, "GOOD CONDITION", "87.5" },
                    { 159, "1.29", "", new DateOnly(2026, 4, 27), 430, 22, 24, 40, "GOOD CONDITION", "84" },
                    { 160, "0.48", "", new DateOnly(2026, 8, 3), 434, 60, 20, 41, "GOOD CONDITION", "150" },
                    { 161, "0.5", "", new DateOnly(2026, 7, 13), 434, 61, 20, 41, "GOOD CONDITION", "180" },
                    { 162, "0.87", "", new DateOnly(2026, 6, 23), 435, 62, 30, 41, "GOOD CONDITION", "240" },
                    { 163, "0.96", "", new DateOnly(2026, 5, 12), 436, 65, 100, 41, "GOOD CONDITION", "700" },
                    { 164, "0.6", "", new DateOnly(2026, 11, 1), 439, 63, 20, 42, "GOOD CONDITION", "290" },
                    { 165, "0.46", "", new DateOnly(2027, 3, 17), 440, 64, 20, 42, "GOOD CONDITION", "230" },
                    { 166, "19.38", "", new DateOnly(2026, 5, 13), null, 32, 500, 43, "GOOD CONDITION", "1000" },
                    { 167, "11.63", "", new DateOnly(2026, 5, 13), null, 30, 300, 43, "GOOD CONDITION", "600" },
                    { 168, "7.75", "", new DateOnly(2026, 5, 13), null, 31, 200, 43, "GOOD CONDITION", "400" },
                    { 169, "0.14", "", new DateOnly(2027, 3, 13), 444, 66, 15, 44, "GOOD CONDITION", "15" },
                    { 170, "0.05", "", new DateOnly(2025, 5, 13), 444, 67, 5, 44, "GOOD CONDITION", "5" },
                    { 171, "0.25", "", new DateOnly(2025, 5, 13), 444, 68, 10, 44, "GOOD CONDITION", "20" },
                    { 172, "0.49", "", new DateOnly(2027, 2, 1), 445, 69, 29, 44, "1 CARTON FOR RETURN MISSING 2CANS. RECEIVED 29CARTONS ONLY", "362.5" },
                    { 173, "0.13", "", new DateOnly(2025, 5, 13), 444, 70, 10, 44, "GOOD CONDITION", "15" },
                    { 174, "0.36", "", new DateOnly(2025, 5, 13), 444, 71, 10, 44, "GOOD CONDITION", "30" },
                    { 175, "0.07", "", new DateOnly(2026, 2, 8), 446, 44, 6, 44, "GOOD CONDITION", "18" },
                    { 176, "0.14", "", new DateOnly(2026, 2, 17), 446, 72, 12, 44, "GOOD CONDITION", "36" },
                    { 177, "0.39", "", new DateOnly(2027, 2, 1), 447, 73, 15, 45, "GOOD CONDITION", "307.5" },
                    { 178, "0.86", "", new DateOnly(2026, 1, 15), 448, 41, 76, 46, "GOOD CONDITION", "228" },
                    { 179, "0.34", "", new DateOnly(2026, 1, 26), 449, 74, 30, 47, "GOOD CONDITION", "90" },
                    { 180, "0.56", "", new DateOnly(2026, 2, 28), 450, 42, 50, 47, "GOOD CONDITION", "150" },
                    { 181, "0.06", "", new DateOnly(2026, 2, 5), 449, 75, 5, 47, "GOOD CONDITION", "15" },
                    { 182, "0.32", "", new DateOnly(2025, 12, 22), 451, 76, 10, 48, "GOOD CONDITION", "100" },
                    { 183, "0.32", "", new DateOnly(2025, 12, 22), 451, 77, 10, 48, "GOOD CONDITION", "100" },
                    { 184, "0.73", "", new DateOnly(2025, 12, 17), 452, 78, 100, 49, "GOOD CONDITION", "700" },
                    { 185, "0.65", "", new DateOnly(2026, 2, 1), 457, 73, 25, 50, "GOOD CONDITION", "512.5" },
                    { 186, "0.65", "", new DateOnly(2027, 2, 1), 458, 73, 25, 50, "GOOD CONDITION", "512.5" },
                    { 187, "0.65", "", new DateOnly(2027, 2, 1), 459, 73, 25, 50, "GOOD CONDITION", "512.5" },
                    { 188, "0.65", "", new DateOnly(2027, 2, 1), 460, 73, 25, 50, "GOOD CONDITION", "512.5" },
                    { 189, "0.98", "", new DateOnly(2026, 3, 1), 461, 79, 50, 51, "GOOD CONDITION", "575" },
                    { 190, "0.49", "", new DateOnly(2026, 3, 1), 462, 79, 25, 51, "GOOD CONDITION", "287.5" },
                    { 191, "0.49", "", new DateOnly(2026, 3, 1), 463, 79, 25, 51, "GOOD CONDITION", "287.5" },
                    { 192, "2.07", "", new DateOnly(2025, 5, 15), 464, 80, 20, 52, "GOOD CONDITION", "110" },
                    { 193, "2.07", "", new DateOnly(2025, 5, 15), 465, 80, 20, 52, "GOOD CONDITION", "110" },
                    { 194, "1.29", "", new DateOnly(2027, 3, 20), 466, 81, 25, 53, "GOODS CONDITION", "337.5" },
                    { 195, "1.29", "", new DateOnly(2027, 3, 20), 467, 81, 25, 53, "GOOD CONDITION", "337.5" },
                    { 196, "0.38", "", new DateOnly(2025, 5, 16), 468, 82, 25, 54, "GOOD CONDITION", "75" },
                    { 197, "0.38", "", new DateOnly(2026, 5, 5), 469, 82, 25, 54, "good condition", "75" },
                    { 198, "0.38", "", new DateOnly(2026, 5, 5), 470, 82, 25, 54, "Good Condition", "75" },
                    { 199, "0.38", "", new DateOnly(2026, 5, 5), 471, 82, 25, 54, "Good condition", "75" },
                    { 201, "1.47", "", new DateOnly(2026, 12, 22), 472, 83, 30, 55, "GOOD CONDITION", "450" },
                    { 202, "0.63", "", new DateOnly(2025, 11, 25), 477, 84, 200, 56, "GOOD CONDITION", "400" },
                    { 203, "1.05", "", new DateOnly(2025, 11, 25), 478, 85, 333, 56, "GOOD CONDITION", "666" },
                    { 204, "0.59", "", new DateOnly(2025, 11, 2), 480, 86, 15, 57, "GOOD CONDITION", "30" },
                    { 205, "0.13", "", new DateOnly(2025, 11, 25), 480, 88, 5, 57, "GOOD CONDITION", "62.5" },
                    { 206, "0.17", "", new DateOnly(2025, 11, 6), 480, 87, 5, 57, "GOOD CONDITION", "10" },
                    { 207, "1.11", "", new DateOnly(2026, 11, 29), 481, 89, 40, 58, "GOOD CONDITION", "160" },
                    { 208, "1.03", "", new DateOnly(2025, 5, 29), 482, 90, 6, 59, "GOOD CONDITION", "18" },
                    { 209, "1.98", "", new DateOnly(2025, 5, 29), 483, 91, 6, 59, "GOOD CONDITION", "15" },
                    { 210, "1.98", "", new DateOnly(2025, 5, 29), 484, 91, 6, 59, "GOOD CONDITION", "15" },
                    { 211, "1.03", "", new DateOnly(2025, 5, 29), 485, 90, 6, 60, "GOOD CONDITION", "18" },
                    { 212, "8.15", "", new DateOnly(2025, 5, 29), 486, 92, 20, 60, "GOOD CONDITION", "230" },
                    { 232, "0.14", "", new DateOnly(2026, 4, 25), 497, 121, 10, 62, "GOOD CONDITION", "40" },
                    { 233, "0.16", "", new DateOnly(2025, 10, 3), 497, 133, 3, 62, "GOOD CONDITION", "27" },
                    { 234, "0.1", "", new DateOnly(2025, 10, 5), 497, 96, 3, 62, "GOOD CONDITION", "27" },
                    { 235, "0.03", "", new DateOnly(2025, 12, 9), 497, 134, 3, 62, "GOOD CONDITION", "6" },
                    { 236, "0.31", "", new DateOnly(2025, 10, 29), 497, 106, 10, 62, "GOOD CONDITION", "10" },
                    { 237, "0.43", "", new DateOnly(2025, 10, 27), 497, 118, 10, 62, "GOOD CONDITION", "30" },
                    { 238, "0.7", "", new DateOnly(2025, 10, 30), 497, 136, 10, 62, "GOOD CONDITION", "30" },
                    { 239, "0.31", "", new DateOnly(2025, 11, 7), 497, 137, 4, 62, "GOOD CONDITION", "8" },
                    { 240, "0.05", "", new DateOnly(2025, 10, 28), 497, 138, 5, 62, "GOOD CONDITION", "5" },
                    { 241, "0.08", "", new DateOnly(2025, 11, 2), 497, 140, 3, 62, "GOOD CONDITION", "3" },
                    { 242, "0.42", "", new DateOnly(2025, 10, 27), 497, 119, 8, 62, "GOOD CONDITION", "40" },
                    { 243, "0.16", "", new DateOnly(2026, 4, 30), 497, 104, 10, 62, "GOOD CONDITION", "130" },
                    { 244, "1.18", "", new DateOnly(2025, 12, 27), 497, 128, 25, 62, "GOOD CONDITION", "400" },
                    { 245, "0.36", "", new DateOnly(2027, 3, 14), 498, 93, 20, 62, "GOOD CONDITION", "220" },
                    { 246, "0.07", "", new DateOnly(2026, 4, 30), 498, 105, 5, 62, "GOOD CONDITION", "50" },
                    { 247, "0.55", "", new DateOnly(2027, 1, 17), 498, 127, 10, 62, "GOOD CONDITION", "140" },
                    { 248, "0.36", "", new DateOnly(2027, 3, 8), 499, 123, 13, 62, "GOOD CONDITION", "156" },
                    { 249, "0.84", "", new DateOnly(2026, 4, 3), 499, 107, 30, 62, "GOOD CONDITION", "480" },
                    { 250, "1.26", "", new DateOnly(2027, 2, 1), 500, 97, 50, 62, "GOOD CONDITION", "1000" },
                    { 251, "1.26", "", new DateOnly(2027, 2, 1), 501, 97, 50, 62, "GOOD CONDITION", "1000" },
                    { 252, "0.94", "", new DateOnly(2026, 4, 4), 520, 100, 50, 63, "GOOD CONDITION", "950" },
                    { 253, "0.78", "", new DateOnly(2026, 4, 5), 521, 99, 50, 63, "GOOD CONDITION", "750" },
                    { 254, "1.04", "", new DateOnly(2026, 4, 2), 522, 101, 50, 63, "GOOD CONDITION", "800" },
                    { 255, "0.16", "", new DateOnly(2025, 11, 5), 523, 139, 5, 63, "GOOD CONDITION", "5" },
                    { 256, "0.08", "", new DateOnly(2027, 3, 8), 523, 123, 3, 63, "GOOD CONDITION", "36" },
                    { 257, "0.04", "", new DateOnly(2026, 2, 16), 523, 126, 2, 63, "GOOD CONDITION", "26" },
                    { 258, "0.17", "", new DateOnly(2025, 11, 8), 523, 95, 5, 63, "GOOD CONDITION", "45" },
                    { 259, "0.32", "", new DateOnly(2026, 9, 20), 523, 98, 10, 63, "GOOD CONDITION", "70" },
                    { 260, "0.03", "", new DateOnly(2026, 4, 9), 523, 102, 3, 63, "GOOD CONDITION", "27" },
                    { 261, "0.25", "", new DateOnly(2025, 12, 9), 524, 129, 10, 63, "GOOD CONDITION", "50" },
                    { 262, "0.25", "", new DateOnly(2025, 12, 11), 524, 129, 10, 63, "GOOD CONDITION", "50" },
                    { 263, "0.16", "", new DateOnly(2025, 12, 23), 524, 77, 5, 63, "GOOD CONDITION", "50" },
                    { 264, "0.79", "", new DateOnly(2025, 12, 5), 524, 111, 5, 63, "GOOD CONDITION", "50" },
                    { 265, "0.02", "", new DateOnly(2029, 3, 19), 524, 117, 5, 63, "GOOD CONDITION", "10" },
                    { 266, "0.16", "", new DateOnly(2025, 12, 15), 524, 76, 5, 63, "GOOD CONDITION", "50" },
                    { 267, "0.21", "", new DateOnly(2025, 12, 30), 524, 109, 5, 63, "GOOD CONDITION", "40" },
                    { 268, "0.09", "", new DateOnly(2026, 3, 31), 524, 115, 3, 63, "GOOD CONDITION", "27" },
                    { 269, "0.03", "", new DateOnly(2026, 6, 19), 524, 113, 2, 63, "GOOD CONDITION", "8" },
                    { 270, "0.03", "", new DateOnly(2026, 9, 26), 524, 114, 3, 63, "GOOD CONDITION", "9" },
                    { 271, "0.65", "", new DateOnly(2026, 2, 27), 524, 108, 20, 63, "GOOD CONDITION", "320" },
                    { 272, "0.04", "", new DateOnly(2027, 2, 18), 525, 132, 2, 63, "GOOD CONDITION", "32" },
                    { 273, "0.02", "", new DateOnly(2025, 10, 3), 525, 122, 2, 63, "GOOD CONDITION", "13" },
                    { 274, "0.1", "", new DateOnly(2026, 8, 23), 525, 125, 5, 63, "GOOD CONDITION", "50" },
                    { 275, "0.05", "", new DateOnly(2026, 4, 15), 525, 103, 2, 63, "GOOD CONDITION", "16" },
                    { 276, "0.52", "", new DateOnly(2025, 10, 26), 525, 120, 10, 63, "GOOD CONDITION", "50" },
                    { 277, "0.25", "", new DateOnly(2025, 12, 28), 525, 130, 10, 63, "GOOD CONDITION", "50" },
                    { 278, "0.54", "", new DateOnly(2025, 10, 25), 525, 12, 10, 63, "GOOD CONDITION", "35" },
                    { 279, "0.54", "", new DateOnly(2025, 10, 22), 525, 112, 15, 63, "GOOD CONDITION", "120" },
                    { 280, "0.73", "", new DateOnly(2025, 6, 4), 530, 141, 15, 64, "GOOD CONDITION", "405" },
                    { 281, "0.15", "", new DateOnly(2025, 6, 4), 530, 150, 5, 64, "GOOD CONDITION", "15" },
                    { 282, "0.15", "", new DateOnly(2025, 6, 4), 530, 151, 5, 64, "GOOD CONDITION", "15" },
                    { 283, "0.05", "", new DateOnly(2027, 2, 6), 530, 145, 2, 64, "GOOD CONDITION", "14" },
                    { 284, "0.73", "", new DateOnly(2025, 6, 4), 531, 142, 15, 64, "GOOD CONDITION", "405" },
                    { 285, "0.03", "", new DateOnly(2025, 6, 4), 531, 147, 3, 64, "GOOD CONDITION", "42" },
                    { 286, "0.03", "", new DateOnly(2025, 6, 4), 531, 148, 3, 64, "GOOD CONDITION", "39" },
                    { 287, "0.05", "", new DateOnly(2025, 6, 4), 531, 146, 5, 64, "GOOD CONDITION", "25" },
                    { 288, "0.05", "", new DateOnly(2025, 6, 4), 531, 149, 5, 64, "GOOD CONDITION", "30" },
                    { 289, "0.73", "", new DateOnly(2025, 6, 4), 532, 143, 15, 64, "GOOD CONDITION", "405" },
                    { 290, "1.22", "", new DateOnly(2025, 6, 4), 533, 144, 25, 64, "GOOD CONDITION", "675" },
                    { 291, "1.65", "", new DateOnly(2026, 11, 12), 534, 152, 53, 65, "GOOD CONDITION", "1060" },
                    { 292, "1.06", "", new DateOnly(2026, 11, 12), 535, 152, 34, 65, "GOOD CONDITION", "680" },
                    { 293, "0.56", "", new DateOnly(2026, 11, 11), 535, 153, 18, 65, "GOOD CONDITION", "360" },
                    { 294, "1.62", "", new DateOnly(2026, 11, 11), 536, 153, 52, 65, "GOOD CONDITION", "1040" },
                    { 295, "0.73", "", new DateOnly(2027, 1, 29), 542, 165, 15, 66, "GOOD CONDITION", "90" },
                    { 296, "0.47", "", new DateOnly(2027, 4, 26), 542, 128, 10, 66, "GOOD CONDITION", "160" },
                    { 297, "0.14", "", new DateOnly(2026, 4, 26), 542, 103, 6, 66, "GOOD CONDITION", "48" },
                    { 298, "0.05", "", new DateOnly(2027, 5, 5), 542, 167, 3, 66, "GOOD CONDITION", "33" },
                    { 299, "0.03", "", new DateOnly(2025, 6, 4), 542, 171, 3, 66, "GOOD CONDITION", "37.5" },
                    { 300, "0.06", "", new DateOnly(2026, 4, 9), 542, 102, 5, 66, "GOOD CONDITION", "45" },
                    { 301, "0.12", "", new DateOnly(2026, 4, 13), 542, 158, 6, 66, "GOOD CONDITION", "36" },
                    { 302, "0.09", "", new DateOnly(2027, 3, 13), 542, 155, 4, 66, "GOOD CONDITION", "48" },
                    { 303, "0.04", "", new DateOnly(2027, 4, 3), 542, 168, 2, 66, "GOOD CONDITION", "24" },
                    { 304, "0.13", "", new DateOnly(2027, 5, 1), 542, 166, 5, 66, "GOOD CONDITION", "75" },
                    { 305, "0.06", "", new DateOnly(2025, 11, 25), 543, 134, 6, 66, "GOOD CONDITION", "12" },
                    { 306, "0.12", "", new DateOnly(2026, 1, 17), 543, 130, 5, 66, "GOOD CONDITION", "25" },
                    { 307, "0.12", "", new DateOnly(2026, 1, 18), 543, 131, 5, 66, "GOOD CONDITION", "25" },
                    { 308, "0.12", "", new DateOnly(2026, 1, 19), 543, 129, 5, 66, "GOOD CONDITION", "25" },
                    { 309, "0.04", "", new DateOnly(2026, 11, 9), 543, 169, 1, 66, "GOOD CONDITION", "14" },
                    { 310, "0.04", "", new DateOnly(2026, 10, 11), 543, 161, 1, 66, "GOOD CONDITION", "14" },
                    { 311, "0.04", "", new DateOnly(2026, 10, 24), 543, 154, 1, 66, "GOOD CONDITION", "14" },
                    { 312, "0.03", "", new DateOnly(2027, 2, 28), 543, 170, 1, 66, "GOOD CONDITION", "7" },
                    { 313, "0.05", "", new DateOnly(2027, 2, 6), 543, 160, 2, 66, "GOOD CONDITION", "14" },
                    { 314, "0.89", "", new DateOnly(2027, 2, 1), 544, 97, 35, 66, "GOOD CONDITION", "700" },
                    { 315, "0.36", "", new DateOnly(2025, 11, 21), 545, 159, 15, 66, "GOOD CONDITION", "285" },
                    { 316, "0.24", "", new DateOnly(2025, 10, 12), 545, 162, 10, 66, "GOOD CONDITION", "190" },
                    { 317, "0.24", "", new DateOnly(2025, 10, 19), 545, 156, 10, 66, "GOOD CONDITION", "190" },
                    { 318, "0.2", "", new DateOnly(2025, 9, 11), 546, 157, 10, 66, "GOOD CONDITION", "190" },
                    { 319, "0.3", "", new DateOnly(2025, 11, 11), 546, 164, 15, 66, "GOOD CONDITION", "180" },
                    { 320, "0.17", "", new DateOnly(2025, 10, 18), 546, 163, 15, 66, "GOOD CONDITION", "135" },
                    { 321, "0.27", "", new DateOnly(2025, 12, 17), 547, 174, 50, 67, "GOOD CONDITION", "100" },
                    { 322, "0.27", "", new DateOnly(2025, 12, 16), 547, 172, 50, 67, "GOOD CONDITION", "100" },
                    { 323, "0.27", "", new DateOnly(2025, 12, 18), 547, 175, 50, 67, "GOOD CONDITION", "100" },
                    { 324, "0.27", "", new DateOnly(2025, 12, 19), 547, 173, 50, 67, "GOOD CONDITION", "100" },
                    { 325, "0.09", "", new DateOnly(2027, 4, 28), 548, 176, 5, 68, "GOOD CONDITION", "100" },
                    { 326, "0.05", "", new DateOnly(2027, 5, 28), 548, 177, 3, 68, "GOOD CONDITION", "57" },
                    { 327, "0.01", "", new DateOnly(2027, 3, 16), 548, 178, 2, 68, "GOOD CONDITION", "8" },
                    { 328, "0.03", "", new DateOnly(2027, 6, 28), 548, 179, 2, 68, "GOOD CONDITION", "20" },
                    { 329, "0.04", "", new DateOnly(2027, 3, 2), 548, 181, 4, 68, "GOOD CONDITION", "12" },
                    { 330, "0.04", "", new DateOnly(2027, 5, 28), 548, 182, 3, 68, "GOOD CONDITION", "24" },
                    { 331, "0.01", "", new DateOnly(2027, 11, 26), 548, 183, 1, 68, "GOOD CONDITION", "2" },
                    { 332, "0.01", "", new DateOnly(2027, 2, 27), 548, 184, 1, 68, "GOOD CONDITION", "2" },
                    { 333, "0.01", "", new DateOnly(2027, 1, 21), 548, 185, 2, 68, "GOOD CONDITION", "2" },
                    { 334, "0.09", "", new DateOnly(2027, 4, 28), 548, 176, 5, 69, "GOOD CONDITION", "100" },
                    { 335, "0.05", "", new DateOnly(2027, 5, 28), 548, 177, 3, 69, "GOOD CONDITION", "57" },
                    { 336, "0.01", "", new DateOnly(2027, 3, 16), 548, 178, 2, 69, "GOOD CONDITION", "8" },
                    { 337, "0.03", "", new DateOnly(2027, 6, 28), 548, 179, 2, 69, "GOOD CONDITION", "20" },
                    { 338, "0.04", "", new DateOnly(2027, 3, 2), 548, 181, 4, 69, "GOOD CONDITION", "12" },
                    { 339, "0.04", "", new DateOnly(2027, 5, 28), 548, 182, 3, 69, "GOOD CONDITION", "24" },
                    { 340, "0.01", "", new DateOnly(2027, 11, 26), 548, 183, 1, 69, "GOOD CONDITION", "2" },
                    { 341, "0.01", "", new DateOnly(2027, 2, 27), 548, 184, 1, 69, "GOOD CONDITION", "2" },
                    { 342, "0.01", "", new DateOnly(2027, 1, 21), 548, 185, 2, 69, "GOOD CONDITION", "2" },
                    { 343, "0.51", "", new DateOnly(2026, 6, 5), 549, 186, 6, 70, "GOOD CONDITION", "18" },
                    { 344, "0.51", "", new DateOnly(2026, 6, 5), 549, 187, 6, 70, "GOOD CONDITION", "18" },
                    { 345, "0.42", "", new DateOnly(2027, 11, 24), 549, 188, 5, 70, "GOOD CONDITION", "15" },
                    { 346, "0.18", "", new DateOnly(2026, 11, 28), 549, 189, 8, 70, "GOOD CONDITION", "16" },
                    { 347, "0.13", "", new DateOnly(2026, 11, 28), 549, 190, 6, 70, "GOOD CONDITION", "12" },
                    { 348, "0.13", "", new DateOnly(2026, 11, 28), 549, 191, 6, 70, "GOOD CONDITION", "12" },
                    { 349, "0.13", "", new DateOnly(2026, 11, 28), 549, 192, 5, 70, "GOOD CONDITION", "20" },
                    { 350, "0.13", "", new DateOnly(2026, 11, 11), 549, 193, 5, 70, "GOOD CONDITION", "20" },
                    { 351, "0.13", "", new DateOnly(2026, 11, 28), 549, 194, 5, 70, "GOOD CONDITION", "20" },
                    { 352, "0.02", "", new DateOnly(2026, 6, 5), 549, 204, 1, 70, "GOOD CONDITION", "3" },
                    { 353, "0.1", "", new DateOnly(2025, 12, 5), 550, 195, 8, 70, "GOOD CONDITION", "16" },
                    { 354, "0.1", "", new DateOnly(2025, 12, 5), 550, 196, 8, 70, "GOOD CONDITION", "16" },
                    { 355, "0.1", "", new DateOnly(2025, 12, 5), 550, 197, 8, 70, "GOOD CONDITION", "16" },
                    { 356, "0.1", "", new DateOnly(2025, 12, 5), 550, 198, 8, 70, "GOOD CONDITION", "16" },
                    { 357, "0.06", "", new DateOnly(2025, 12, 5), 550, 199, 5, 70, "GOOD CONDITION", "10" },
                    { 358, "0.15", "", new DateOnly(2026, 6, 5), 550, 201, 3, 70, "GOOD CONDITION", "9" },
                    { 359, "0.15", "", new DateOnly(2026, 6, 5), 550, 202, 3, 70, "GOOD CONDITION", "9" },
                    { 360, "0.1", "", new DateOnly(2026, 6, 5), 550, 203, 2, 70, "GOOD CONDITION", "6" },
                    { 361, "0.59", "", new DateOnly(2026, 6, 5), 550, 205, 6, 70, "GOOD CONDITION", "18" },
                    { 362, "0.36", "", new DateOnly(2026, 6, 11), 550, 206, 6, 70, "GOOD CONDITION", "24" },
                    { 363, "0.61", "", new DateOnly(2025, 12, 6), 551, 208, 8, 71, "GOOD CONDITION", "24" },
                    { 364, "0.46", "", new DateOnly(2025, 12, 6), 551, 209, 6, 71, "GOOD CONDITION", "0" },
                    { 365, "0.57", "", new DateOnly(2025, 12, 6), 551, 210, 8, 71, "GOOD CONDITION", "24" },
                    { 366, "0.57", "", new DateOnly(2025, 12, 6), 551, 211, 8, 71, "GOOD CONDITION", "24" },
                    { 367, "0.32", "", new DateOnly(2025, 12, 6), 551, 212, 6, 71, "GOOD CONDITION", "18" },
                    { 368, "0.42", "", new DateOnly(2025, 12, 18), 551, 213, 8, 71, "GOOD CONDITION", "24" },
                    { 369, "0.42", "", new DateOnly(2025, 12, 24), 551, 214, 8, 71, "GOOD CONDITION", "24" },
                    { 370, "0.16", "", new DateOnly(2025, 12, 30), 552, 215, 3, 71, "GOOD CONDITION", "9" },
                    { 371, "0.16", "", new DateOnly(2025, 12, 25), 552, 216, 3, 71, "GOOD CONDITION", "9" },
                    { 372, "0.16", "", new DateOnly(2025, 11, 13), 552, 217, 3, 71, "GOOD CONDITION", "9" },
                    { 373, "0.4", "", new DateOnly(2025, 11, 21), 552, 218, 8, 71, "GOOD CONDITION", "24" },
                    { 374, "0.4", "", new DateOnly(2025, 11, 25), 552, 219, 8, 71, "GOOD CONDITION", "24" },
                    { 375, "0.23", "", new DateOnly(2025, 11, 28), 552, 221, 3, 71, "GOOD CONDITION", "9" },
                    { 376, "0.23", "", new DateOnly(2025, 12, 19), 552, 222, 3, 71, "GOOD CONDITION", "9" },
                    { 377, "0.46", "", new DateOnly(2025, 12, 26), 552, 224, 6, 71, "GOOD CONDITION", "36" },
                    { 378, "0.13", "", new DateOnly(2025, 11, 28), 553, 226, 6, 72, "GOOD CONDITION", "12" },
                    { 379, "0.18", "", new DateOnly(2025, 11, 28), 553, 227, 8, 72, "GOOD CONDITION", "16" },
                    { 380, "0.13", "", new DateOnly(2025, 11, 28), 553, 228, 6, 72, "GOOD CONDITION", "12" },
                    { 381, "0.12", "", new DateOnly(2025, 12, 5), 553, 230, 6, 72, "GOOD CONDITION", "24" },
                    { 382, "0.12", "", new DateOnly(2025, 11, 28), 553, 231, 6, 72, "GOOD CONDITION", "24" },
                    { 383, "0.1", "", new DateOnly(2025, 12, 6), 553, 229, 4, 72, "GOOD CONDITION", "16" },
                    { 384, "0.1", "", new DateOnly(2027, 2, 1), 554, 233, 5, 73, "GOOD CONDITION", "60" },
                    { 385, "0.1", "", new DateOnly(2026, 2, 1), 554, 234, 5, 73, "GOOD CONDITION", "60" },
                    { 386, "0.06", "", new DateOnly(2026, 1, 31), 554, 235, 3, 73, "GOOD CONDITION", "48" },
                    { 387, "0.1", "", new DateOnly(2026, 1, 31), 554, 236, 5, 73, "GOOD CONDITION", "80" },
                    { 388, "0.12", "", new DateOnly(2026, 2, 2), 554, 237, 6, 73, "GOOD CONDITION", "96" },
                    { 389, "0.06", "", new DateOnly(2026, 2, 2), 554, 238, 3, 73, "GOOD CONDITION", "48" },
                    { 390, "0.1", "", new DateOnly(2026, 1, 30), 554, 240, 5, 73, "GOOD CONDITION", "80" },
                    { 391, "0.2", "", new DateOnly(2026, 1, 29), 554, 242, 10, 73, "GOOD CONDITION", "160" },
                    { 392, "0.04", "", new DateOnly(2026, 2, 17), 554, 243, 3, 73, "GOOD CONDITION", "30" },
                    { 393, "0.07", "", new DateOnly(2026, 2, 25), 554, 244, 5, 73, "GOOD CONDITION", "50" },
                    { 394, "0.04", "", new DateOnly(2026, 3, 3), 554, 245, 3, 73, "GOOD CONDITION", "30" },
                    { 395, "0.3", "", new DateOnly(2026, 2, 17), 554, 246, 15, 73, "GOOD CONDITION", "240" },
                    { 396, "0.07", "", new DateOnly(2026, 2, 3), 554, 247, 5, 73, "GOOD CONDITION", "50" },
                    { 397, "0.04", "", new DateOnly(2026, 2, 3), 554, 248, 3, 73, "GOOD CONDITION", "30" },
                    { 398, "0.07", "", new DateOnly(2026, 2, 2), 554, 249, 5, 73, "GOOD CONDITION", "50" },
                    { 399, "0.14", "", new DateOnly(2026, 3, 3), 554, 250, 10, 73, "GOOD CONDITION", "140" },
                    { 400, "0.37", "", new DateOnly(2025, 9, 11), 555, 251, 5, 74, "GOOD CONDITION", "40" },
                    { 401, "0.37", "", new DateOnly(2025, 9, 11), 555, 252, 5, 74, "GOOD CONDITION", "40" },
                    { 402, "0.37", "", new DateOnly(2025, 9, 11), 555, 253, 5, 74, "GOOD CONDITION", "40" },
                    { 403, "0.04", "", new DateOnly(2025, 10, 31), 555, 255, 1, 74, "GOOD CONDITION", "16" },
                    { 404, "0.04", "", new DateOnly(2025, 11, 1), 555, 256, 1, 74, "GOOD CONDITION", "16" },
                    { 405, "0.16", "", new DateOnly(2025, 11, 18), 555, 260, 5, 74, "GOOD CONDITION", "40" },
                    { 406, "0.16", "", new DateOnly(2025, 12, 19), 555, 259, 5, 74, "GOOD CONDITION", "40" },
                    { 407, "0.16", "", new DateOnly(2025, 12, 20), 555, 258, 5, 74, "GOOD CONDITION", "40" },
                    { 408, "0.11", "", new DateOnly(2025, 12, 31), 555, 257, 2, 74, "GOOD CONDITION", "20" },
                    { 409, "0.84", "", new DateOnly(2026, 1, 25), 556, 261, 50, 75, "GOOD CONDITION", "525" },
                    { 410, "0.47", "", new DateOnly(2026, 1, 25), 557, 261, 28, 75, "GOOD CONDITION", "294" },
                    { 411, "0.84", "", new DateOnly(2026, 1, 7), 558, 262, 50, 75, "GOOD CONDITION", "525" },
                    { 412, "0.85", "", new DateOnly(2026, 1, 20), 559, 263, 51, 75, "GOOD CONDITION", "535.5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bins_BayId",
                table: "Bins",
                column: "BayId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_BinNamesId",
                table: "Bins",
                column: "BinNamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_LevelId",
                table: "Bins",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_RackId",
                table: "Bins",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInBin_CheckInId",
                table: "CheckInBin",
                column: "CheckInId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInReceivedProduct_ReceivedProductId",
                table: "CheckInReceivedProduct",
                column: "ReceivedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_PalletId",
                table: "CheckIns",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualPickings_BinId",
                table: "ManualPickings",
                column: "BinId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualPickings_CheckInId",
                table: "ManualPickings",
                column: "CheckInId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualPickings_WarehouseId",
                table: "ManualPickings",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_WarehouseId",
                table: "Pallets",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PickedProducts_ManualPickingId",
                table: "PickedProducts",
                column: "ManualPickingId");

            migrationBuilder.CreateIndex(
                name: "IX_PickedProducts_ReceivedProductId",
                table: "PickedProducts",
                column: "ReceivedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RackFloorMapObjects_RackId",
                table: "RackFloorMapObjects",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_BayId",
                table: "Racks",
                column: "BayId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_LevelId",
                table: "Racks",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_WarehouseId",
                table: "Racks",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_PalletId",
                table: "ReceivedProducts",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_ProductId",
                table: "ReceivedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedProducts_ReceivingId",
                table: "ReceivedProducts",
                column: "ReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_WarehouseId",
                table: "Receivings",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckInBin");

            migrationBuilder.DropTable(
                name: "CheckInReceivedProduct");

            migrationBuilder.DropTable(
                name: "PickedProducts");

            migrationBuilder.DropTable(
                name: "RackFloorMapObjects");

            migrationBuilder.DropTable(
                name: "ManualPickings");

            migrationBuilder.DropTable(
                name: "ReceivedProducts");

            migrationBuilder.DropTable(
                name: "Bins");

            migrationBuilder.DropTable(
                name: "CheckIns");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Receivings");

            migrationBuilder.DropTable(
                name: "BinNames");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Bays");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
