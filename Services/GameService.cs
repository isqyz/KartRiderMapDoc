using KartRiderMapDoc.Db;
using KartRiderMapDoc.Models;

namespace KartRiderMapDoc.Services
{
    public class GameService(AppDbContext context, ILogger<GameService> logger)
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger<GameService> _logger = logger;
        internal IEnumerable<Track> GetAllTrack()
        {
            return _context.Tracks;
        }
        internal IEnumerable<PlayerScore> GetAllPlayerScores()
        {
            return _context.PlayerScores;
        }
        internal bool AddOrUpdate(PlayerScore player)
        {
            return _context.PlayerScores.Add;
        }
    }
}
