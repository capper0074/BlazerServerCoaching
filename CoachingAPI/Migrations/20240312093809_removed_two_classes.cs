using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    public partial class removed_two_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_GeneralStats_FK_GeneralStatsId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_GeneralStats_FK_GeneralStatsId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "MapStats");

            migrationBuilder.DropTable(
                name: "GeneralStats");

            migrationBuilder.DropIndex(
                name: "IX_Team_FK_GeneralStatsId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_PlayerPerformanceStats_FK_MatchId",
                table: "PlayerPerformanceStats");

            migrationBuilder.DropIndex(
                name: "IX_Player_FK_GeneralStatsId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Assists",
                table: "TeamPerformanceStats");

            migrationBuilder.DropColumn(
                name: "Deaths",
                table: "TeamPerformanceStats");

            migrationBuilder.DropColumn(
                name: "Kills",
                table: "TeamPerformanceStats");

            migrationBuilder.DropColumn(
                name: "FK_GeneralStatsId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FK_GeneralStatsId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "TRoundsWon",
                table: "TeamPerformanceStats",
                newName: "TRoundsWins");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_TeamMatchStats_TeamId",
                table: "PlayerPerformanceStats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "FK_MapName",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPerformanceStats_FK_MatchId_FK_TeamMatchStats_TeamId",
                table: "PlayerPerformanceStats",
                columns: new[] { "FK_MatchId", "FK_TeamMatchStats_TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_Match_FK_MapName",
                table: "Match",
                column: "FK_MapName");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Map_FK_MapName",
                table: "Match",
                column: "FK_MapName",
                principalTable: "Map",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPerformanceStats_TeamPerformanceStats_FK_MatchId_FK_TeamMatchStats_TeamId",
                table: "PlayerPerformanceStats",
                columns: new[] { "FK_MatchId", "FK_TeamMatchStats_TeamId" },
                principalTable: "TeamPerformanceStats",
                principalColumns: new[] { "FK_TeamId", "FK_MatchId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Map_FK_MapName",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPerformanceStats_TeamPerformanceStats_FK_MatchId_FK_TeamMatchStats_TeamId",
                table: "PlayerPerformanceStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerPerformanceStats_FK_MatchId_FK_TeamMatchStats_TeamId",
                table: "PlayerPerformanceStats");

            migrationBuilder.DropIndex(
                name: "IX_Match_FK_MapName",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "FK_TeamMatchStats_TeamId",
                table: "PlayerPerformanceStats");

            migrationBuilder.DropColumn(
                name: "FK_MapName",
                table: "Match");

            migrationBuilder.RenameColumn(
                name: "TRoundsWins",
                table: "TeamPerformanceStats",
                newName: "TRoundsWon");

            migrationBuilder.AddColumn<int>(
                name: "Assists",
                table: "TeamPerformanceStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Deaths",
                table: "TeamPerformanceStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kills",
                table: "TeamPerformanceStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                    table.PrimaryKey("PK_GeneralStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapStats",
                columns: table => new
                {
                    FK_GeneralStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_MapName = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: true),
                    CtPistolRoundsLost = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    CtPistolRoundsWon = table.Column<int>(type: "int", nullable: false),
                    CtRoundsPlayed = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: true),
                    Kills = table.Column<int>(type: "int", nullable: true),
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
                name: "IX_PlayerPerformanceStats_FK_MatchId",
                table: "PlayerPerformanceStats",
                column: "FK_MatchId");

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
    }
}
