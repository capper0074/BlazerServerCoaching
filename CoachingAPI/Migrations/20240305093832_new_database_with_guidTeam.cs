using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class new_database_with_guidTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Map",
                columns: table => new
                {
                    Name = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCoach = table.Column<bool>(type: "bit", nullable: false),
                    FK_GeneralStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_GeneralStats_FK_GeneralStatsId",
                        column: x => x.FK_GeneralStatsId,
                        principalTable: "GeneralStats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMatchMaking = table.Column<bool>(type: "bit", nullable: false),
                    FK_GeneralStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_GeneralStats_FK_GeneralStatsId",
                        column: x => x.FK_GeneralStatsId,
                        principalTable: "GeneralStats",
                        principalColumn: "Id");
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
                    Kills = table.Column<int>(type: "int", nullable: true),
                    Deaths = table.Column<int>(type: "int", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchPlatform = table.Column<int>(type: "int", nullable: false),
                    FK_WinnerTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_Team_FK_WinnerTeamId",
                        column: x => x.FK_WinnerTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MembershipType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_Membership_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchTeam",
                columns: table => new
                {
                    MatchesMatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTeam", x => new { x.MatchesMatchId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_MatchTeam_Match_MatchesMatchId",
                        column: x => x.MatchesMatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchTeam_Team_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPerformanceStats",
                columns: table => new
                {
                    FK_PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<double>(type: "float", nullable: false),
                    KRRatio = table.Column<double>(type: "float", nullable: false),
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
                    FK_TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    TRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TRoundsWon = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundWon = table.Column<int>(type: "int", nullable: false),
                    CTRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CTRoundsWon = table.Column<int>(type: "int", nullable: false),
                    CTPistolRoundWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPerformanceStats", x => new { x.FK_TeamId, x.FK_MatchId });
                    table.ForeignKey(
                        name: "FK_TeamPerformanceStats_Match_FK_MatchId",
                        column: x => x.FK_MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPerformanceStats_Team_FK_TeamId",
                        column: x => x.FK_TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapStats_FK_MapName",
                table: "MapStats",
                column: "FK_MapName");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FK_WinnerTeamId",
                table: "Match",
                column: "FK_WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeam_TeamsId",
                table: "MatchTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_TeamId",
                table: "Membership",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_FK_GeneralStatsId",
                table: "Player",
                column: "FK_GeneralStatsId",
                unique: true,
                filter: "[FK_GeneralStatsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerformanceStats_FK_MatchId",
                table: "PlayerPerformanceStats",
                column: "FK_MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_FK_GeneralStatsId",
                table: "Team",
                column: "FK_GeneralStatsId",
                unique: true,
                filter: "[FK_GeneralStatsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPerformanceStats_FK_MatchId",
                table: "TeamPerformanceStats",
                column: "FK_MatchId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapStats");

            migrationBuilder.DropTable(
                name: "MatchTeam");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "PlayerPerformanceStats");

            migrationBuilder.DropTable(
                name: "TeamPerformanceStats");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "GeneralStats");
        }
    }
}
