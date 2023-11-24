using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazerServerCoaching.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opponent",
                table: "Matchs",
                newName: "Oppenent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Oppenent",
                table: "Matchs",
                newName: "Opponent");
        }
    }
}
