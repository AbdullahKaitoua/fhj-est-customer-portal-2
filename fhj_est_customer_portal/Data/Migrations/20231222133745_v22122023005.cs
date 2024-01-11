using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fhj_est_customer_portal.Migrations
{
    /// <inheritdoc />
    public partial class v22122023005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingStations_AspNetUsers_UserId",
                table: "ChargingStations");

            migrationBuilder.DropIndex(
                name: "IX_ChargingStations_UserId",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChargingStations");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "ChargingStations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingStations_LocationId",
                table: "ChargingStations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingStations_Locations_LocationId",
                table: "ChargingStations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingStations_Locations_LocationId",
                table: "ChargingStations");

            migrationBuilder.DropIndex(
                name: "IX_ChargingStations_LocationId",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "ChargingStations");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ChargingStations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargingStations_UserId",
                table: "ChargingStations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingStations_AspNetUsers_UserId",
                table: "ChargingStations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
