using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fhj_est_customer_portal.Migrations
{
    /// <inheritdoc />
    public partial class v21122023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingStations_AspNetUsers_UserId",
                table: "ChargingStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChargingStations",
                table: "ChargingStations");

            migrationBuilder.RenameTable(
                name: "ChargingStations",
                newName: "ChargingStation");

            migrationBuilder.RenameIndex(
                name: "IX_ChargingStations_UserId",
                table: "ChargingStation",
                newName: "IX_ChargingStation_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ChargingStation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChargingStation",
                table: "ChargingStation",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingStation_AspNetUsers_UserId",
                table: "ChargingStation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingStation_AspNetUsers_UserId",
                table: "ChargingStation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChargingStation",
                table: "ChargingStation");

            migrationBuilder.RenameTable(
                name: "ChargingStation",
                newName: "ChargingStations");

            migrationBuilder.RenameIndex(
                name: "IX_ChargingStation_UserId",
                table: "ChargingStations",
                newName: "IX_ChargingStations_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ChargingStations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChargingStations",
                table: "ChargingStations",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingStations_AspNetUsers_UserId",
                table: "ChargingStations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
