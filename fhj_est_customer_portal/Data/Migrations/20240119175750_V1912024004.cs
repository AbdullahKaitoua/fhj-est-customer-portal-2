using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fhj_est_customer_portal.Migrations
{
    /// <inheritdoc />
    public partial class V1912024004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargingProcesses",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterStart = table.Column<long>(type: "bigint", nullable: true),
                    MeterEnd = table.Column<long>(type: "bigint", nullable: true),
                    MeterTotal = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    Costs = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    ChargingCardId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ChargingPointId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingProcesses", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ChargingProcesses_ChargingCards_ChargingCardId",
                        column: x => x.ChargingCardId,
                        principalTable: "ChargingCards",
                        principalColumn: "CardId");
                    table.ForeignKey(
                        name: "FK_ChargingProcesses_ChargingPoints_ChargingPointId",
                        column: x => x.ChargingPointId,
                        principalTable: "ChargingPoints",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargingProcesses_ChargingCardId",
                table: "ChargingProcesses",
                column: "ChargingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingProcesses_ChargingPointId",
                table: "ChargingProcesses",
                column: "ChargingPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargingProcesses");
        }
    }
}
