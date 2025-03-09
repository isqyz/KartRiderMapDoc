using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartRiderMapDoc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: true),
                    Score = table.Column<double>(type: "REAL", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lev = table.Column<string>(type: "TEXT", nullable: true),
                    Star = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerScores");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
