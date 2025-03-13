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
        internal int AddOrUpdate(Player player)
        {
            _context.PlayerScores.Add(player);
            return _context.SaveChanges();
            //dotnet ef database update
                //dotnet ef migrations add InitialCreated
        }
    }
}
