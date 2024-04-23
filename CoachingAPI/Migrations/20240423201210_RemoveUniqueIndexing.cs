using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueIndexing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMatchStats_MatchId",
                table: "TeamMatchStats");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchStats_MatchId",
                table: "TeamMatchStats",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMatchStats_MatchId",
                table: "TeamMatchStats");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchStats_MatchId",
                table: "TeamMatchStats",
                column: "MatchId",
                unique: true);
        }
    }
}
