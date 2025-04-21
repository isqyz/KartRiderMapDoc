using KartRiderMapDoc.Db;
using KartRiderMapDoc.Models;
using Microsoft.EntityFrameworkCore;

namespace KartRiderMapDoc.Services
{
    public class GameService(AppDbContext context, ILogger<GameService> logger)
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger<GameService> _logger = logger;
        internal IEnumerable<Track> GetAllTrack()
        {
            return  _context.Tracks
                .Include(t => t.TrackScores.OrderBy(ts=>ts.Score))
                    .ThenInclude(p=>p.Player)
                    .Include(t=>t.PlayerTrackAchievements).OrderBy(t => t.Star);
        }
        internal IEnumerable<Player> GetAllPlayer()
        {
            return _context.Player;
        }
        internal IEnumerable<TrackScoreMark> GetTrackScoreMark()
        {
            return _context.TrackScoreMarks; 
        }

        internal void AddTrack(Track track)
        {
            var existingTrack = GetAllTrack().FirstOrDefault(t => t.TrackName == track.TrackName);
            if (existingTrack != null)
            {
                track.Id = existingTrack.Id;
                _context.Entry(existingTrack).CurrentValues.SetValues(track);
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
            var existing = _context.TrackScoreMarks.FirstOrDefault(tsm => tsm.PlayerId == mark.PlayerId && tsm.TrackId == mark.TrackId);
            if (existing == null)
            {
                _context.TrackScoreMarks.Add(mark);
            }
            else
            {
                existing.Score = mark.Score;
                existing.CreatedAt = DateTime.Now;
            }
            _context.SaveChanges();
        }

        internal void DelTrack(int id)
        {
            var track = _context.Tracks.FirstOrDefault(val => val.Id == id);
            if (track is not null)
            {
                _context.Tracks.Remove(track);
                _context.SaveChanges();
            }
        }
    }
}
