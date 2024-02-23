using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class PlayerID_moved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMapStatistics_Player_PlayerId",
                table: "PlayerMapStatistics");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMapStatistics_PlayerStatistics_PlayerId",
                table: "PlayerMapStatistics",
                column: "PlayerId",
                principalTable: "PlayerStatistics",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMapStatistics_PlayerStatistics_PlayerId",
                table: "PlayerMapStatistics");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMapStatistics_Player_PlayerId",
                table: "PlayerMapStatistics",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
