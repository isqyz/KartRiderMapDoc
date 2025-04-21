using System.ComponentModel.DataAnnotations;

namespace KartRiderMapDoc.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }
        public string? Name { get; set; }  // 成就名称
        public string? Description { get; set; }  // 详细描述
        public ICollection<PlayerTrackAchievement>? PlayerTrackAchievements { get; set; }

    }
    public enum ScoreLev
    {
        主力,
        一线,
        二线,
        三线,
        娱乐,
        墙主,
    }
    public enum TrackLev
    {
        R,
        L3,
        L2,
        L1
    }
}
