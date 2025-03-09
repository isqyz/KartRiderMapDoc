namespace KartRiderMapDoc.Models
{
    public class PlayerScore
    {
        public int Id {get; set; }
        public string? PlayerName { get; set; }
        public double Score { get; set; }
        public ScoreLev Level { get; set; }
        public string? TrackName { get; set; }
    }


}
