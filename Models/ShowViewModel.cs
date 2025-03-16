namespace KartRiderMapDoc.Models
{
    public class ShowViewModel
    {
        public IEnumerable<Track> Tracks { get; set; } = [];
        public IEnumerable<Player> Players { get; set; } = [];
        
        public string TrackName { get; set; } = string.Empty;
        public List<string> PlayerNames { get; set; } = [];
        public List<string> Scores { get; set; } = []; 
        public List<byte> Levs { get; set; } = [];
    }
}
