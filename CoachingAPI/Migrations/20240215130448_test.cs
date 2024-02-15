using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class test : Migration
    {
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
                name: "PlayerStats",
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
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchPlatform = table.Column<int>(type: "int", nullable: false),
                    WinnerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCoach = table.Column<bool>(type: "bit", nullable: false),
                    StatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeamName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_PlayerStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "PlayerStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMapStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    TPistolRoundsLost = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMapStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMapStats_Map_MapName",
                        column: x => x.MapName,
                        principalTable: "Map",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMapStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeamHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeamHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTeamHistory_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
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
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Teams_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Player_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_PlayerId",
                table: "Match",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_WinnerID",
                table: "Match",
                column: "WinnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_StatsId",
                table: "Player",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamName",
                table: "Player",
                column: "TeamName");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamName1",
                table: "Player",
                column: "TeamName1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMapStats_MapName",
                table: "PlayerMapStats",
                column: "MapName");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMapStats_PlayerId",
                table: "PlayerMapStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeamHistory_PlayerId",
                table: "PlayerTeamHistory",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MatchId",
                table: "Teams",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Player_PlayerId",
                table: "Match",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_WinnerID",
                table: "Match",
                column: "WinnerID",
                principalTable: "Teams",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamName",
                table: "Player",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Teams_TeamName1",
                table: "Player",
                column: "TeamName1",
                principalTable: "Teams",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Player_PlayerId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Player_CoachId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_WinnerID",
                table: "Match");

            migrationBuilder.DropTable(
                name: "PlayerMapStats");

            migrationBuilder.DropTable(
                name: "PlayerTeamHistory");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Match");
        }
    }
}
