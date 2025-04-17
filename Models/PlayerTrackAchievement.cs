using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KartRiderMapDoc.Models
{
    public class PlayerTrackAchievement
    {
        [Key]
        public int Id { get; set; }  // 唯一标识

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }

        [ForeignKey("Achievement")]
        public int AchievementId { get; set; }
        public DateTime AchievedAt { get; set; }  // 成就达成时间
        public bool IsUnlocked { get; set; }  // 是否已解锁

        // 导航属性
        public Player? Player { get; set; }
        public Track? Track { get; set; }
        public Achievement? Achievement { get; set; }
    }
}