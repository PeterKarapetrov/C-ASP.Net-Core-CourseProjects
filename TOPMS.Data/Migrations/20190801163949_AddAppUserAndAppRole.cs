using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class AddAppUserAndAppRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_AspNetUsers_UserId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_UserId",
                table: "TransportRFQs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TransportRFQs",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TransportRFQs_UserId",
                table: "TransportRFQs",
                newName: "IX_TransportRFQs_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Offers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                newName: "IX_Offers_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Insurances",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_UserId",
                table: "Insurances",
                newName: "IX_Insurances_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_AspNetUsers_AppUserId",
                table: "Insurances",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_AppUserId",
                table: "Offers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_AppUserId",
                table: "TransportRFQs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_AspNetUsers_AppUserId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_AppUserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_AppUserId",
                table: "TransportRFQs");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "TransportRFQs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TransportRFQs_AppUserId",
                table: "TransportRFQs",
                newName: "IX_TransportRFQs_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Offers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_AppUserId",
                table: "Offers",
                newName: "IX_Offers_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Insurances",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_AppUserId",
                table: "Insurances",
                newName: "IX_Insurances_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_AspNetUsers_UserId",
                table: "Insurances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_AspNetUsers_UserId",
                table: "TransportRFQs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
