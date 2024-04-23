using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingAPI.Migrations
{
    /// <inheritdoc />
    public partial class CompositeIndexing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStat_Match_MatchId",
                table: "PlayerMatchStat");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStat_Player_PlayerId",
                table: "PlayerMatchStat");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStat_TeamMatchStat_TeamId_MatchId",
                table: "PlayerMatchStat");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchStat_Match_MatchId",
                table: "TeamMatchStat");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchStat_Team_TeamId",
                table: "TeamMatchStat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMatchStat",
                table: "TeamMatchStat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerMatchStat",
                table: "PlayerMatchStat");

            migrationBuilder.RenameTable(
                name: "TeamMatchStat",
                newName: "TeamMatchStats");

            migrationBuilder.RenameTable(
                name: "PlayerMatchStat",
                newName: "PlayerMatchStats");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMatchStat_MatchId",
                table: "TeamMatchStats",
                newName: "IX_TeamMatchStats_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMatchStat_TeamId_MatchId",
                table: "PlayerMatchStats",
                newName: "IX_PlayerMatchStats_TeamId_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMatchStat_MatchId",
                table: "PlayerMatchStats",
                newName: "IX_PlayerMatchStats_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMatchStats",
                table: "TeamMatchStats",
                columns: new[] { "TeamId", "MatchId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerMatchStats",
                table: "PlayerMatchStats",
                columns: new[] { "PlayerId", "MatchId" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatchStats_TeamId_MatchId",
                table: "TeamMatchStats",
                columns: new[] { "TeamId", "MatchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStats_PlayerId_MatchId",
                table: "PlayerMatchStats",
                columns: new[] { "PlayerId", "MatchId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStats_Match_MatchId",
                table: "PlayerMatchStats",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStats_Player_PlayerId",
                table: "PlayerMatchStats",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStats_TeamMatchStats_TeamId_MatchId",
                table: "PlayerMatchStats",
                columns: new[] { "TeamId", "MatchId" },
                principalTable: "TeamMatchStats",
                principalColumns: new[] { "TeamId", "MatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchStats_Match_MatchId",
                table: "TeamMatchStats",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchStats_Team_TeamId",
                table: "TeamMatchStats",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStats_Match_MatchId",
                table: "PlayerMatchStats");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStats_Player_PlayerId",
                table: "PlayerMatchStats");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchStats_TeamMatchStats_TeamId_MatchId",
                table: "PlayerMatchStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchStats_Match_MatchId",
                table: "TeamMatchStats");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMatchStats_Team_TeamId",
                table: "TeamMatchStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMatchStats",
                table: "TeamMatchStats");

            migrationBuilder.DropIndex(
                name: "IX_TeamMatchStats_TeamId_MatchId",
                table: "TeamMatchStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerMatchStats",
                table: "PlayerMatchStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerMatchStats_PlayerId_MatchId",
                table: "PlayerMatchStats");

            migrationBuilder.RenameTable(
                name: "TeamMatchStats",
                newName: "TeamMatchStat");

            migrationBuilder.RenameTable(
                name: "PlayerMatchStats",
                newName: "PlayerMatchStat");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMatchStats_MatchId",
                table: "TeamMatchStat",
                newName: "IX_TeamMatchStat_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMatchStats_TeamId_MatchId",
                table: "PlayerMatchStat",
                newName: "IX_PlayerMatchStat_TeamId_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMatchStats_MatchId",
                table: "PlayerMatchStat",
                newName: "IX_PlayerMatchStat_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMatchStat",
                table: "TeamMatchStat",
                columns: new[] { "TeamId", "MatchId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerMatchStat",
                table: "PlayerMatchStat",
                columns: new[] { "PlayerId", "MatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStat_Match_MatchId",
                table: "PlayerMatchStat",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStat_Player_PlayerId",
                table: "PlayerMatchStat",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchStat_TeamMatchStat_TeamId_MatchId",
                table: "PlayerMatchStat",
                columns: new[] { "TeamId", "MatchId" },
                principalTable: "TeamMatchStat",
                principalColumns: new[] { "TeamId", "MatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchStat_Match_MatchId",
                table: "TeamMatchStat",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMatchStat_Team_TeamId",
                table: "TeamMatchStat",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
