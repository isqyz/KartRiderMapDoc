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
            var tracks = _context.Tracks;
            if (tracks != null)
            {
                context.Entry(tracks).Reference(ts => ts.Local).Load(); // 手动加载
            }
            return _context.Tracks;
        }
        internal IEnumerable<Player> GetAllPlayer()
        {
            return _context.Player;
        }
        internal IEnumerable<TrackScoreMark> GetTrackScoreMark()
        {
            return _context.TrackScoreMarks; 
        }
        internal int AddPlayer(string playerName, Player player)
        {
            //var existingPlayer = GetAllPlayer().FirstOrDefault(p => p.PlayerName == player.PlayerName);
            //if (existingPlayer != null)
            //{
            //    // 更新成绩
            //    existingPlayer.Score = player.Score;
            //}
            //else
            //{
            //    // 添加新玩家成绩
            //    _context.Player.Add(player);
            //}
            return 1;// _context.SaveChanges();
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


        internal void AddPlayer(string playerName, string score, int trackId)
        {
            Player? player = _context.Player.FirstOrDefault(p => p.PlayerName == playerName);
            if (player == null)
            {
                player = new Player
                {
                    PlayerName = playerName
                };
                _context.Player.Add(player);
                _context.SaveChanges();
            }
            var mark = _context.TrackScoreMarks.FirstOrDefault(m => m.PlayerId == player.PlayerId && m.TrackId== trackId);
            mark ??= new TrackScoreMark
            {
                TrackId = trackId,
                PlayerId = player.PlayerId,
            };
            mark.WriteScore(score);
            _context.TrackScoreMarks.Add(mark);
            _context.SaveChanges();
        }
    }
}
