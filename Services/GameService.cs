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
        internal IEnumerable<Player> GetAllPlayerScores()
        {
            return _context.PlayerScores;
        }
        internal int AddPlayer(Player player)
        {
            var existingPlayer = GetAllPlayerScores().FirstOrDefault(p => p.PlayerName == player.PlayerName);
            if (existingPlayer != null)
            {
                // 更新成绩
                existingPlayer.Score = player.Score;
            }
            else
            {
                // 添加新玩家成绩
                _context.PlayerScores.Add(player);
            }
            return _context.SaveChanges();
            //dotnet ef database update
                //dotnet ef migrations add InitialCreated
        }

        internal void AddTrack(Track track)
        {
            var existingTrack = GetAllTrack().FirstOrDefault(t => t.TrackName == track.TrackName);
            if (existingTrack != null)
            {
                existingTrack = track;
            }
            else
            {
                _context.Tracks.Add(track);
            }
            _context.SaveChanges();
        }
    }
}
