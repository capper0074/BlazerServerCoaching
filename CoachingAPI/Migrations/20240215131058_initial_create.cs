using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Name = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchPlatform = table.Column<int>(type: "int", nullable: false),
                    WinnerName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMapStats",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MapName = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    TotalRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CtRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsWon = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsLost = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundsWins = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundsLost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMapStats", x => new { x.PlayerId, x.MapName });
                    table.ForeignKey(
                        name: "FK_PlayerMapStats_Maps_MapName",
                        column: x => x.MapName,
                        principalTable: "Maps",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCoach = table.Column<bool>(type: "bit", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<int>(type: "int", nullable: false),
                    KRRatio = table.Column<int>(type: "int", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false),
                    CurrentTeamName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<int>(type: "int", nullable: false),
                    KRRatio = table.Column<int>(type: "int", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsMatchMaking = table.Column<bool>(type: "bit", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Teams_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerId",
                table: "Matches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerName",
                table: "Matches",
                column: "WinnerName");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMapStats_MapName",
                table: "PlayerMapStats",
                column: "MapName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentTeamName",
                table: "Players",
                column: "CurrentTeamName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamName",
                table: "Players",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MatchId",
                table: "Teams",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerId",
                table: "Matches",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_WinnerName",
                table: "Matches",
                column: "WinnerName",
                principalTable: "Teams",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMapStats_Players_PlayerId",
                table: "PlayerMapStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_CurrentTeamName",
                table: "Players",
                column: "CurrentTeamName",
                principalTable: "Teams",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamName",
                table: "Players",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_CoachId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_WinnerName",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "PlayerMapStats");

            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
