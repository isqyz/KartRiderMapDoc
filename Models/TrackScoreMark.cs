using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartRiderMapDoc.Models
{
    public class TrackScoreMark
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Track")]
        public int TrackId { get; set; }

        public double Score { get; set; }  // 选手在该赛道的分数

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string ReadScore()
        {
            TimeSpan ts = TimeSpan.FromSeconds(Score);
            int minutes = (int)(Score / 60);
            int seconds = ts.Seconds;       
            int milliseconds = ts.Milliseconds; 

            return $"{minutes}:{seconds}:{milliseconds}";
        }

        public void WriteScore(string score)
        {
            Score = 0;
            var spl = score.Split(':');
            if (spl.Length == 3)
            {
                Score += (double.Parse(spl[0]) * 60);
                Score += (double.Parse(spl[1]));
                Score += (double.Parse(spl[2])) / 1000;
            }
        }
        // 导航属性
        public Player? Player { get; set; }
        public Track? Track { get; set; }
        public ScoreLev GetLev()
        {
            ScoreLev scoreLev = ScoreLev.墙主;
            if (Track is not null)
                foreach (var item in Track.ReadGradeLevel())
                {
                    if (Score <= Track.ScoreToDouble(item.Value))
                    {
                        scoreLev = item.Key;
                        break;
                    }
                }
            return scoreLev;
        }
    }
}
