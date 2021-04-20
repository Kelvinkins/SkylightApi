using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class UpdateAuthDown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceResponses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceResponses",
                columns: table => new
                {
                    ServiceResponseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastRun = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Log = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceResponses", x => x.ServiceResponseID);
                });
        }
    }
}
