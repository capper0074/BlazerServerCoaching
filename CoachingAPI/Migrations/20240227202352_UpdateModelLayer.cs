using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class UpdateModelLayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinnerTeamName",
                table: "Match");

            migrationBuilder.DropTable(
                name: "PlayerMapStatistics");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");

            migrationBuilder.RenameColumn(
                name: "WinnerTeamName",
                table: "Match",
                newName: "FK_WinnerTeamName");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WinnerTeamName",
                table: "Match",
                newName: "IX_Match_FK_WinnerTeamName");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_GeneralStatsId",
                table: "Team",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FK_GeneralStatsId",
                table: "Player",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneralStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_GeneralStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPerformanceStats",
                columns: table => new
                {
                    FK_PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<double>(type: "float", nullable: false),
                    KRRatio = table.Column<double>(type: "float", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPerformanceStats", x => new { x.FK_PlayerId, x.FK_MatchId });
                    table.ForeignKey(
                        name: "FK_PlayerPerformanceStats_Match_FK_MatchId",
                        column: x => x.FK_MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPerformanceStats_Player_FK_PlayerId",
                        column: x => x.FK_PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPerformanceStats",
                columns: table => new
                {
                    FK_TeamName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FK_MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<double>(type: "float", nullable: false),
                    KRRatio = table.Column<double>(type: "float", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false),
                    TRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TRoundsWon = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundWon = table.Column<int>(type: "int", nullable: false),
                    CTRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CTRoundsWon = table.Column<int>(type: "int", nullable: false),
                    CTPistolRoundWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPerformanceStats", x => new { x.FK_TeamName, x.FK_MatchId });
                    table.ForeignKey(
                        name: "FK_TeamPerformanceStats_Match_FK_MatchId",
                        column: x => x.FK_MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPerformanceStats_Team_FK_TeamName",
                        column: x => x.FK_TeamName,
                        principalTable: "Team",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapStats",
                columns: table => new
                {
                    FK_GeneralStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_MapName = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_MapStats", x => new { x.FK_GeneralStatsId, x.FK_MapName });
                    table.ForeignKey(
                        name: "FK_MapStats_GeneralStats_FK_GeneralStatsId",
                        column: x => x.FK_GeneralStatsId,
                        principalTable: "GeneralStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapStats_Map_FK_MapName",
                        column: x => x.FK_MapName,
                        principalTable: "Map",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_FK_GeneralStatsId",
                table: "Team",
                column: "FK_GeneralStatsId",
                unique: true,
                filter: "[FK_GeneralStatsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Player_FK_GeneralStatsId",
                table: "Player",
                column: "FK_GeneralStatsId",
                unique: true,
                filter: "[FK_GeneralStatsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MapStats_FK_MapName",
                table: "MapStats",
                column: "FK_MapName");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerformanceStats_FK_MatchId",
                table: "PlayerPerformanceStats",
                column: "FK_MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPerformanceStats_FK_MatchId",
                table: "TeamPerformanceStats",
                column: "FK_MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_FK_WinnerTeamName",
                table: "Match",
                column: "FK_WinnerTeamName",
                principalTable: "Team",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_GeneralStats_FK_GeneralStatsId",
                table: "Player",
                column: "FK_GeneralStatsId",
                principalTable: "GeneralStats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_GeneralStats_FK_GeneralStatsId",
                table: "Team",
                column: "FK_GeneralStatsId",
                principalTable: "GeneralStats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_FK_WinnerTeamName",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_GeneralStats_FK_GeneralStatsId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_GeneralStats_FK_GeneralStatsId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "MapStats");

            migrationBuilder.DropTable(
                name: "PlayerPerformanceStats");

            migrationBuilder.DropTable(
                name: "TeamPerformanceStats");

            migrationBuilder.DropTable(
                name: "GeneralStats");

            migrationBuilder.DropIndex(
                name: "IX_Team_FK_GeneralStatsId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Player_FK_GeneralStatsId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "FK_GeneralStatsId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FK_GeneralStatsId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "FK_WinnerTeamName",
                table: "Match",
                newName: "WinnerTeamName");

            migrationBuilder.RenameIndex(
                name: "IX_Match_FK_WinnerTeamName",
                table: "Match",
                newName: "IX_Match_WinnerTeamName");

            migrationBuilder.CreateTable(
                name: "PlayerStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<int>(type: "int", nullable: false),
                    KRRatio = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMapStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MapName = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsLost = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsWon = table.Column<int>(type: "int", nullable: false),
                    CtRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundsLost = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundsWins = table.Column<int>(type: "int", nullable: false),
                    TRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TotalRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMapStatistics", x => new { x.PlayerId, x.MapName });
                    table.ForeignKey(
                        name: "FK_PlayerMapStatistics_Map_MapName",
                        column: x => x.MapName,
                        principalTable: "Map",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMapStatistics_PlayerStatistics_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerStatistics",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMapStatistics_MapName",
                table: "PlayerMapStatistics",
                column: "MapName");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinnerTeamName",
                table: "Match",
                column: "WinnerTeamName",
                principalTable: "Team",
                principalColumn: "Name");
        }
    }
}
