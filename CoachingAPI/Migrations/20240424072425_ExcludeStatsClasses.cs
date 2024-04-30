using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExcludeStatsClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStats_TeamMatchStats_TeamId_MatchId",
                table: "PlayerMatchStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerMatchStats_TeamId_MatchId",
                table: "PlayerMatchStats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStats_TeamId_MatchId",
                table: "PlayerMatchStats",
                columns: new[] { "TeamId", "MatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStats_TeamMatchStats_TeamId_MatchId",
                table: "PlayerMatchStats",
                columns: new[] { "TeamId", "MatchId" },
                principalTable: "TeamMatchStats",
                principalColumns: new[] { "TeamId", "MatchId" });
        }
    }
}
