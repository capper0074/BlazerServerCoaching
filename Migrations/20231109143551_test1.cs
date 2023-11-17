using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazerServerCoaching.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Oppenent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maps = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TSideW = table.Column<int>(type: "int", nullable: false),
                    TSideL = table.Column<int>(type: "int", nullable: false),
                    CTSideW = table.Column<int>(type: "int", nullable: false),
                    CTSideL = table.Column<int>(type: "int", nullable: false),
                    TPistol = table.Column<bool>(type: "bit", nullable: false),
                    CTPistol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matchs");
        }
    }
}
