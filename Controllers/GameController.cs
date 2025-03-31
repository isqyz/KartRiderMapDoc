using KartRiderMapDoc.Models;
using KartRiderMapDoc.Services;
using Microsoft.AspNetCore.Mvc;

namespace KartRiderMapDoc.Controllers
{
    public class GameController : Controller
    {
        private readonly GameService gameService;

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
  
            // 选中赛道，如果未选择则展示全部
            //var filteredPlayers = gameService.GetAllPlayer()
            //    .Where(players => selectedTracks.Count == 0 || selectedTracks.Contains(players.TrackName??""))
            //    .OrderByDescending(players => players.Score);
            ShowViewModel showView = new();

            var tracks = gameService.GetAllTrack();
            List<ShowViewModel> showViewModel = [];
            foreach (var t in tracks)
            {
                if(t.TrackScores is not null)
                foreach(var mark in t.TrackScores)
                {
                    if(mark.Track is not null && mark.Player is not null)
                        if (selectedTracks.Count == 0 || selectedTracks.Contains(mark.Track.TrackName))
                        {
                                var mod = new ShowViewModel() { TrackName = t.TrackName };
                                mod.PlayerNames.Add(mark.Player.PlayerName);
                                mod.TrackName = t.TrackName;
                                mod.Scores.Add(mark.ReadScore());
                                //mod.Levs.Add(mark.Score);
                                showViewModel.Add(mod);
                        }
                }

            }
            return View(showView);
        }

        public IActionResult Update()
        {
            var dto = new
            {
                player = new Player(),
                mark = new TrackScoreMark(),
                players = gameService.GetAllPlayer(),
                tracks = gameService.GetAllTrack()
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult AddOrUpdate(string playerName, string score, int trackId)
        {
            gameService.AddPlayer(playerName,score,trackId);
            return RedirectToAction("Update");
        }
        [HttpPost]
        public IActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index"); // 添加成功后跳转到列表页
            }
            return View(track);
        }
        public IActionResult AddTrack()
        {
            return View((gameService.GetAllTrack(),new Track()));
        }

        // 处理添加赛道的表单提交
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrack(Track track)
        {
            if (ModelState.IsValid)
            {
                gameService.AddTrack(track);
                return RedirectToAction("Index"); 
            }
            return View(track);
        }
    }
}
