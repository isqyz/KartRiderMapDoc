using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KartRiderMapDoc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated888 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievement_Achievement_AchievementId",
                table: "PlayerTrackAchievement");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievement_PlayerScores_PlayerId",
                table: "PlayerTrackAchievement");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievement_Tracks_TrackId",
                table: "PlayerTrackAchievement");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackScoreMark_PlayerScores_PlayerId",
                table: "TrackScoreMark");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackScoreMark_Tracks_TrackId",
                table: "TrackScoreMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackScoreMark",
                table: "TrackScoreMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTrackAchievement",
                table: "PlayerTrackAchievement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement");

            migrationBuilder.RenameTable(
                name: "TrackScoreMark",
                newName: "TrackScoreMarks");

            migrationBuilder.RenameTable(
                name: "PlayerTrackAchievement",
                newName: "PlayerTrackAchievements");

            migrationBuilder.RenameTable(
                name: "Achievement",
                newName: "Achievements");

            migrationBuilder.RenameIndex(
                name: "IX_TrackScoreMark_TrackId",
                table: "TrackScoreMarks",
                newName: "IX_TrackScoreMarks_TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackScoreMark_PlayerId",
                table: "TrackScoreMarks",
                newName: "IX_TrackScoreMarks_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTrackAchievement_TrackId",
                table: "PlayerTrackAchievements",
                newName: "IX_PlayerTrackAchievements_TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTrackAchievement_PlayerId",
                table: "PlayerTrackAchievements",
                newName: "IX_PlayerTrackAchievements_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTrackAchievement_AchievementId",
                table: "PlayerTrackAchievements",
                newName: "IX_PlayerTrackAchievements_AchievementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackScoreMarks",
                table: "TrackScoreMarks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTrackAchievements",
                table: "PlayerTrackAchievements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "AchievementId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievements_Achievements_AchievementId",
                table: "PlayerTrackAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "AchievementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievements_PlayerScores_PlayerId",
                table: "PlayerTrackAchievements",
                column: "PlayerId",
                principalTable: "PlayerScores",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievements_Tracks_TrackId",
                table: "PlayerTrackAchievements",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackScoreMarks_PlayerScores_PlayerId",
                table: "TrackScoreMarks",
                column: "PlayerId",
                principalTable: "PlayerScores",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackScoreMarks_Tracks_TrackId",
                table: "TrackScoreMarks",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievements_Achievements_AchievementId",
                table: "PlayerTrackAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievements_PlayerScores_PlayerId",
                table: "PlayerTrackAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTrackAchievements_Tracks_TrackId",
                table: "PlayerTrackAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackScoreMarks_PlayerScores_PlayerId",
                table: "TrackScoreMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackScoreMarks_Tracks_TrackId",
                table: "TrackScoreMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackScoreMarks",
                table: "TrackScoreMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTrackAchievements",
                table: "PlayerTrackAchievements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.RenameTable(
                name: "TrackScoreMarks",
                newName: "TrackScoreMark");

            migrationBuilder.RenameTable(
                name: "PlayerTrackAchievements",
                newName: "PlayerTrackAchievement");

            migrationBuilder.RenameTable(
                name: "Achievements",
                newName: "Achievement");

            migrationBuilder.RenameIndex(
                name: "IX_TrackScoreMarks_TrackId",
                table: "TrackScoreMark",
                newName: "IX_TrackScoreMark_TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackScoreMarks_PlayerId",
                table: "TrackScoreMark",
                newName: "IX_TrackScoreMark_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTrackAchievements_TrackId",
                table: "PlayerTrackAchievement",
                newName: "IX_PlayerTrackAchievement_TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTrackAchievements_PlayerId",
                table: "PlayerTrackAchievement",
                newName: "IX_PlayerTrackAchievement_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTrackAchievements_AchievementId",
                table: "PlayerTrackAchievement",
                newName: "IX_PlayerTrackAchievement_AchievementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackScoreMark",
                table: "TrackScoreMark",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTrackAchievement",
                table: "PlayerTrackAchievement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievement",
                table: "Achievement",
                column: "AchievementId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievement_Achievement_AchievementId",
                table: "PlayerTrackAchievement",
                column: "AchievementId",
                principalTable: "Achievement",
                principalColumn: "AchievementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievement_PlayerScores_PlayerId",
                table: "PlayerTrackAchievement",
                column: "PlayerId",
                principalTable: "PlayerScores",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTrackAchievement_Tracks_TrackId",
                table: "PlayerTrackAchievement",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackScoreMark_PlayerScores_PlayerId",
                table: "TrackScoreMark",
                column: "PlayerId",
                principalTable: "PlayerScores",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackScoreMark_Tracks_TrackId",
                table: "TrackScoreMark",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
