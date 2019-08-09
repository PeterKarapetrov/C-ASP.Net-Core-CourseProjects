using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class AddWeightToTransportRFQEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Materials_MaterialId",
                table: "TransportRFQs");

            migrationBuilder.AddColumn<int>(
                name: "Packaging",
                table: "TransportRFQs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "TransportRFQs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Materials_MaterialId",
                table: "TransportRFQs",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Materials_MaterialId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "Packaging",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "TransportRFQs");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Materials_MaterialId",
                table: "TransportRFQs",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
