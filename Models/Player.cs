using System.ComponentModel.DataAnnotations;

namespace KartRiderMapDoc.Models
{
    public class Player
    {
        [Key]
        public int PlayerId {get; set; }
        public string PlayerName { get; set; } = "";
        public double Score { get; set; }
        //总体实力
        public ScoreLev Level { get; set; }
        //玩家赛道记录
        public ICollection<TrackScoreMark> TrackScores { get; set; } = [];
        public ICollection<PlayerTrackAchievement> PlayerTrackAchievements { get; set; } = [];
    }
}
