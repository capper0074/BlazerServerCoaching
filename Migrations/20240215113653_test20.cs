using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazerServerCoaching.Migrations
{
    /// <inheritdoc />
    public partial class test20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    Player_1Id = table.Column<int>(type: "int", nullable: true),
                    Player_2Id = table.Column<int>(type: "int", nullable: true),
                    Player_3Id = table.Column<int>(type: "int", nullable: true),
                    Player_4Id = table.Column<int>(type: "int", nullable: true),
                    Player_5Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Users_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_Player_1Id",
                        column: x => x.Player_1Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_Player_2Id",
                        column: x => x.Player_2Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_Player_3Id",
                        column: x => x.Player_3Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_Player_4Id",
                        column: x => x.Player_4Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Users_Player_5Id",
                        column: x => x.Player_5Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player_1Id",
                table: "Teams",
                column: "Player_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player_2Id",
                table: "Teams",
                column: "Player_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player_3Id",
                table: "Teams",
                column: "Player_3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player_4Id",
                table: "Teams",
                column: "Player_4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player_5Id",
                table: "Teams",
                column: "Player_5Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
