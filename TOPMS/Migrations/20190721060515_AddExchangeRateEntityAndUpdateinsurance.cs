using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class AddExchangeRateEntityAndUpdateinsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuranceId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Insurances",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Insurances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderAmount",
                table: "Insurances",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SendToEmail",
                table: "Insurances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_InsuranceId",
                table: "TransportRFQs",
                column: "InsuranceId",
                unique: true,
                filter: "[InsuranceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Insurances_InsuranceId",
                table: "TransportRFQs",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Insurances_InsuranceId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_InsuranceId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "OrderAmount",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "SendToEmail",
                table: "Insurances");
        }
    }
}
