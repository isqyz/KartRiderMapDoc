using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartRiderMapDoc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlayerScores",
                newName: "PlayerId");

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.AchievementId);
                });

            migrationBuilder.CreateTable(
                name: "TrackScoreMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackScoreMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackScoreMark_PlayerScores_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerScores",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackScoreMark_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTrackAchievement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false),
                    AchievementId = table.Column<int>(type: "INTEGER", nullable: false),
                    AchievedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsUnlocked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTrackAchievement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTrackAchievement_Achievement_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievement",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTrackAchievement_PlayerScores_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerScores",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTrackAchievement_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTrackAchievement_AchievementId",
                table: "PlayerTrackAchievement",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTrackAchievement_PlayerId",
                table: "PlayerTrackAchievement",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTrackAchievement_TrackId",
                table: "PlayerTrackAchievement",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackScoreMark_PlayerId",
                table: "TrackScoreMark",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackScoreMark_TrackId",
                table: "TrackScoreMark",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTrackAchievement");

            migrationBuilder.DropTable(
                name: "TrackScoreMark");

            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "PlayerScores",
                newName: "Id");
        }
    }
}
