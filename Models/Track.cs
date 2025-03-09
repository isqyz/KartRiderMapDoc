namespace KartRiderMapDoc.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string? Lev { get; set; }
        public int Star { get; set; }
        public string? TrackName { get; set; }
        public ICollection<TrackScoreMark>? TrackScores { get; set; }
        public ICollection<PlayerTrackAchievement>? PlayerTrackAchievements { get; set; }
        //public Dictionary<ScoreLev, double>? ScoreMark { get; set; }//赛道实力分级
    }


}
