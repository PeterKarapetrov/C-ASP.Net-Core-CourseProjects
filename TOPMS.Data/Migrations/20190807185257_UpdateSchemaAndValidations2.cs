using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class UpdateSchemaAndValidations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAreaOfServices_AreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAreaOfServices_Companies_CompanyId",
                table: "CompanyAreaOfServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTransports_Companies_CompanyId",
                table: "CompanyTransports");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTransports_Transports_TransportId",
                table: "CompanyTransports");

            migrationBuilder.AlterColumn<string>(
                name: "TransportId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ToId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MaterialId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FromId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "TransportRFQs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TransportRFQId",
                table: "Offers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Offers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Insurances",
                nullable: true,
                oldClrType: typeof(string));

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTransports_Companies_CompanyId",
                table: "CompanyTransports",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTransports_Transports_TransportId",
                table: "CompanyTransports",
                column: "TransportId",
                principalTable: "Transports",
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

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTransports_Companies_CompanyId",
                table: "CompanyTransports");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTransports_Transports_TransportId",
                table: "CompanyTransports");

            migrationBuilder.AlterColumn<string>(
                name: "TransportId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransportRFQId",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Insurances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAreaOfServices_AreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfServices",
                column: "AreaOfServiceId",
                principalTable: "AreaOfService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAreaOfServices_Companies_CompanyId",
                table: "CompanyAreaOfServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTransports_Companies_CompanyId",
                table: "CompanyTransports",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTransports_Transports_TransportId",
                table: "CompanyTransports",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
