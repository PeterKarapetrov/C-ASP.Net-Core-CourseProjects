using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class UpdateOfferAndOrderEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "TransportRFQs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliverTill",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadingDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "OrderAmount",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Offers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Offers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTime",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoadingTime",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOffered",
                table: "Offers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TransportRFQId",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTill",
                table: "Offers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TransportRFQs_OrderId",
                table: "TransportRFQs",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TransportRFQId",
                table: "Offers",
                column: "TransportRFQId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_TransportRFQs_TransportRFQId",
                table: "Offers",
                column: "TransportRFQId",
                principalTable: "TransportRFQs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRFQs_Orders_OrderId",
                table: "TransportRFQs",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_TransportRFQs_TransportRFQId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRFQs_Orders_OrderId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_TransportRFQs_OrderId",
                table: "TransportRFQs");

            migrationBuilder.DropIndex(
                name: "IX_Offers_TransportRFQId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "TransportRFQs");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliverTill",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LoadingDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LoadingTime",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "PriceOffered",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "TransportRFQId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ValidTill",
                table: "Offers");
        }
    }
}
