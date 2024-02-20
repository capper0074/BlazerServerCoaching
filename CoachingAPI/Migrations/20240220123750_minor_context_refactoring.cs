using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class minor_context_refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchTeam_Match_MatchesId",
                table: "MatchTeam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Player",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "MatchesId",
                table: "MatchTeam",
                newName: "MatchesMatchId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Match",
                newName: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchTeam_Match_MatchesMatchId",
                table: "MatchTeam",
                column: "MatchesMatchId",
                principalTable: "Match",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchTeam_Match_MatchesMatchId",
                table: "MatchTeam");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Player",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MatchesMatchId",
                table: "MatchTeam",
                newName: "MatchesId");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Match",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchTeam_Match_MatchesId",
                table: "MatchTeam",
                column: "MatchesId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
