using Microsoft.EntityFrameworkCore.Migrations;

namespace TOPMS.Migrations
{
    public partial class AddAreaOfServiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaOfService",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOfService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAreaOfService",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: false),
                    AreaOfServiceId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAreaOfService", x => new { x.CompanyId, x.AreaOfServiceId });
                    table.ForeignKey(
                        name: "FK_CompanyAreaOfService_AreaOfService_AreaOfServiceId",
                        column: x => x.AreaOfServiceId,
                        principalTable: "AreaOfService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAreaOfService_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAreaOfService_AreaOfServiceId",
                table: "CompanyAreaOfService",
                column: "AreaOfServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAreaOfService");

            migrationBuilder.DropTable(
                name: "AreaOfService");
        }
    }
}
