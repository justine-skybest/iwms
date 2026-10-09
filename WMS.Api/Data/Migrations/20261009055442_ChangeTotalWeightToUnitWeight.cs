using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations;

public partial class ChangeTotalWeightToUnitWeight : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<decimal>(
            name: "Weight",
            table: "IncomingProduct",
            type: "decimal(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "Weight",
            table: "ReceivedProducts",
            type: "decimal(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "ExpectedTotalWeightDecimal",
            table: "ReceivedProducts",
            type: "decimal(18,2)",
            precision: 18,
            scale: 2,
            nullable: true);

        migrationBuilder.Sql("""
            UPDATE `IncomingProduct`
            SET `Weight` = CASE
                WHEN `Quantity` > 0 AND TRIM(`TotalWeight`) REGEXP '^[+-]?[0-9]+([.][0-9]+)?$'
                    THEN CAST(`TotalWeight` AS DECIMAL(18,6)) / `Quantity`
                ELSE NULL
            END;

            UPDATE `ReceivedProducts`
            SET `Weight` = CASE
                WHEN `Quantity` > 0 AND TRIM(`TotalWeight`) REGEXP '^[+-]?[0-9]+([.][0-9]+)?$'
                    THEN CAST(`TotalWeight` AS DECIMAL(18,6)) / `Quantity`
                ELSE NULL
            END;

            UPDATE `ReceivedProducts`
            SET `ExpectedTotalWeightDecimal` = CASE
                WHEN TRIM(`ExpectedTotalWeight`) REGEXP '^[+-]?[0-9]+([.][0-9]+)?$'
                    THEN CAST(`ExpectedTotalWeight` AS DECIMAL(18,2))
                ELSE NULL
            END;
            """);

        migrationBuilder.DropColumn(
            name: "ExpectedTotalWeight",
            table: "ReceivedProducts");

        migrationBuilder.RenameColumn(
            name: "ExpectedTotalWeightDecimal",
            table: "ReceivedProducts",
            newName: "ExpectedTotalWeight");

        migrationBuilder.DropColumn(
            name: "TotalWeight",
            table: "ReceivedProducts");

        migrationBuilder.DropColumn(
            name: "TotalWeight",
            table: "IncomingProduct");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "TotalWeight",
            table: "IncomingProduct",
            type: "longtext",
            nullable: false,
            defaultValue: "")
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "TotalWeight",
            table: "ReceivedProducts",
            type: "longtext",
            nullable: false,
            defaultValue: "")
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.Sql("""
            UPDATE `IncomingProduct`
            SET `TotalWeight` = CAST(ROUND(COALESCE(`Weight`, 0) * `Quantity`, 2) AS CHAR);

            UPDATE `ReceivedProducts`
            SET `TotalWeight` = CAST(ROUND(COALESCE(`Weight`, 0) * `Quantity`, 2) AS CHAR);
            """);

        migrationBuilder.DropColumn(
            name: "Weight",
            table: "IncomingProduct");

        migrationBuilder.DropColumn(
            name: "Weight",
            table: "ReceivedProducts");

        migrationBuilder.AlterColumn<string>(
            name: "ExpectedTotalWeight",
            table: "ReceivedProducts",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,2)",
            oldPrecision: 18,
            oldScale: 2,
            oldNullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");
    }
}
