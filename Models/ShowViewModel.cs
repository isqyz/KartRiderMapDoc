namespace KartRiderMapDoc.Models
{
    public class ShowViewModel
    {
        public IEnumerable<Track> Tracks { get; set; } = [];
        public IEnumerable<PlayerScore> PlayerScores { get; set; } = [];
    }
}
