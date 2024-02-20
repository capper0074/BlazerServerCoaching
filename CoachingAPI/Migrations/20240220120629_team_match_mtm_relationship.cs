using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class team_match_mtm_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinnerName",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Match_MatchId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_MatchId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "WinnerName",
                table: "Match",
                newName: "WinnerTeamName");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WinnerName",
                table: "Match",
                newName: "IX_Match_WinnerTeamName");

            migrationBuilder.CreateTable(
                name: "MatchTeam",
                columns: table => new
                {
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTeam", x => new { x.MatchesId, x.TeamsName });
                    table.ForeignKey(
                        name: "FK_MatchTeam_Match_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchTeam_Team_TeamsName",
                        column: x => x.TeamsName,
                        principalTable: "Team",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeam_TeamsName",
                table: "MatchTeam",
                column: "TeamsName");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinnerTeamName",
                table: "Match",
                column: "WinnerTeamName",
                principalTable: "Team",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinnerTeamName",
                table: "Match");

            migrationBuilder.DropTable(
                name: "MatchTeam");

            migrationBuilder.RenameColumn(
                name: "WinnerTeamName",
                table: "Match",
                newName: "WinnerName");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WinnerTeamName",
                table: "Match",
                newName: "IX_Match_WinnerName");

            migrationBuilder.AddColumn<Guid>(
                name: "MatchId",
                table: "Team",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_MatchId",
                table: "Team",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinnerName",
                table: "Match",
                column: "WinnerName",
                principalTable: "Team",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Match_MatchId",
                table: "Team",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id");
        }
    }
}
