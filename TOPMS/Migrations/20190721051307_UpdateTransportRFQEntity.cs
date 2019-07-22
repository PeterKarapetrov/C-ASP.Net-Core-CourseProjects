using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class UpdateTransportRFQEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TransportRFQs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FromId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPackages",
                table: "TransportRFQs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PackageDimention",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDeliveryDate",
                table: "TransportRFQs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ServiceId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentReadyDate",
                table: "TransportRFQs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequirements",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Volume",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_FromId",
                table: "TransportRFQs",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_MaterialId",
                table: "TransportRFQs",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_ServiceId",
                table: "TransportRFQs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_StatusId",
                table: "TransportRFQs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_ToId",
                table: "TransportRFQs",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_TransportId",
                table: "TransportRFQs",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Companies_FromId",
                table: "TransportRFQs",
                column: "FromId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Materials_MaterialId",
                table: "TransportRFQs",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Services_ServiceId",
                table: "TransportRFQs",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Status_StatusId",
                table: "TransportRFQs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Companies_ToId",
                table: "TransportRFQs",
                column: "ToId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Transports_TransportId",
                table: "TransportRFQs",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Companies_FromId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Materials_MaterialId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Services_ServiceId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Status_StatusId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Companies_ToId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Transports_TransportId",
                table: "TransportRFQs");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_FromId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_MaterialId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_ServiceId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_StatusId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_ToId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_TransportId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "NumberOfPackages",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "PackageDimention",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "RequestDeliveryDate",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "ShipmentReadyDate",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "SpecialRequirements",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "TransportRFQs");
        }
    }
}
