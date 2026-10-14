using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfileImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TraceId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserRole = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DetailsJson = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                })
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfPackage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Measurement = table.Column<string>(type: "longtext", precision: 18, scale: 4, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ReportJobs_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomingDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncomingId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    OriginalFileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomingDocuments_Incomings_IncomingId",
                        column: x => x.IncomingId,
                        principalTable: "Incomings",
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CBM = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Supplier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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

            migrationBuilder.CreateTable(
                name: "Receivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncomingId = table.Column<int>(type: "int", nullable: true),
                    Series = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransportCompany = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reference = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlateNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DriverName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientRepresentative = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CheckerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReceived = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Shipper = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Consignee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivings_Incomings_IncomingId",
                        column: x => x.IncomingId,
                        principalTable: "Incomings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivings_Warehouses_WarehouseId",
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
                name: "Bins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    RackId = table.Column<int>(type: "int", nullable: true),
                    BayId = table.Column<int>(type: "int", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true),
                    BinNamesId = table.Column<int>(type: "int", nullable: false),
                    BinHashCode = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StandaloneLocationId = table.Column<int>(type: "int", nullable: true),
                    Location3DId = table.Column<int>(type: "int", nullable: true),
                    RelativeX = table.Column<float>(type: "float", nullable: true),
                    RelativeY = table.Column<float>(type: "float", nullable: true),
                    RelativeZ = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bins_Bays_BayId",
                        column: x => x.BayId,
                        principalTable: "Bays",
                        principalColumn: "Id");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bins_Location3D_Location3DId",
                        column: x => x.Location3DId,
                        principalTable: "Location3D",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bins_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bins_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
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
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ExpectedQuantity = table.Column<int>(type: "int", nullable: true),
                    ExpectedCBM = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ExpectedTotalWeight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ExpectedExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedProductName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContainerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LotNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfPackage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PalletId = table.Column<int>(type: "int", nullable: true),
                    IncomingProductId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CBM = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Supplier = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedProducts_IncomingProduct_IncomingProductId",
                        column: x => x.IncomingProductId,
                        principalTable: "IncomingProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ReceivingException",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceivedProductId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryReceiptReference = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingException", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingException_ReceivedProducts_ReceivedProductId",
                        column: x => x.ReceivedProductId,
                        principalTable: "ReceivedProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransferLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransferType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: true),
                    ReceivedProductId = table.Column<int>(type: "int", nullable: true),
                    FromBinId = table.Column<int>(type: "int", nullable: false),
                    ToBinId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferLogs_Bins_FromBinId",
                        column: x => x.FromBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferLogs_Bins_ToBinId",
                        column: x => x.ToBinId,
                        principalTable: "Bins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferLogs_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransferLogs_ReceivedProducts_ReceivedProductId",
                        column: x => x.ReceivedProductId,
                        principalTable: "ReceivedProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransferLogs_Warehouses_WarehouseId",
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

            migrationBuilder.CreateTable(
                name: "ExceptionPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceivingExceptionId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UploadedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionPhoto_ReceivingException_ReceivingExceptionId",
                        column: x => x.ReceivingExceptionId,
                        principalTable: "ReceivingException",
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

            migrationBuilder.CreateTable(
                name: "LoadingExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoadingPlanId = table.Column<int>(type: "int", nullable: false),
                    PalletId = table.Column<int>(type: "int", nullable: true),
                    LoadingPlanLineId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_LoadingExceptions_LoadingPlanLines_LoadingPlanLineId",
                        column: x => x.LoadingPlanLineId,
                        principalTable: "LoadingPlanLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                columns: new[] { "Id", "Code", "DateAdded", "Measurement", "Name", "TypeOfPackage", "Weight" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2397), "47 X 21 X 35", "Pillows Ube-Filled Crackers HA-24gX100", "Carton", 3.5m },
                    { 2, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2398), "47 X 21 X 35", "Pillows Chocolate Crackers HA-24gX100", "Carton", 3.5m },
                    { 3, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2399), "56 X 24 X 40", "Bread Pan Toasted Garlic 24gX100pcs", "Carton", 3.5m },
                    { 4, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2400), "56 X 24 X 40", "Bread Pan Cheese & Onion 24gX100pcs", "Carton", 3.5m },
                    { 5, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2401), "56 X 24 X 40", "Bread Pan Cheese & Onion 24gX100pcs", "Carton", 3.5m },
                    { 6, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2401), "56 X 24 X 40", "Bread Pan Buttered Toast 24gX100pcs", "Carton", 3.5m },
                    { 7, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2402), "56 X 24 X 40", "Miggos Sweet Corn Tortilla Chips L28g", "Carton", 3.5m },
                    { 8, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2403), "56 X 24 X 40", "O-puff Chocolate Cream Filled OWA 3.5g x 24 x 30", "Carton", 3.5m },
                    { 9, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2405), "56 X 24 X 40", "O-puff Mango Filled OWA 3.5g x 24 x 30", "Carton", 3.5m },
                    { 10, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2405), "56 X 24 X 40", "O-puff Ube Marshmallow OWA 3.5g x 24 x 30", "Carton", 3.5m },
                    { 11, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2406), "56 X 24 X 40", "Onion Rings L-16gx100", "Carton", 3.5m },
                    { 12, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2438), "56 X 24 X 40", "Oishi Prawn Cracker L-24gx100", "Carton", 3.5m },
                    { 13, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2438), "56 X 24 X 40", "Oishi Potato Fries BBQ LB-21gx100", "Carton", 3.5m },
                    { 14, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2439), "56 X 24 X 40", "Oishi Potato Fries Cheese LB-21gx100", "Carton", 3.5m },
                    { 15, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2440), "56 X 24 X 40", "Potato Fries Tomato Ketchup LB-21gx100", "Carton", 3.5m },
                    { 16, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2440), "56 X 24 X 40", "Oishi Fishda Fish Kropeck LF-22gx100", "Carton", 3.5m },
                    { 17, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2441), "56 X 24 X 40", "Fish Cracker L-24gx100", "Carton", 3.5m },
                    { 18, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2442), "56 X 24 X 40", "Oishi Sundays Mango Juice 35gx6x20", "Carton", 3.5m },
                    { 19, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2442), "56 X 24 X 40", "Oishi Sundays Orange Juice 35gx6x20", "Carton", 3.5m },
                    { 20, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2443), "56 X 24 X 40", "Oishi Sundays Orange-Mango Blends 35gx6x20", "Carton", 3.5m },
                    { 21, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2444), "56 X 24 X 40", "POTATO FRIES BBQ 50gX50", "Carton", 3.5m },
                    { 22, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2445), "56 X 24 X 40", "POTATO FRIES CHEESE 50gX50", "Carton", 3.5m },
                    { 23, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2447), "56 X 24 X 40", "POTATO FRIES KETCHUP FLAVOR 50gX50", "Carton", 3.5m },
                    { 24, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2448), "56 X 24 X 40", "OISHI PILLOWS CHOCOLATE CRACKERS 150gX20", "Carton", 3.5m },
                    { 25, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2449), "56 X 24 X 40", "MIGGOS NACHO CHEESE TORTILLA CHIPS L28gX100", "Carton", 3.5m },
                    { 26, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2450), "56 X 24 X 40", "SELECTA MOO MILK", "Carton", 3.5m },
                    { 27, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2450), "56 X 24 X 40", "SKYFLAKES", "Carton", 3.5m },
                    { 28, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2454), "56 X 24 X 40", "ISDALICIOUS FISH CRACKER", "Carton", 3.5m },
                    { 29, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2455), "56 X 24 X 40", "RICE & CORN CHEESE", "Carton", 3.5m },
                    { 30, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2458), "71 X 42 X 13", "CHEESE RING 60gX25pcs", "Sack", 2m },
                    { 31, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2459), "71 X 42 X 13", "CHEESE BALL 60gX25pcs", "Sack", 2m },
                    { 32, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2459), "71 X 42 X 13", "GOLDEN SWEET CORN 60gX25pcs", "Sack", 2m },
                    { 33, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2460), "60 X 46 X 46", "FAN MOTOR 24V 10' FAN BASE 10' FAN BLADE", "PCS", 0m },
                    { 34, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2461), "62 X 28 X 16", "CIRCUIT BOARD TS26F CONTROLLER NEW SENSORS CPR WITH O RING FUSE DETECTION BOARD", "PCS", 0m },
                    { 35, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2461), "39 X 32 X 21", "COPPER HOSE BENDABLE", "PCS", 0m },
                    { 36, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2463), "40 X 29 X 20", "RECEIVER DRIER 15NF RECEIVER DRIER 20NF", "PCS", 0m },
                    { 37, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2464), "100 X 6 X 4", "CURTAIN ROD", "PCS", 0m },
                    { 38, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2464), "38 X 38 X 23", "PLASTIC CURTAIN", "PCS", 0m },
                    { 39, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2466), "38 X 38 X 23", "ELIMINATOR FILTER DRIER", "PCS", 0m },
                    { 40, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2470), "40 X 29 X 20", "THERMOSTATIC EXPANSION VALVE 15NF THERMOSTATIC EXPANSION VALVE 20NF", "PCS", 0m },
                    { 41, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2470), "27 X 22 X 19", "TANG PWD JCE STRAWBERRY 144/19G", "Carton", 3m },
                    { 42, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2471), "27 X 22 X 19", "TANG PWD JCE MANGO 144/19G", "Carton", 3m },
                    { 43, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2472), "27 X 22 X 19", "TANG PWD JCE I.TEA LEMON 144/19G", "Carton", 3m },
                    { 44, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2472), "27 X 22 X 19", "TANG PWD JCE GRAPE 144/19G", "Carton", 3m },
                    { 45, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2473), "27 X 22 X 19", "TANG PWD JCE ORANGE 12/12/19G", "Carton", 3m },
                    { 46, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2473), "27 X 22 X 19", "TANG PWD JCE FOUR SEASON 144/19G", "Carton", 3m },
                    { 47, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2474), "27 X 22 X 19", "TANG PWD JCE FOUR SEASON 144/19G", "Carton", 3m },
                    { 48, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2475), "27 X 40 X 63", "OISHI FISH CRACKERS UA 90gX30", "Sack", 3m },
                    { 49, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2477), "29 X 49 X 66", "Miggos Sweet Corn Tortilla Chips UA 105gX30", "Sack", 3.5m },
                    { 50, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2477), "60.5 X 43 X 17.5", "DL-2000A DC12V WALL MOUNTED ELECTRIC AIR CONDITIONER", "Carton", 7m },
                    { 51, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2478), "73.5 X 55 X 32.5", "DL-2000F1 DC12V WALL MOUNTED AIR CONDITIONER", "Carton", 25m },
                    { 52, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2478), "61 X 42 X 27", "DL-2600A1 DC24V WALL MOUNTED ELECTRIC AIR CONDITIONER", "Carton", 6m },
                    { 53, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2480), "73.5 X 55 X 32.5", "DL-2600F DC24V WALL MOUNTED AIR CONDITIONER", "Carton", 24m },
                    { 54, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2480), "78 X 50 X 32", "DL-2600FT-BY DC24V WALL MOUNTED AIR CONDITIONER", "Carton", 25m },
                    { 55, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2481), "96 X 80 X 40", "DL-1800 DC12V ROOF AIR CONDITIONER", "Carton", 25m },
                    { 56, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2482), "96 X 80 X 40", "DL-1800BY DC24V ROOF AIR CONDITIONER", "Carton", 25m },
                    { 57, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2482), "96 X 80 X 40", "DL-1800-12V ROOF AIR CONDITIONER", "Carton", 25m },
                    { 58, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2483), "41 X 23 X 17", "Zesto Big 250 Grapes", "Carton", 10.5m },
                    { 59, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2483), "31 X 37 X 21", "KOPIKO BROWN COFFEE POUCH 24x1024x10x27.5G", "Carton", 0m },
                    { 60, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2484), "31 X 37 X 21", "KOPIKO BROWN COFFEE POUCH 24x1024x10x27.5G", "Carton", 7.5m },
                    { 61, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2485), "25 X 36 X 28", "KOPIKO BLANCA POUCH 24X10X30G", "Carton", 9m },
                    { 62, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2485), "24 X 43 X 28", "KOPIKO BLACK 3IN1 POUCH 24X1024X 10 X 30G", "Carton", 8m },
                    { 63, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2490), "30 X 50 X 20", "JUMBO PUSH POP 24 X 12 X 30G", "Carton", 14.5m },
                    { 64, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2490), "17 X 52 X 26", "PUSH POP LOLLIPOP 20 X 20 X 14G", "Carton", 11.5m },
                    { 65, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2491), "21 X 24 X 19", "KOJIE SL CLASSIC SOAP 135G X 24 X 20", "Carton", 7m },
                    { 66, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2491), "18 X 16 X 32", "AJI CRISPY FRY ORIG 24/238G", "Carton", 1m },
                    { 67, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2492), "18 X 16 X 32", "MODESS BODY ADAPT LONGS UT 24/4S", "Carton", 1m },
                    { 68, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2493), "38 X 18 X 37", "MODESS C.SFT LONG W 24/8'S", "Carton", 2m },
                    { 69, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2493), "35 X 18 X 27", "DM PINEAPPLE SLICES 24/432G", "Carton", 12.5m },
                    { 70, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2494), "24 X 18 X 29", "MODESS ALL NIGHT W 24/4'S", "Carton", 1.5m },
                    { 71, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2495), "48 X 31 X 24", "MODESS C.SFT REG MAXI W 12/32/1S", "Carton", 3m },
                    { 72, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2495), "27 X 22 X 19", "TANG PWD JCE LYCHEE 144/19G", "Carton", 3m },
                    { 73, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2496), "17 X 48 X 32", "FIESTA FRT COCKTL 6/3033G", "Carton", 20.5m },
                    { 74, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2496), "27 X 22 X 19", "TANG PWD JCE APPLE 144/19G", "Carton", 3m },
                    { 75, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2497), "27 X 22 X 19", "TANG PWD JCE ORANGE-MANGO 144/19G", "Carton", 3m },
                    { 76, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2499), "19 X 49 X 34", "SKYFLAKES CRCKR SWCH TSOKOLATE 30/10", "Carton", 10m },
                    { 77, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2500), "19 X 49 X 34", "SKYFLAKES CRCKR SWCH CONDENSADA 30/10", "Carton", 10m },
                    { 78, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2500), "33 X 13 X 17", "SELECTA MOO MILK CHOCO 24/245ML", "Carton", 7m },
                    { 79, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2501), "33 X 22 X 27", "SNOWTIME ICE POPS 15/8/90ML", "Carton", 11.5m },
                    { 80, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2502), "37 X 70 X 40", "PARTY PACK SUPER CRUNCH CHEESE RINGS 370G X 12S", "Carton", 5.5m },
                    { 81, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2502), "44 X 30 X 39", "MUNCHER KID'S CHOICE GREEN PEAS CHICKEN", "Carton", 13.5m },
                    { 82, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2503), "40 X 19 X 20", "Muncher G. Peas Orig 70gX10packsX10pcs", "Carton", 3m },
                    { 83, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2503), "72 X 40 X 17", "Super Q Golden Bihon 15x1KG", "Carton", 15m },
                    { 84, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2504), "21 X 10 X 15", "ZEST-O ORANGE 10X200ML", "Carton", 2m },
                    { 85, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2505), "21 X 10 X 15", "ZEST-O MANGO 10X200ML", "Carton", 2m },
                    { 86, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2505), "84 X 36 X 13", "Cheese Ring Snack Cheese 25x60g", "Carton", 2m },
                    { 87, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2506), "78 X 33 X 13", "Snacku Vegetable Snack 30/50G", "Carton", 2m },
                    { 88, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2506), "37 X 34 X 21", "Maya Cornstarch 12x1kg", "Carton", 12.5m },
                    { 89, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2507), "44 X 30 X 21", "American Gumball 24x40", "Carton", 4m },
                    { 90, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2509), "86 X 51 X 39", "Ordinary Mattress 4x36x75", "Carton", 3m },
                    { 91, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2510), "164 X 61 X 33", "Ordinary Mattress 4x54x75", "Carton", 2.5m },
                    { 92, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2511), "54 X 98 X 77", "Jumbo Rack 4 layer", "Carton", 11.5m },
                    { 93, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2511), "30 X 23 X 26", "1339 DM KTCHP TOM(ORG) 12/567G", "Carton", 11m },
                    { 94, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2512), "30 X 23 X 26", "1339 DM KTCHP TOM(ORG) 12/567G", "Carton", 11m },
                    { 95, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2513), "41 X 32 X 26", "30308 MAXX CANDY DALANDAN 40/50S", "Carton", 9m },
                    { 96, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2513), "41 X 32 X 26", "30308 MAXX CANDY CHERRY 40/50S", "Carton", 9m },
                    { 97, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2514), "48 X 31 X 17", "TODAY'S MIXED FRUIT 6/2.9L", "Carton", 20m },
                    { 98, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2514), "43 X 29 X 26", "965 COL.MONAMI STRAW CRM 40/50'S", "Carton", 7m },
                    { 99, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2515), "37 X 15 X 28", "ABSOLUTE DISTILLED WATER 3/5000ML", "Carton", 15m },
                    { 100, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2516), "44 X 13 X 33", "ABSOLUTE DISTILLED WATER 3/6000ML", "Carton", 19m },
                    { 101, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2516), "29 X 24 X 30", "ABSOLUTE DISTILLED WATER 4/4000ML", "Carton", 16m },
                    { 102, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2517), "30 X 22 X 17", "AJINAMOTO GINISA MIX 48/100G", "Carton", 9m },
                    { 103, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2519), "40 X 25 X 24", "AJINAMOTO GINISA MIX 54/16/8G", "Carton", 8m },
                    { 104, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2519), "39 X 28 X 15", "AJINAMOTO VETSIN BLUE 48/250G", "Carton", 13m },
                    { 105, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2520), "35 X 22 X 18", "AJINAMOTO VETSIN RED 8X12X100G", "Carton", 10m },
                    { 106, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2521), "77 X 31 X 13", "CHEESE RING SNACK CHEESE 30/25G", "Carton", 1m },
                    { 107, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2521), "29 X 30 X 32", "DATU PUTI VINEGAR PCON 4/1GAL", "Carton", 16m },
                    { 108, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2522), "44 X 24 X 31", "DATU PUTI VINEGAR 8/1.893", "Carton", 16m },
                    { 109, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2522), "53 X 40 X 20", "FIBISCO COOKIES CHOCO CHIP 36/200G", "Carton", 8m },
                    { 110, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2523), "53 X 40 X 20", "FIBISCO COOKIES CHOCO CHIP 36/200G", "Carton", 8m },
                    { 111, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2523), "51 X 38 X 82", "FITA CRACKER SINGLES 20/15/30G", "Carton", 10m },
                    { 112, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2524), "48 X 24 X 31", "HAPPY TIME BISCUIT ASSORTMENT 4/1.5K", "Carton", 8m },
                    { 113, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2525), "25 X 25 X 20", "KNR MIX SNGNG ORIG 12/12/22G", "Carton", 4m },
                    { 114, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2525), "34 X 14 X 20", "KNR SOUP CRAB & CORN 72/37G", "Carton", 3m },
                    { 115, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2526), "29 X 30 X 35", "MAGGI MAGIC SARAP SEASONING 60/16/8G", "Carton", 9m },
                    { 116, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2528), "29 X 30 X 35", "MAGGI MAGIC SARAP SEASONING 60/16/8G", "Carton", 9m },
                    { 117, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2528), "18 X 14 X 12", "MCCORMICK BLACK PEPPER GRND 12/35G", "Carton", 2m },
                    { 118, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2529), "55 X 41 X 19", "OISHI CHEESE CLUBS 100X23G", "Carton", 3m },
                    { 119, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2530), "57 X 24 X 38", "OISHI PILLOWS CHOCO 100/38G", "Carton", 5m },
                    { 120, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2530), "57 X 24 X 38", "OISHI PILLOWS UBE 100/38G", "Carton", 5m },
                    { 121, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2531), "30 X 18 X 26", "OREO SND.CKIE CHOCO 12/9/27G", "Carton", 4m },
                    { 122, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2531), "41 X 14 X 17", "QUEEN BAKING SODA 48/125G", "Carton", 6.5m },
                    { 123, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2532), "41 X 31 X 22", "WHITE KING FIESTA ELBOW MAC 12/1KG", "Carton", 12m },
                    { 124, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2533), "41 X 31 X 22", "WHITE KING FIESTA ELBOW MAC 12/1KG", "Carton", 12m },
                    { 125, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2533), "40 X 26 X 19", "VIVA CARAMEL CANDY 20/100'S", "Carton", 10m },
                    { 126, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2565), "37 X 25 X 21", "UFC BANANA CATSUP 24/320G", "Carton", 13m },
                    { 127, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2566), "44 X 18 X 69", "SUPER Q GOLDEN BIHON 60/227G", "Carton", 14m },
                    { 128, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2567), "69 X 38 X 18", "SUPER Q GOLDEN BIHON 30/500 G", "Carton", 16m },
                    { 129, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2567), "42 X 33 X 18", "STIK-O STRAW WATER JR 12/380G", "Carton", 5m },
                    { 130, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2570), "42 X 33 X 18", "STIK-O UBE WATER JR 12/380G", "Carton", 5m },
                    { 131, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2570), "42 X 33 X 18", "STIK-O CHOCO WATER JR 12/380G", "Carton", 5m },
                    { 132, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2571), "27 X 26 X 29", "ROYAL SPAGHETTI 18/900G", "Carton", 16m },
                    { 133, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2571), "50 X 37 X 28", "SKYFLAKES REG 30/10/25G", "Carton", 9m },
                    { 134, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2572), "31 X 20 X 17", "STIK-O CHOCO WAFER MINI 30/60G", "Carton", 2m },
                    { 135, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2572), "43 X 18 X 54", "OISHI PRAWN CRACKER 100/24G", "Carton", 3m },
                    { 136, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2573), "68 X 37 X 28", "OISHI PRAWN CRACKER 30/95G", "Carton", 3m },
                    { 137, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2574), "56 X 35 X 40", "OISHI PRAWN CRACKER 50/60G", "Carton", 2m },
                    { 138, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2574), "31 X 20 X 17", "SNACKU VEGETABLE SNACK 25/60G", "Carton", 1m },
                    { 139, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2575), "73 X 33 X 13", "SWEET CORN SNACK 25/60G", "Carton", 1m },
                    { 140, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2575), "31 X 13 X 70", "SWEET CORN SNACK 30/25", "Carton", 1m },
                    { 141, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2576), "52 X 36 X 26", "ZONROX BLEACH FRSH SCNT 24/1000ML", "Carton", 27m },
                    { 142, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2576), "52 X 36 X 26", "ZONROX BLEACH ORIGINAL 24/1000ML", "Carton", 27m },
                    { 143, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2579), "52 X 36 X 26", "ZONROX BLEACH FLORAL 24/1000ML", "Carton", 27m },
                    { 144, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2579), "52 X 36 X 26", "ZONROX BLEACH COLORSAFE 24/900ML", "Carton", 27m },
                    { 145, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2580), "32 X 26 X 32", "MENTOS CANDY TROPICAL MIX 40/50", "Carton", 7m },
                    { 146, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2580), "29 X 15 X 23", "KJSN SOAP SKIN LGHTNNG 24/2/135G", "Carton", 5m },
                    { 147, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2581), "34 X 30 X 11", "TIDE BAR NAT FRSH 36/380G", "Carton", 14m },
                    { 148, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2582), "31 X 22 X 15", "SURF BAR W/FBCN BLOSFRSH", "Carton", 13m },
                    { 149, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2582), "22 X 19 X 24", "KJSN SOAP SKIN LGHTNNG 48/2/65G", "Carton", 6m },
                    { 150, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2583), "36 X 33 X 25", "CHARMEE S.NPKN A.FLW D.NET NW 36X8", "Carton", 3m },
                    { 151, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2584), "36 X 33 X 25", "CHARMEE S.NPKN A.FLW D.NET W 36X8", "Carton", 3m },
                    { 152, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2584), "39 X 19 X 42", "NATURE SPRING 10L PURE", "Carton", 20m },
                    { 153, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2585), "39 X 19 X 42", "NATURE SPRING 10L DISTILLED", "Carton", 20m },
                    { 154, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2586), "50 X 41 X 19", "KENDI MINT CANDY 60/50", "Carton", 14m },
                    { 155, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2586), "43 X 20 X 25", "AJI CRISPY FRY ORIGINAL 13/14/62", "Carton", 12m },
                    { 156, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2587), "32 X 22 X 34", "MIRINDA ORANGE PET BOTTLE 12/1.5L", "Carton", 19m },
                    { 157, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2589), "35 X 26 X 22", "108080 SPRITE REG PET BOT 12/1.5L", "Carton", 19m },
                    { 158, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2590), "46 X 30 X 15", "AJINAMOTO GINISA MIX 120/40G", "Carton", 6m },
                    { 159, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2590), "32 X 22 X 34", "PEPSI REG PET BOTTLE 12/1.5L", "Carton", 19m },
                    { 160, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2591), "38 X 30 X 24", "MENTOS CANDY MINT BAG 40/50", "Carton", 7m },
                    { 161, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2591), "50 X 41 X 19", "VIVA CARAMEL CANDY 60/50", "Carton", 14m },
                    { 162, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2592), "32 X 22 X 34", "MOUNTAIN DEW PET BOTTLE 12/1.5L", "Carton", 19m },
                    { 163, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2593), "33 X 16 X 21", "STING ENERGY DRINK STRAWBERRY 24/320", "Carton", 9m },
                    { 164, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2593), "40 X 23 X 22", "PEPSI REG PET BOT 24/500ML", "Carton", 12m },
                    { 165, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2594), "72 X 40 X 17", "SUPER Q PALABOK 12/500G", "Carton", 6m },
                    { 166, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2595), "33 X 27 X 29", "LORINS PATIS PLASTIC 12/1000ML", "Carton", 15m },
                    { 167, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2595), "37 X 26 X 19", "LORINS PATIS PLASTIC 24/350ML", "Carton", 11m },
                    { 168, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2596), "43 X 20 X 25", "AJI CRISPY FRY GARLIC 13/14/62G", "Carton", 12m },
                    { 169, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2596), "50 X 41 X 19", "WHITE RABBIT CANDY 60/50", "Carton", 14m },
                    { 170, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2598), "39 X 31 X 21", "RICOA FLAT TOPS 12/100", "Carton", 7m },
                    { 171, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2599), "30 X 22 X 17", "SURF BAR KALAMANSI 36/360G", "Carton", 12.5m },
                    { 172, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2600), "32 X 10 X 17", "ZEST-O BIG 250 APPLE 10/250ML", "Carton", 2m },
                    { 173, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2601), "32 X 10 X 17", "ZEST-O BIG 250 GRAPE 10/250ML", "Carton", 2m },
                    { 174, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2601), "32 X 10 X 17", "ZEST-O BIG 250 ORANGE 10/250ML", "Carton", 2m },
                    { 175, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2602), "32 X 10 X 17", "ZEST-O BIG MANGO 10/250ML", "Carton", 2m },
                    { 176, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2602), "32 X 27 X 20", "IODIZED SALT 1KG", "Carton", 20m },
                    { 177, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2603), "32 X 27 X 20", "IODIZED SALT 500G", "Carton", 19m },
                    { 178, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2604), "30 X 14 X 13", "LASAP SINIGANG MIX 20G", "Carton", 4m },
                    { 179, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2604), "28 X 28 X 19", "LASAP VETSIN 100G", "Carton", 10m },
                    { 180, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2605), "28 X 28 X 19", "LASAP VETSIN 100G", "Carton", 10m },
                    { 181, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2605), "33 X 19 X 15", "LASAP SINIGANG MIX W/GABI 22G", "Carton", 3m },
                    { 182, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2606), "32 X 22 X 17", "LASAP OYSTER SAUCE 170 G", "Carton", 8m },
                    { 183, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2607), "32 X 22 X 17", "LASAP KARE KARE MIX 75G", "Carton", 2m },
                    { 184, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2608), "30 X 14 X 13", "LASAP TOCINO MIX", "Carton", 2m },
                    { 185, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2609), "30 X 14 X 13", "LASAP BBQ MIX 50G", "Carton", 1m },
                    { 186, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2609), "59 X 36 X 40", "REGENT TEMPURA SHRIMP 25/100G", "Carton", 3m },
                    { 187, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2610), "59 X 36 X 40", "REGENT LABSTER 25/100G", "Carton", 3m },
                    { 188, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2610), "59 X 36 X 40", "REGENT ISDALICIOUS 25/85G", "Carton", 3m },
                    { 189, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2611), "37 X 35 X 17", "REGENT UBE CAKE 8/10'S", "Carton", 2m },
                    { 190, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2612), "37 X 35 X 17", "REGENT SAND CAKE MELON 8/10S", "Carton", 2m },
                    { 191, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2612), "37 X 35 X 17", "REGENT MOCHA CAKE 8/10'S", "Carton", 2m },
                    { 192, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2613), "44 X 27 X 22", "REGENT JAPANESE UBE CAKE 34G", "Carton", 4m },
                    { 193, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2613), "44 X 27 X 22", "REGENT JAPANESE CHOKORETO CAKE 34G", "Carton", 4m },
                    { 194, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2614), "44 X 27 X 22", "REGENT JAPANESE CHEESECAKE 34G", "Carton", 4m },
                    { 195, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2614), "34 X 27 X 14", "REGENT MOCHI MANGO 240G", "Carton", 2m },
                    { 196, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2615), "34 X 27 X 14", "REGENT MOCHI UBE 240 G", "Carton", 2m },
                    { 197, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2617), "34 X 27 X 14", "REGENT BUKO PANDAN 240G", "Carton", 2m },
                    { 198, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2618), "34 X 27 X 14", "REGENT MOCHI ASSORTED", "Carton", 2m },
                    { 199, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2618), "34 X 27 X 14", "REGENT MOCHI BLACK SESAME 240G", "Carton", 2m },
                    { 200, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2619), "34 X 27 X 14", "REGENT MOCHI BLACK SESAME 240G", "Carton", 2m },
                    { 201, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2619), "50 X 38 X 26", "CRIS P'S SEAWEED 60G", "Carton", 3m },
                    { 202, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2620), "50 X 38 X 26", "CRIS P'S SAL VINEGAR 60G", "Carton", 3m },
                    { 203, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2621), "50 X 38 X 26", "CRIS P'S CHEESE", "Carton", 3m },
                    { 204, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2621), "40 X 21 X 18", "POTATO CRACKERS", "Carton", 3m },
                    { 205, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2622), "61 X 39 X 41", "KING CRAB", "Carton", 3m },
                    { 206, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2623), "60 X 30 X 33", "GOLDEN SWEET CORN", "Carton", 4m },
                    { 207, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2623), "60 X 30 X 33", "CHEESE RING JALAPENO", "Carton", 4m },
                    { 208, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2624), "60 X 30 X 33", "CHEESE RING CHEESE", "Carton", 4m },
                    { 209, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2624), "61 X 39 X 41", "FRENCH FRIES", "Carton", 5m },
                    { 210, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2628), "61 X 39 X 41", "SHRIMP FRITTERS", "Carton", 4m },
                    { 211, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2628), "54 X 35 X 38", "MOBY CARAMEL 90G", "Carton", 3m },
                    { 212, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2629), "64 X 46 X 18", "CHEESE IT CHEESE 60G", "Carton", 3m },
                    { 213, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2630), "63 X 46 X 18", "MOBY CHOCOLATE CHIPS 60G", "Carton", 3m },
                    { 214, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2630), "63 X 46 X 18", "MOBY CARAMEL PUFFS 60G", "Carton", 3m },
                    { 215, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2631), "63 X 46 X 18", "MOBY CHOCOLATE 25G", "Carton", 3m },
                    { 216, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2632), "63 X 46 X 18", "MOBY CARAMEL 25G", "Carton", 3m },
                    { 217, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2632), "63 X 46 X 18", "MOBY CHOCO CUM CHOC BU", "Carton", 3m },
                    { 218, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2633), "58 X 48 X 18", "LOADED CHOCO FILLED 65G", "Carton", 3m },
                    { 219, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2633), "58 X 48 X 18", "LOADED WHITE CHOCO 65G", "Carton", 3m },
                    { 220, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2634), "56 X 36 X 38", "LOADED WHITE CHOCO 32G", "Carton", 3m },
                    { 221, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2635), "56 X 36 X 38", "LOADED WHITE CHOCO 32G", "Carton", 3m },
                    { 222, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2635), "56 X 36 X 38", "LOADED CHOCO 32G", "Carton", 3m },
                    { 223, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2636), "56 X 36 X 38", "LOADED CHOCO 32G", "Carton", 3m },
                    { 224, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2638), "46 X 32 X 52", "TOMI SWEET CORN 110G", "Carton", 6m },
                    { 225, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2638), "46 X 32 X 52", "TOMI SWEET CORN 110G", "Carton", 6m },
                    { 226, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2639), "37 X 35 X 17", "REGENT STRAWBERRY CAKE 8/10S", "Carton", 2m },
                    { 227, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2639), "37 X 35 X 17", "REGENT PANDAN CAKE 8/10S", "Carton", 2m },
                    { 228, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2640), "37 X 35 X 17", "REGENT ASSORTED CAKE 8/10S", "Carton", 2m },
                    { 229, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2641), "44 X 27 X 22", "REGENT BANANA CAKE 34G", "Carton", 4m },
                    { 230, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2641), "46 X 30 X 15", "REGENT BELGIAN WAFFLE 30G", "Carton", 4m },
                    { 231, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2642), "46 X 30 X 15", "REGENT BELGIAN CHOCO", "Carton", 4m },
                    { 232, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2642), "46 X 30 X 15", "REGENT BELGIAN CHOCO", "Carton", 4m },
                    { 233, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2643), "38 X 30 X 18", "FLORENCE MACAPUNO 24/12OZ", "Carton", 12m },
                    { 234, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2644), "38 X 30 X 18", "FLORENCE JACKFRUIT 24/12OZ", "Carton", 12m },
                    { 235, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2644), "42 X 32 X 15", "FLORENCE KAONG RED 24/12OZ", "Carton", 16m },
                    { 236, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2645), "42 X 32 X 15", "FLORENCE NATA DE COCO WHITE 24/12OZ", "Carton", 16m },
                    { 237, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2646), "42 X 32 X 15", "FLORENCE NATA DE COCO GREEN 24/12OZ", "Carton", 16m },
                    { 238, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2646), "42 X 32 X 15", "FLORENCE NATA DE COCO RED 24/12OZ", "Carton", 16m },
                    { 240, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2647), "42 X 32 X 15", "FLORENCE JACKFRUIT 24X12OZ", "Carton", 16m },
                    { 241, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2681), "42 X 32 X 15", "FLORENCE PURPLE YAM 24/12OZ", "Carton", 16m },
                    { 242, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2681), "42 X 32 X 15", "FLORENCE PURPLE YAM 24/12OZ", "Carton", 16m },
                    { 243, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2682), "40 X 27 X 13", "FLORENCE NATA DE COCO WHITE 12/24OZ", "Carton", 10m },
                    { 244, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2682), "40 X 27 X 13", "FLORENCE NATA DE COCO GREEN 12/24OZ", "Carton", 10m },
                    { 245, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2683), "40 X 27 X 13", "FLORENCE NATA DE COCO RED 12/24OZ", "Carton", 10m },
                    { 246, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2684), "42 X 32 X 15", "FLORENCE SALTED SHRIMP 24/340G", "Carton", 16m },
                    { 247, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2684), "40 X 27 X 13", "FLORENCE SAU SHRIMP SWEET", "Carton", 16m },
                    { 248, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2685), "40 X 27 X 13", "FLORENCE SAU SHRIMP REGULAR", "Carton", 10m },
                    { 249, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2686), "40 X 27 X 13", "FLORENCE SAU SHRIMP SPICY", "Carton", 10m },
                    { 250, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2686), "39 X 28 X 13", "FLORENCE BAGOONG BALAYAN", "Carton", 14m },
                    { 251, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2687), "58 X 34 X 38", "ADORABLE CREAM BAR CHOCO", "Carton", 8m },
                    { 252, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2689), "58 X 34 X 38", "ADORABLE CREAM BAR MATHCA", "Carton", 8m },
                    { 253, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2690), "58 X 34 X 38", "ADORABLE CREAM BAR STRAWBERRY", "Carton", 8m },
                    { 254, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2690), "36 X 44 X 23", "MONIEGOLD TAMARIND CHEWY 150G", "Carton", 16m },
                    { 255, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2691), "36 X 44 X 23", "MONIEGOLD TAMARIND CHEWY 150G", "Carton", 16m },
                    { 256, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2691), "36 X 44 X 23", "MONIEGOLD TAMARIND CHEWY 80G", "Carton", 16m },
                    { 257, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2692), "53 X 34 X 30", "COCONUT ENERGY BAR NUTS 24/400", "Carton", 10m },
                    { 258, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2693), "54 X 36 X 16", "COCONUT BLAST ICECREAM CHOCO 24/300", "Carton", 8m },
                    { 259, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2693), "54 X 36 X 16", "COCONUT BLAST ICECREAM STRAWBERRY 24/300", "Carton", 8m },
                    { 260, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2694), "54 X 36 X 16", "COCO CREAM BAR CHOCO 24/300", "Carton", 8m },
                    { 261, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2695), "41 X 24 X 17", "BIG 250 APPLE", "Carton", 10.5m },
                    { 262, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2696), "41 X 24 X 17", "BIG 250 GRAPE", "Carton", 10.5m },
                    { 263, null, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(2696), "41 X 24 X 17", "BIG 250 ORANGE", "Carton", 10.5m }
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
                    { 1, 3, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1936), false, 3, "Metal Shelving 1", 1 },
                    { 2, 1, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1954), false, 5, "Metal Shelving 2", 1 },
                    { 3, 3, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1956), false, 4, "Pallet Racking 1", 1 },
                    { 4, 6, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1956), false, 4, "Pallet Racking 2", 1 },
                    { 5, 3, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1957), false, 4, "Pallet Racking 3", 1 },
                    { 6, 2, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1957), false, 7, "Crossdocking 1", 1 },
                    { 7, 2, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1958), false, 7, "Crossdocking 2", 1 },
                    { 8, 2, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1958), false, 7, "Crossdocking 3", 1 },
                    { 9, 1, new DateTime(2026, 10, 14, 9, 52, 5, 488, DateTimeKind.Local).AddTicks(1959), false, 7, "Crossdocking 4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Receivings",
                columns: new[] { "Id", "CheckerName", "ClientRepresentative", "Consignee", "DateAdded", "DateReceived", "DateTime", "DriverName", "IncomingId", "PlateNumber", "Reference", "Series", "Shipper", "TimeEnd", "TimeStart", "TransportCompany", "WarehouseId" },
                values: new object[,]
                {
                    { 1, "VAN VERGEL CORTE", "", "", new DateTime(2025, 1, 22, 1, 48, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 8, 33, 0, 0, DateTimeKind.Unspecified), "NORBERTO TAMON", null, "NAQ9905", "BS23580", "SLCWH-00001-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 10, 10, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 8, 33, 0, 0, DateTimeKind.Unspecified), "REGENT FOOD CORPORATION", 1 },
                    { 2, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 48, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", null, "NAQ3433", "SI8100009660", "SLCWH-00002-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 12, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 3, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 1, 58, 1, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "JOEY ANASTACIO", null, "NAM4312", "SI8100009350", "SLCWH-00003-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING COPORATION", 1 },
                    { 4, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 17, 0, 0, DateTimeKind.Unspecified), "JANWARREN REYES", null, "NHF7527", "SI8100009681", "SLCWH-00004-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 13, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 17, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 5, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 1, 27, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 43, 0, 0, DateTimeKind.Unspecified), "RANDOLPH MAGDAMIT", null, "CAJ8292", "SI8100009680", "SLCWH-00005-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 14, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 13, 43, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING COPORATION", 1 },
                    { 6, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 18, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 9, 0, 0, DateTimeKind.Unspecified), "JANVIE CABALE", null, "XTB145", "SI8100009707", "SLCWH-00006-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 14, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 9, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 7, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 20, 34, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 35, 0, 0, DateTimeKind.Unspecified), "JAYNARD CLAVO", null, "NIO8373", "SI8100009711", "SLCWH-00007-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 35, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 8, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 24, 44, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 52, 0, 0, DateTimeKind.Unspecified), "ALLAN BARREDO", null, "NBS2417", "SI8100009713", "SLCWH-00008-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 15, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 14, 52, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 9, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 27, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 11, 0, 0, DateTimeKind.Unspecified), "MARK EDISON REGENCIA", null, "NBR9810", "SI8100009712", "SLCWH-00009-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 15, 15, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 15, 11, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 10, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 29, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 11, 45, 0, 0, DateTimeKind.Unspecified), "JEYVIN HELIS", null, "XTK237", "SI8100010505", "SLCWH-00010-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 16, 12, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 11, 45, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 11, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 35, 41, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 12, 8, 0, 0, DateTimeKind.Unspecified), "JOHANSON OLIVEROS", null, "NAO9918", "SI8100010504", "SLCWH-00011-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 16, 12, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 12, 8, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 12, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 38, 14, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 13, 45, 0, 0, DateTimeKind.Unspecified), "RANDOLPH MAGDAMIT", null, "CAJ8292", "SI8100010518", "SLCWH-00012-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 16, 14, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 45, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 13, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 40, 45, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "JOEY ANASTACIO", null, "NAM4312", "SI8100011269", "SLCWH-00013-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 17, 10, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / VONE TRUCKING", 1 },
                    { 14, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 22, 2, 44, 46, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "JOEY ANASTACIO", null, "NAM4312", "SI8100011267", "SLCWH-00014-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 7, 10, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 9, 2, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / VONE TRUCKING", 1 },
                    { 18, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 25, 2, 30, 20, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV 103001428147", "SLCWH-00015-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 19, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 25, 2, 33, 39, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV 103001428148", "SLCWH-00016-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 20, "VAN VERGEL CONTE", "", "", new DateTime(2025, 1, 25, 2, 36, 43, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV 103001428146", "SLCWH-00017-25", "EAST RIZAL TRADING", new DateTime(2025, 1, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 10, 24, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 21, "VAN VERGEL CONTE", "", "BESTCHILL INC", new DateTime(2025, 1, 25, 3, 25, 23, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "ASDAD", null, "ABC1234", "INV AA-1111001", "SLCWH-00018-25", "FLUTAI COMPANY LIMITED", new DateTime(2022, 11, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "SKYBEST LOGISTICS CORPORATION", 1 },
                    { 22, "VAN VERGEL CONTE", "", "", new DateTime(2025, 3, 7, 10, 0, 34, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 1, 10, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 8, 34, 0, 0, DateTimeKind.Unspecified), "Samuel Ramos", null, "NBE7478", "1106083", "SLCWH-00019-25", "EAST RIZAL TRADING", new DateTime(2025, 2, 25, 9, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 8, 34, 0, 0, DateTimeKind.Unspecified), "REGENT FOODS CORP / JWDC TRUCKING", 1 },
                    { 23, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 2, 50, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 8, 35, 0, 0, DateTimeKind.Unspecified), "RINATO LOPEZ", null, "CBB4965", "8100047950", "SLCWH-00020-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 9, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 8, 35, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 24, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 9, 7, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 9, 24, 0, 0, DateTimeKind.Unspecified), "Jaynard Clavo", null, "NIO 8373", "8100047812", "SLCWH-00021-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 9, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 9, 24, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION / GOBEYOND TRUCKING", 1 },
                    { 25, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 11, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 15, 0, 0, DateTimeKind.Unspecified), "JOHANSON OLIVEROS", null, "NAO 9915", "8100047630", "SLCWH-00022-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 10, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 15, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 26, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 17, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", null, "NBT 8366", "8100047625", "SLCWH-00023-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 27, "", "", "", new DateTime(2025, 3, 5, 1, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 1, 17, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", null, "NBT 8366", "8100047587", "SLCWH-00024-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 10, 38, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 28, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 26, 18, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 11, 0, 0, DateTimeKind.Unspecified), "MICHAEL GARLANDO", null, "NAQ 3433", "8100047808", "SLCWH-00025-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 11, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 29, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 1, 28, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), "ELWEN ACOS", null, "NBR 9963", "8100047804", "SLCWH-00026-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 4, 11, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 30, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 2, 28, 9, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 2, 21, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 8, 31, 0, 0, DateTimeKind.Unspecified), "JOHANSON OLIVEROS", null, "RHE 512", "8100048625", "SLCWH-00027-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 8, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 8, 31, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 31, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 2, 33, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 2, 30, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "J. DELA CERNA", null, "NAQ 3433", "8100048620", "SLCWH-00028-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 9, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 32, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 3, 37, 27, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 3, 30, 54, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 10, 59, 0, 0, DateTimeKind.Unspecified), "GERMAN ALILING", null, "NBT 8366", "8100048619", "SLCWH-00029-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 11, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 10, 59, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 33, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 3, 5, 6, 32, 30, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 5, 59, 58, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 1, 35, 0, 0, DateTimeKind.Unspecified), "ERNESTO JAMERO", null, "XTB145", "8100048629", "SLCWH-00030-25", "EAST RIZAL TRADING", new DateTime(2025, 3, 5, 1, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 1, 35, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 34, "VAN VERGEL CONTE", "", "BESTCHILL INC", new DateTime(2025, 3, 13, 2, 26, 56, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 13, 10, 0, 0, DateTimeKind.Unspecified), "JERSON", null, "ABC1234", "INV: 20221118", "SLCWH-00031-25", "DONGGUAN TONGDA STORAGE SERVE CO., LTD.", new DateTime(2025, 3, 7, 13, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 13, 10, 0, 0, DateTimeKind.Unspecified), "SKYBEST LOGISTICS CORPORATION", 1 },
                    { 35, "JAN MICHAEL LARDIZABAL", "", "", new DateTime(2025, 4, 8, 1, 45, 52, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 1, 38, 26, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "JANCARL DEL ROSARIO", null, "NKF2611", "ZMC-0010", "SLCWH-00032-25", "EAST RIZAL TRADING", new DateTime(2025, 8, 4, 9, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "Zesto Corporation", 1 },
                    { 36, "VAN VERGEL CONTE", "", "", new DateTime(2025, 5, 9, 2, 10, 52, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 2, 6, 5, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "JOHN CUTAMORA", null, "NBY 4315", "SI8100093852", "SLCWH-00033-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 9, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 37, "VAN VERGEL CONTE", "", "", new DateTime(2025, 5, 9, 2, 14, 1, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 2, 11, 14, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "JOHN CUTAMORA", null, "NBY 4315", "SI8100093853", "SLCWH-00034-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 9, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 8, 34, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 38, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 9, 2, 19, 18, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 2, 14, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 9, 44, 0, 0, DateTimeKind.Unspecified), "JONVIE CABALE", null, "ABK 6586", "SI8100093854", "SLCWH-00035-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 10, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 9, 44, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 39, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 9, 3, 58, 40, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 3, 27, 8, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 10, 34, 0, 0, DateTimeKind.Unspecified), "ALEX QUERIZA", null, "NBX 7265", "SI8100093962", "SLCWH-00036-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 11, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 10, 34, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 40, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 9, 4, 20, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 4, 12, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 11, 55, 0, 0, DateTimeKind.Unspecified), "JEFERSON URCIA", null, "CCO 5221", "SI8100094566", "SLCWH-00037-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 9, 0, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 11, 55, 0, 0, DateTimeKind.Unspecified), "LIWAYWAY MARKETING CORPORATION", 1 },
                    { 41, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 10, 0, 22, 30, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 0, 19, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 31, 0, 0, DateTimeKind.Unspecified), "ANGELO PADRE", null, "GAK 2456", "26887", "SLCWH-00038-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 10, 7, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 31, 0, 0, DateTimeKind.Unspecified), "MAGIS DISTRIBUTION INC", 1 },
                    { 42, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 10, 0, 34, 35, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 0, 32, 14, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 49, 0, 0, DateTimeKind.Unspecified), "ALEX ENCISO", null, "UIX 617", "10068437", "SLCWH-00039-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 10, 7, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 7, 49, 0, 0, DateTimeKind.Unspecified), "JARCFMCG DISTRIBUTIONG CORP.", 1 },
                    { 43, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 2, 25, 33, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 2, 21, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 8, 43, 0, 0, DateTimeKind.Unspecified), "JERIC ZETA", null, "NEG 4134", "BS 239266", "SLCWH-00040-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 10, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 8, 43, 0, 0, DateTimeKind.Unspecified), "REGENT FOOD CORPORATION / JWDS", 1 },
                    { 44, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 30, 49, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 23, 30, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH 3355", "INV: 103001724905", "SLCWH-00041-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 45, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 44, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 31, 7, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV: 103001724906", "SLCWH-00042-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 46, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 35, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 33, 20, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV: 103001724908", "SLCWH-00043-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 47, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 39, 12, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 35, 16, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV: 103001724910", "SLCWH-00044-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 48, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 46, 40, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 39, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV: 103001724911", "SLCWH-00045-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 49, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 4, 48, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 4, 47, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "FELIPE POBLEO", null, "CAH3355", "INV: 103001724912", "SLCWH-00046-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 11, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 10, 42, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 50, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 5, 28, 6, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 5, 20, 48, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "ELIAZAR UMOQUIT", null, "CAL 3472", "INV: 103001724907", "SLCWH-00047-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 13, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 51, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 13, 5, 31, 57, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 5, 28, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "ELIAZAR UMOQUIT", null, "CAL 3472", "INV: 103001724909", "SLCWH-00048-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 13, 13, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 13, 5, 0, 0, DateTimeKind.Unspecified), "SUYSING COMMERCIAL CORPORATION", 1 },
                    { 52, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 15, 1, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 1, 27, 11, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 9, 11, 0, 0, DateTimeKind.Unspecified), "RISER SORIANO", null, "NAN2206", "264051", "SLCWH-00049-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 15, 9, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 9, 11, 0, 0, DateTimeKind.Unspecified), "PRIFOOD CORPORATION", 1 },
                    { 53, "TIMOTHY AMBROSE MANALAYSAY", "", "", new DateTime(2025, 5, 15, 3, 16, 17, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 3, 12, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 10, 58, 0, 0, DateTimeKind.Unspecified), "EDWIN PADEROS", null, "NKF3224", "0", "SLCWH-00050-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 15, 11, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 15, 10, 58, 0, 0, DateTimeKind.Unspecified), "WL FOODS (LALAMOVE)", 1 },
                    { 54, "JAN MICHAEL LARDIZABAL", "", "", new DateTime(2025, 5, 16, 23, 35, 34, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 16, 23, 27, 22, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 17, 7, 20, 0, 0, DateTimeKind.Unspecified), "ROBERT DOMINGO JR", null, "CCB6518", "DR01319916", "SLCWH-00051-25", "EAST RIZAL TRADING", new DateTime(2025, 5, 17, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 17, 7, 20, 0, 0, DateTimeKind.Unspecified), "WL FOODS PRODUCTS", 1 },
                    { 55, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 23, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "LYMART BONGAHOY", null, "CAZ 1482", "104001000000", "SLCWH-00052-25", "RCV", new DateTime(2025, 5, 28, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "SUY SING / VILLALIMA", 2 },
                    { 56, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 30, 42, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 32, 36, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 7, 50, 0, 0, DateTimeKind.Unspecified), "MARK ANTHONY PADILLA", null, "CAB 5802", "178615", "SLCWH-00053-25", "RCV", new DateTime(2025, 5, 29, 8, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 7, 50, 0, 0, DateTimeKind.Unspecified), "ZESTO CORPORATION / 2K2J-2", 2 },
                    { 57, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 8, 47, 43, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 42, 53, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 12, 15, 0, 0, DateTimeKind.Unspecified), "LESTER SANCHEZ", null, "DBM 4751", "14021", "SLCWH-00054-25", "RCV", new DateTime(2025, 5, 29, 12, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 12, 15, 0, 0, DateTimeKind.Unspecified), "LIANA'S DAILY MART", 2 },
                    { 58, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 8, 52, 53, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 49, 16, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 14, 49, 0, 0, DateTimeKind.Unspecified), "LARRY BULAGNER", null, "NHC 5016", "52422", "SLCWH-00055-25", "RCV", new DateTime(2025, 5, 29, 14, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 14, 49, 0, 0, DateTimeKind.Unspecified), "AZUCAR DISTRIBUTION", 2 },
                    { 59, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 3, 20, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 8, 58, 9, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 14, 37, 0, 0, DateTimeKind.Unspecified), "RYAN ARTUGUE", null, "NKP 4704", "314", "SLCWH-00056-25", "RCV", new DateTime(2025, 5, 28, 14, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 14, 37, 0, 0, DateTimeKind.Unspecified), "BESTMART", 2 },
                    { 60, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 5, 29, 9, 5, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 29, 9, 3, 50, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "DOMINIC BALUYOT", null, "NKH 1349", "316", "SLCWH-00057-25", "RCV", new DateTime(2025, 5, 28, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 15, 32, 0, 0, DateTimeKind.Unspecified), "BESTMART", 2 },
                    { 62, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 2, 7, 44, 15, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 9, 1, 0, 0, DateTimeKind.Unspecified), "MAG MINOZA", null, "NCK 9038", "104001000000", "SLCWH-00058-25", "RCV", new DateTime(2025, 5, 28, 9, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 9, 1, 0, 0, DateTimeKind.Unspecified), "SUY SING", 2 },
                    { 63, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 2, 9, 33, 53, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 8, 15, 0, 0, DateTimeKind.Unspecified), "ALEX BORIGAS", null, "CBS 2980", "104001000000", "SLCWH-00059-25", "RCV", new DateTime(2025, 5, 28, 8, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 28, 8, 15, 0, 0, DateTimeKind.Unspecified), "SUYSING", 2 },
                    { 64, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 4, 7, 43, 40, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 7, 36, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 8, 50, 0, 0, DateTimeKind.Unspecified), "JOEL EDEM", null, "PQD 200", "104001000000", "SLCWH-00060-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 4, 9, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 8, 50, 0, 0, DateTimeKind.Unspecified), "SUYSING / TSM TRUCKING", 2 },
                    { 65, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 4, 7, 52, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 7, 44, 7, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 9, 45, 0, 0, DateTimeKind.Unspecified), "ARTHUR ROJAS", null, "GAA 5050", "11505", "SLCWH-00061-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 4, 10, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 9, 45, 0, 0, DateTimeKind.Unspecified), "PSWRI", 2 },
                    { 66, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 4, 8, 43, 33, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 8, 28, 36, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 10, 47, 0, 0, DateTimeKind.Unspecified), "RUPERTO CHERRY", null, "NAF 7231", "104001000000", "SLCWH-00062-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 4, 11, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 4, 10, 47, 0, 0, DateTimeKind.Unspecified), "SUYSING / TSM TRUCKING", 2 },
                    { 67, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 2, 44, 27, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 11, 2, 39, 1, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), "VICSON CUDAL", null, "NHL 5003", "2024-0080", "SLCWH-00063-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 5, 8, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), "EJJC-3 TRUCKING", 2 },
                    { 68, "", "", "", new DateTime(2025, 6, 11, 3, 39, 18, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "MARK VALENUEVA", null, "XPL 733", "73251", "SLCWH-00064-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 5, 9, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "BILLIES", 2 },
                    { 69, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 3, 39, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "MARK VALENUEVA", null, "XPL 733", "73251", "SLCWH-00065-25", "SUNRISE UNLIMITED TRADING", new DateTime(2025, 6, 5, 9, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 9, 40, 0, 0, DateTimeKind.Unspecified), "BILLIES", 2 },
                    { 70, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 5, 44, 17, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 13, 2, 0, 0, DateTimeKind.Unspecified), "JIMMY BOB VISTAL", null, "NEV 4353", "239091", "SLCWH-00066-25", "SUNRISE TRADING", new DateTime(2025, 6, 5, 13, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 5, 13, 2, 0, 0, DateTimeKind.Unspecified), "MANIMALIX", 2 },
                    { 71, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 7, 32, 10, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 10, 48, 0, 0, DateTimeKind.Unspecified), "JOHN CABILLO", null, "NAB 080", "1427", "SLCWH-00067-25", "SUNRISE TRADING", new DateTime(2025, 6, 9, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 10, 48, 0, 0, DateTimeKind.Unspecified), "OGB FOOD", 2 },
                    { 72, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 7, 46, 28, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), "JIMMY BOB VISTAL", null, "NEV 4353", "239091", "SLCWH-00068-25", "SUNRISE TRADING", new DateTime(2025, 6, 9, 8, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), "MANIMALIX", 2 },
                    { 73, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 8, 21, 5, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "FLORO NOFIES", null, "RES 126", "55384", "SLCWH-00069-25", "SUNRISE TRADING", new DateTime(2025, 6, 7, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "PIXCEL", 2 },
                    { 74, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 11, 8, 42, 23, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 10, 28, 0, 0, DateTimeKind.Unspecified), "NANTE MABINI", null, "ABC 123", "1", "SLCWH-00070-25", "SUNRISE TRADING", new DateTime(2025, 6, 10, 10, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 10, 28, 0, 0, DateTimeKind.Unspecified), "VIA LALAMOVE", 2 },
                    { 75, "Timothy Ambrose Manalaysay", "", "", new DateTime(2025, 6, 18, 2, 6, 37, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 2, 2, 55, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 9, 33, 0, 0, DateTimeKind.Unspecified), "MAGPILI WILLIAM MADRID", null, "NAA 1320", "Z-MCPPG-0011", "SLCWH-00071-25", "EAST RIZAL TRADING", new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 9, 33, 0, 0, DateTimeKind.Unspecified), "ZESTO CORPORATION / JHEAIN-6", 1 }
                });

            migrationBuilder.InsertData(
                table: "Bins",
                columns: new[] { "Id", "BayId", "BinHashCode", "BinNamesId", "DateAdded", "LevelId", "Location3DId", "RackId", "RelativeX", "RelativeY", "RelativeZ", "StandaloneLocationId", "WarehouseId" },
                values: new object[,]
                {
                    { 1, 1, 976636213, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 1, null, null, null, null, null },
                    { 2, 1, -1979248654, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 1, null, null, null, null, null },
                    { 3, 1, 1673490748, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 1, null, null, null, null, null },
                    { 4, 2, 1701384564, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 1, null, null, null, null, null },
                    { 5, 2, 196724902, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 1, null, null, null, null, null },
                    { 6, 2, -484174977, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 1, null, null, null, null, null },
                    { 7, 3, -1790539235, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 1, null, null, null, null, null },
                    { 8, 3, 642809004, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 1, null, null, null, null, null },
                    { 9, 3, -1992005959, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 1, null, null, null, null, null },
                    { 10, 1, -902286026, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 2, null, null, null, null, null },
                    { 11, 1, 485716536, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 2, null, null, null, null, null },
                    { 12, 1, 120754032, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 2, null, null, null, null, null },
                    { 13, 1, -767892144, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 2, null, null, null, null, null },
                    { 14, 1, -105527948, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 5, null, 2, null, null, null, null, null },
                    { 15, 1, -1285803628, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 3, null, null, null, null, null },
                    { 16, 1, 800775118, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 3, null, null, null, null, null },
                    { 17, 1, 1019046532, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 3, null, null, null, null, null },
                    { 18, 1, 719689299, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 3, null, null, null, null, null },
                    { 19, 1, 276386526, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 3, null, null, null, null, null },
                    { 20, 1, 1871078101, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 3, null, null, null, null, null },
                    { 21, 1, -341256051, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 3, null, null, null, null, null },
                    { 22, 1, 641176255, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 3, null, null, null, null, null },
                    { 23, 2, -1555901299, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 3, null, null, null, null, null },
                    { 24, 2, -1585561989, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 3, null, null, null, null, null },
                    { 25, 2, 1053115519, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 3, null, null, null, null, null },
                    { 26, 2, -479592046, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 3, null, null, null, null, null },
                    { 27, 2, -1228370061, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 3, null, null, null, null, null },
                    { 28, 2, 1245142399, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 3, null, null, null, null, null },
                    { 29, 2, -652623830, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 3, null, null, null, null, null },
                    { 30, 2, 1485157462, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 3, null, null, null, null, null },
                    { 31, 3, -1358792930, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 3, null, null, null, null, null },
                    { 32, 3, -346485753, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 3, null, null, null, null, null },
                    { 33, 3, 1185566390, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 3, null, null, null, null, null },
                    { 34, 3, -1450237118, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 3, null, null, null, null, null },
                    { 35, 3, 1150083063, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 3, null, null, null, null, null },
                    { 36, 3, -1122546266, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 3, null, null, null, null, null },
                    { 37, 3, -1317167336, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 3, null, null, null, null, null },
                    { 38, 3, 187127893, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 3, null, null, null, null, null },
                    { 39, 1, -1850022207, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 40, 1, 1318415253, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 41, 1, -18621311, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 42, 1, 1420536157, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 43, 1, 1062200443, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 44, 1, -1512804114, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 45, 1, 527966408, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 46, 1, 511745895, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 47, 2, 116982465, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 48, 2, 1654232790, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 49, 2, 334109798, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 50, 2, 1123410421, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 51, 2, -2108006358, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 52, 2, 395006760, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 53, 2, 2010979598, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 54, 2, -40662049, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 55, 3, -1084611347, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 56, 3, -1787215891, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 57, 3, -1643181944, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 58, 3, 1321412513, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 59, 3, -763942232, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 60, 3, -2056561571, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 61, 3, -2118881999, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 62, 3, -470185763, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 63, 4, -1658049340, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 64, 4, 844845106, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 65, 4, -1669224409, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 66, 4, -358179989, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 67, 4, -1955242011, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 68, 4, 1958354202, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 69, 4, 1825131077, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 70, 4, -169292521, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 71, 5, -1517118774, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 72, 5, 1886512625, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 73, 5, -1449568076, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 74, 5, -343470659, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 75, 5, -1614793922, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 76, 5, -56520126, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 77, 5, 692756103, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 78, 5, 1833364874, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 79, 6, 2005043736, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 80, 6, 2046651153, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 4, null, null, null, null, null },
                    { 81, 6, -933943777, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 82, 6, 291972557, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 4, null, null, null, null, null },
                    { 83, 6, -863513047, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 84, 6, -573098862, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 4, null, null, null, null, null },
                    { 85, 6, -326151564, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 86, 6, 997413098, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 4, null, null, null, null, null },
                    { 87, 1, 1638846713, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 5, null, null, null, null, null },
                    { 88, 1, 1543093550, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 5, null, null, null, null, null },
                    { 89, 1, -1128665772, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 5, null, null, null, null, null },
                    { 90, 1, 486148647, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 5, null, null, null, null, null },
                    { 91, 1, -1264708691, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 5, null, null, null, null, null },
                    { 92, 1, 2026885023, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 5, null, null, null, null, null },
                    { 93, 1, 979658065, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 5, null, null, null, null, null },
                    { 94, 1, 1465100942, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 5, null, null, null, null, null },
                    { 95, 2, -1984800236, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 5, null, null, null, null, null },
                    { 96, 2, -1216511168, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 5, null, null, null, null, null },
                    { 97, 2, -456683100, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 5, null, null, null, null, null },
                    { 98, 2, -317063528, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 5, null, null, null, null, null },
                    { 99, 2, -87416372, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 5, null, null, null, null, null },
                    { 100, 2, 411003153, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 5, null, null, null, null, null },
                    { 101, 2, -1884306233, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 5, null, null, null, null, null },
                    { 102, 2, -340554057, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 5, null, null, null, null, null },
                    { 103, 3, -1690893460, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 5, null, null, null, null, null },
                    { 104, 3, -1153602774, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 1, null, 5, null, null, null, null, null },
                    { 105, 3, 1710903346, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 5, null, null, null, null, null },
                    { 106, 3, 773588751, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 2, null, 5, null, null, null, null, null },
                    { 107, 3, -1603994513, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 5, null, null, null, null, null },
                    { 108, 3, 1282473269, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 3, null, 5, null, null, null, null, null },
                    { 109, 3, -57269117, 1, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 5, null, null, null, null, null },
                    { 110, 3, 839865094, 2, new DateTime(2024, 12, 10, 8, 4, 17, 763, DateTimeKind.Unspecified).AddTicks(9160), 4, null, 5, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "IX_Bins_Location3DId",
                table: "Bins",
                column: "Location3DId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_RackId",
                table: "Bins",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_WarehouseId",
                table: "Bins",
                column: "WarehouseId");

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
                name: "IX_ExceptionPhoto_ReceivingExceptionId",
                table: "ExceptionPhoto",
                column: "ReceivingExceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingDocuments_IncomingId",
                table: "IncomingDocuments",
                column: "IncomingId");

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

            migrationBuilder.CreateIndex(
                name: "IX_LoadingEvidence_LoadingPlanId",
                table: "LoadingEvidence",
                column: "LoadingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingExceptions_LoadingPlanId",
                table: "LoadingExceptions",
                column: "LoadingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingExceptions_LoadingPlanLineId",
                table: "LoadingExceptions",
                column: "LoadingPlanLineId");

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
                name: "IX_ReceivedProducts_IncomingProductId",
                table: "ReceivedProducts",
                column: "IncomingProductId");

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
                name: "IX_ReceivingException_ReceivedProductId",
                table: "ReceivingException",
                column: "ReceivedProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_IncomingId",
                table: "Receivings",
                column: "IncomingId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_WarehouseId",
                table: "Receivings",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportJobs_WarehouseId",
                table: "ReportJobs",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLogs_FromBinId",
                table: "TransferLogs",
                column: "FromBinId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLogs_PalletId",
                table: "TransferLogs",
                column: "PalletId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLogs_ReceivedProductId",
                table: "TransferLogs",
                column: "ReceivedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLogs_ToBinId",
                table: "TransferLogs",
                column: "ToBinId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferLogs_WarehouseId",
                table: "TransferLogs",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "CheckInBin");

            migrationBuilder.DropTable(
                name: "CheckInReceivedProduct");

            migrationBuilder.DropTable(
                name: "ExceptionPhoto");

            migrationBuilder.DropTable(
                name: "IncomingDocuments");

            migrationBuilder.DropTable(
                name: "LoadingEvidence");

            migrationBuilder.DropTable(
                name: "LoadingExceptions");

            migrationBuilder.DropTable(
                name: "LoadingPalletVerifications");

            migrationBuilder.DropTable(
                name: "OutboundStageCancellationLines");

            migrationBuilder.DropTable(
                name: "RackFloorMapObjects");

            migrationBuilder.DropTable(
                name: "ReportJobs");

            migrationBuilder.DropTable(
                name: "TransferLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ReceivingException");

            migrationBuilder.DropTable(
                name: "LoadingPlanLines");

            migrationBuilder.DropTable(
                name: "OutboundStageCancellations");

            migrationBuilder.DropTable(
                name: "LoadingPlans");

            migrationBuilder.DropTable(
                name: "OutboundStageLines");

            migrationBuilder.DropTable(
                name: "OutboundStages");

            migrationBuilder.DropTable(
                name: "PickedProducts");

            migrationBuilder.DropTable(
                name: "ManualPickings");

            migrationBuilder.DropTable(
                name: "ReceivedProducts");

            migrationBuilder.DropTable(
                name: "Bins");

            migrationBuilder.DropTable(
                name: "CheckIns");

            migrationBuilder.DropTable(
                name: "IncomingProduct");

            migrationBuilder.DropTable(
                name: "Receivings");

            migrationBuilder.DropTable(
                name: "BinNames");

            migrationBuilder.DropTable(
                name: "Location3D");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Incomings");

            migrationBuilder.DropTable(
                name: "Bays");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
