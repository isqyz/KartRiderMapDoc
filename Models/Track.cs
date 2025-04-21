using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace KartRiderMapDoc.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        public string? Lev { get; set; }
        public int Star { get; set; }
        public string TrackName { get; set; } = "";

        public string GradeLevelJsonStr { get; set; } = System.Text.Json.JsonSerializer.Serialize(Enum.GetValues<ScoreLev>().ToDictionary(level => level, level => 0.0));


        public Dictionary<ScoreLev, string> ReadGradeLevel()
        {
            if (GradeLevelJsonStr != null)
            {
                var dic = System.Text.Json.JsonSerializer.Deserialize<Dictionary<ScoreLev, double>>(GradeLevelJsonStr);
                if (dic != null)
                {
                    return dic.ToDictionary(Lev=>Lev.Key,s=> ReadScore(s.Value));
                }
            } 
            return Enum.GetValues<ScoreLev>().ToDictionary(level => level, level => "0.0");
        }
        public void WriteGradeLevel(ref Dictionary<ScoreLev, double> keys)
        {
            GradeLevelJsonStr = System.Text.Json.JsonSerializer.Serialize(keys);
        }

        public void AppendGradeLevel(ScoreLev lev,string value)
        {
            var dic = ReadGradeLevel();
            if(dic is not null)
            {
                dic[lev] = value;
                var d = dic.ToDictionary(Lev => Lev.Key, s => ScoreToDouble(s.Value));
                WriteGradeLevel(ref d);
            }
        }
        // 导航属性
        public ICollection<TrackScoreMark> TrackScores { get; set; } = [];
        public ICollection<PlayerTrackAchievement>? PlayerTrackAchievements { get; set; }
        public static string ReadScore(double s)
        {
            TimeSpan ts = TimeSpan.FromSeconds(s);
            int minutes = (int)(s / 60);
            int seconds = ts.Seconds;
            int milliseconds = ts.Milliseconds;

            return $"{minutes}:{seconds}:{milliseconds}";
        }

        public static double ScoreToDouble(string score)
        {
            double Score = 0;
            var spl = score.Split(':');
            if (spl.Length == 3)
            {
                Score += (double.Parse(spl[0]) * 60);
                Score += (double.Parse(spl[1]));
                Score += (double.Parse(spl[2])) / 1000;
            }
            return Score;
        }
    }


}
