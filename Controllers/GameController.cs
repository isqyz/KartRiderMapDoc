using KartRiderMapDoc.Models;
using KartRiderMapDoc.Services;
using Microsoft.AspNetCore.Mvc;

namespace KartRiderMapDoc.Controllers
{
    public class GameController : Controller
    {
        private readonly GameService gameService;


        private static List<PlayerScore> Scores = new List<PlayerScore>();
        // GET: GameStatsApp

        private static List<PlayerScore> players = new List<PlayerScore>();

        private static List<string> tracks = new List<string> { "Track A", "Track B", "Track C" };

        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        //public IActionResult Index()
        //{

        //    return Ok("filteredPlayers");
        //}

        public IActionResult Index(List<string> selectedTracks)
        {
            // 获取所有赛道
            ViewBag.AllTracks = gameService.GetAllTrack();
  
            // 选中赛道，如果未选择则展示全部
            ViewBag.SelectedTracks = selectedTracks;
            var filteredPlayers = players
                .Where(p => selectedTracks.Count == 0 || selectedTracks.Contains(p.TrackName))
                .OrderByDescending(p => p.Score);
            ShowViewModel showView = new();

            showView.Tracks = gameService.GetAllTrack();
            showView.PlayerScores = gameService.GetAllPlayerScores();
            return View(showView);
        }

        public IActionResult Manage()
        {
            return View((play:new PlayerScore(), Tracks:gameService.GetAllTrack()));
        }

        [HttpPost]
        public IActionResult AddOrUpdate(PlayerScore player)
        {
            var existingPlayer = players.FirstOrDefault(p => p.PlayerName == player.PlayerName && p.TrackName == player.TrackName);
            if (existingPlayer != null)
            {
                // 更新成绩
                existingPlayer.Score = player.Score;
            }
            else
            {
                // 添加新玩家成绩
                players.Add(player);
            }

            return RedirectToAction("Index");
        }
    }
}
