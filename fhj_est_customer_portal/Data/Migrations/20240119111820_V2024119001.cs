using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fhj_est_customer_portal.Migrations
{
    /// <inheritdoc />
    public partial class V2024119001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargingCards",
                columns: table => new
                {
                    CardId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingCards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "LocationChargingCards",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChargingCardId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationChargingCards", x => new { x.LocationId, x.ChargingCardId });
                    table.ForeignKey(
                        name: "FK_LocationChargingCards_ChargingCards_ChargingCardId",
                        column: x => x.ChargingCardId,
                        principalTable: "ChargingCards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationChargingCards_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationChargingCards_ChargingCardId",
                table: "LocationChargingCards",
                column: "ChargingCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationChargingCards");

            migrationBuilder.DropTable(
                name: "ChargingCards");
        }
    }
}
