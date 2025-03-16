using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartRiderMapDoc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated8885 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievements_PlayerScores_PlayerId",
                table: "PlayerTrackAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackScoreMarks_PlayerScores_PlayerId",
                table: "TrackScoreMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerScores",
                table: "PlayerScores");

            migrationBuilder.RenameTable(
                name: "PlayerScores",
                newName: "Player");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievements_Player_PlayerId",
                table: "PlayerTrackAchievements",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackScoreMarks_Player_PlayerId",
                table: "TrackScoreMarks",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievements_Player_PlayerId",
                table: "PlayerTrackAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackScoreMarks_Player_PlayerId",
                table: "TrackScoreMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "PlayerScores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerScores",
                table: "PlayerScores",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievements_PlayerScores_PlayerId",
                table: "PlayerTrackAchievements",
                column: "PlayerId",
                principalTable: "PlayerScores",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackScoreMarks_PlayerScores_PlayerId",
                table: "TrackScoreMarks",
                column: "PlayerId",
                principalTable: "PlayerScores",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
