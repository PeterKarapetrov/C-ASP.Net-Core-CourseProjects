using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class DeleteBehaviorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_AppUserId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Services_ServiceId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Status_StatusId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Transports_TransportId",
                table: "TransportRFQs");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_AppUserId",
                table: "TransportRFQs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Services_ServiceId",
                table: "TransportRFQs",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Status_StatusId",
                table: "TransportRFQs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Transports_TransportId",
                table: "TransportRFQs",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_AppUserId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Services_ServiceId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Status_StatusId",
                table: "TransportRFQs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Transports_TransportId",
                table: "TransportRFQs");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_AppUserId",
                table: "TransportRFQs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
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
                name: "FK_TransportRFQs_Transports_TransportId",
                table: "TransportRFQs",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
