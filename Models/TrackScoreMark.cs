using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartRiderMapDoc.Models
{
    public class TrackScoreMark
    {
        [Key]
        public int Id { get; set; }  // 可以用复合键（见方案 2），这里简单化

        [ForeignKey("Player")]
        public int PlayerId { get; set; }  // 选手外键

        [ForeignKey("Track")]
        public int TrackId { get; set; }  // 赛道外键

        public double Score { get; set; }  // 选手在该赛道的分数

        // 导航属性
        public Player? Player { get; set; }
        public Track? Track { get; set; }
        public ScoreLev Get()
        {
            ScoreLev scoreLev = ScoreLev.None;
            //if (ScoreMark is not null)
            //    foreach (var item in ScoreMark)
            //    {
            //        if (Score <= item.Value)
            //        {
            //            scoreLev = item.Key;
            //        }
            //    }
            return scoreLev;
        }
    }
}
