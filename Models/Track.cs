using System.ComponentModel.DataAnnotations;

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

        public Dictionary<ScoreLev, double> ReadGradeLevel()
        {
            if (GradeLevelJsonStr != null)
            {
                var dic = System.Text.Json.JsonSerializer.Deserialize<Dictionary<ScoreLev, double>>(GradeLevelJsonStr);
                if (dic != null)
                {
                    return dic;
                }
            }
            return Enum.GetValues<ScoreLev>().ToDictionary(level => level, level => 0.0);
        }
        public void WriteGradeLevel(ref Dictionary<ScoreLev, double> keys)
        {
            GradeLevelJsonStr = System.Text.Json.JsonSerializer.Serialize(keys);
        }

        public void Append(ScoreLev lev,string value)
        {
            var dic = ReadGradeLevel();
            if(dic is not null)
            {
                dic[lev] = 1;
                WriteGradeLevel(ref dic);
            }
        }
        // 导航属性
        public ICollection<TrackScoreMark> TrackScores { get; set; } = [];
        public ICollection<PlayerTrackAchievement>? PlayerTrackAchievements { get; set; }

        public Track()
        {

        }
    }


}
