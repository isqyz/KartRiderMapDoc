namespace KartRiderMapDoc.Models
{
    public class GradeLevel
    {
        public int Id { get; set; }
        public ScoreLev Level { get; set; }
        public double Score { get; set; }
        public int TrackId { get; set; }
        public Track? Track { get; set; }
    }
}
