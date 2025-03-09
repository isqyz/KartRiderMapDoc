namespace KartRiderMapDoc.Models
{
    public class ShowViewModel
    {
        public IEnumerable<Track> Tracks { get; set; } = [];
        public IEnumerable<Player> PlayerScores { get; set; } = [];
    }
}
