namespace KartRiderMapDoc.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string? Lev { get; set; }
        public int Star { get; set; }
        public string? TrackName { get; set; }

        // 导航属性
        public ICollection<TrackScoreMark>? TrackScores { get; set; }
        public ICollection<PlayerTrackAchievement>? PlayerTrackAchievements { get; set; }
    }


}
