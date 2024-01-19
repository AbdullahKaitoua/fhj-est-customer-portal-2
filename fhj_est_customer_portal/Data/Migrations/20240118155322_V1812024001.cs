using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fhj_est_customer_portal.Migrations
{
    /// <inheritdoc />
    public partial class V1812024001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargingPoints",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PowerType = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    MaxPower = table.Column<int>(type: "int", nullable: true),
                    PlugTypes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: true),
                    ChargingStationId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingPoints", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ChargingPoints_ChargingStations_ChargingStationId",
                        column: x => x.ChargingStationId,
                        principalTable: "ChargingStations",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPoints_ChargingStationId",
                table: "ChargingPoints",
                column: "ChargingStationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargingPoints");
        }
    }
}
