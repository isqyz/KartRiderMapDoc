using KartRiderMapDoc.Models;
using Microsoft.EntityFrameworkCore;

namespace KartRiderMapDoc.Db
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // 如果有需要, 可以在这里配置数据库连接字符串等
        public DbSet<Player>  PlayerScores { get; set; }
        public DbSet<Track>  Tracks { get; set; }
        public DbSet<Achievement> Achievements{ get; set; }
        public DbSet<PlayerTrackAchievement>  PlayerTrackAchievements { get; set; }
        public DbSet<TrackScoreMark>  TrackScoreMarks { get; set; }
    }
}
