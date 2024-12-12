using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModels.Migrations
{
    /// <inheritdoc />
    public partial class HallSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Hall",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hall_TheaterId",
                table: "Hall",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Theaters_TheaterId",
                table: "Hall",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "TheaterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Theaters_TheaterId",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Hall_TheaterId",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Hall");
        }
    }
}
