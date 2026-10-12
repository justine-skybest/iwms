using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Data.Migrations;

public partial class AddLoadingExceptionLineReference : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "LoadingPlanLineId",
            table: "LoadingExceptions",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_LoadingExceptions_LoadingPlanLineId",
            table: "LoadingExceptions",
            column: "LoadingPlanLineId");

        migrationBuilder.AddForeignKey(
            name: "FK_LoadingExceptions_LoadingPlanLines_LoadingPlanLineId",
            table: "LoadingExceptions",
            column: "LoadingPlanLineId",
            principalTable: "LoadingPlanLines",
            principalColumn: "Id",
            onDelete: ReferentialAction.SetNull);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_LoadingExceptions_LoadingPlanLines_LoadingPlanLineId",
            table: "LoadingExceptions");

        migrationBuilder.DropIndex(
            name: "IX_LoadingExceptions_LoadingPlanLineId",
            table: "LoadingExceptions");

        migrationBuilder.DropColumn(
            name: "LoadingPlanLineId",
            table: "LoadingExceptions");
    }
}
