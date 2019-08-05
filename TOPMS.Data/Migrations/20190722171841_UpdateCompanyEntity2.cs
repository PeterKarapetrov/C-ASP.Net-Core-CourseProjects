using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class UpdateCompanyEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAreaOfService_AreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfService");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAreaOfService_Companies_CompanyId",
                table: "CompanyAreaOfService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyAreaOfService",
                table: "CompanyAreaOfService");

            migrationBuilder.RenameTable(
                name: "CompanyAreaOfService",
                newName: "CompanyAreaOfServices");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyAreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfServices",
                newName: "IX_CompanyAreaOfServices_AreaOfServiceId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyType",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyAreaOfServices",
                table: "CompanyAreaOfServices",
                columns: new[] { "CompanyId", "AreaOfServiceId" });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ValidForMonth = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTill = table.Column<DateTime>(nullable: false),
                    ConvertFrom = table.Column<int>(nullable: false),
                    ConvertToBGN = table.Column<int>(nullable: false),
                    ConvertRate = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAreaOfServices_AreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfServices",
                column: "AreaOfServiceId",
                principalTable: "AreaOfService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAreaOfServices_Companies_CompanyId",
                table: "CompanyAreaOfServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAreaOfServices_AreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAreaOfServices_Companies_CompanyId",
                table: "CompanyAreaOfServices");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyAreaOfServices",
                table: "CompanyAreaOfServices");

            migrationBuilder.DropColumn(
                name: "CompanyType",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "CompanyAreaOfServices",
                newName: "CompanyAreaOfService");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyAreaOfServices_AreaOfServiceId",
                table: "CompanyAreaOfService",
                newName: "IX_CompanyAreaOfService_AreaOfServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyAreaOfService",
                table: "CompanyAreaOfService",
                columns: new[] { "CompanyId", "AreaOfServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAreaOfService_AreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfService",
                column: "AreaOfServiceId",
                principalTable: "AreaOfService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAreaOfService_Companies_CompanyId",
                table: "CompanyAreaOfService",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
