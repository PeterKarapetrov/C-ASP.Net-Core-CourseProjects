using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class UpdateValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "TransportRFQs",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
