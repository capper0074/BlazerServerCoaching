using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMatchMaking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchPlatform = table.Column<int>(type: "int", nullable: false),
                    FKMapName = table.Column<int>(type: "int", nullable: false),
                    FKTeamWinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Map_FKMapName",
                        column: x => x.FKMapName,
                        principalTable: "Map",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Team_FKTeamWinnerId",
                        column: x => x.FKTeamWinnerId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    FKPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.FKPlayerId, x.FKTeamId });
                    table.ForeignKey(
                        name: "FK_Membership_Player_FKPlayerId",
                        column: x => x.FKPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Team_FKTeamId",
                        column: x => x.FKTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchTeam",
                columns: table => new
                {
                    MatchesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTeam", x => new { x.MatchesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_MatchTeam_Match_MatchesId",
                        column: x => x.MatchesId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchTeam_Team_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMatchStats",
                columns: table => new
                {
                    FKTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKMatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    TRoundsWins = table.Column<int>(type: "int", nullable: false),
                    TPistolRoundWon = table.Column<int>(type: "int", nullable: false),
                    CTRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CTRoundsWon = table.Column<int>(type: "int", nullable: false),
                    CTPistolRoundWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMatchStats", x => new { x.FKTeamId, x.FKMatchId });
                    table.ForeignKey(
                        name: "FK_TeamMatchStats_Match_FKMatchId",
                        column: x => x.FKMatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMatchStats_Team_FKTeamId",
                        column: x => x.FKTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatchStats",
                columns: table => new
                {
                    FKPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKMatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    KDRatio = table.Column<double>(type: "float", nullable: false),
                    KRRatio = table.Column<double>(type: "float", nullable: false),
                    Headshots = table.Column<int>(type: "int", nullable: false),
                    FKTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchStats", x => new { x.FKPlayerId, x.FKMatchId });
                    table.ForeignKey(
                        name: "FK_PlayerMatchStats_Match_FKMatchId",
                        column: x => x.FKMatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatchStats_Player_FKPlayerId",
                        column: x => x.FKPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatchStats_TeamMatchStats_FKTeamId_FKMatchId",
                        columns: x => new { x.FKTeamId, x.FKMatchId },
                        principalTable: "TeamMatchStats",
                        principalColumns: new[] { "FKTeamId", "FKMatchId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_FKMapName",
                table: "Match",
                column: "FKMapName");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FKTeamWinnerId",
                table: "Match",
                column: "FKTeamWinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTeam_TeamsId",
                table: "MatchTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_FKTeamId",
                table: "Membership",
                column: "FKTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStats_FKMatchId",
                table: "PlayerMatchStats",
                column: "FKMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStats_FKTeamId_FKMatchId",
                table: "PlayerMatchStats",
                columns: new[] { "FKTeamId", "FKMatchId" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchStats_FKMatchId",
                table: "TeamMatchStats",
                column: "FKMatchId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchTeam");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "PlayerMatchStats");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "TeamMatchStats");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
