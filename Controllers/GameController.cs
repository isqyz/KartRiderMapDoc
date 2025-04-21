using KartRiderMapDoc.Models;
using KartRiderMapDoc.Services;
using Microsoft.AspNetCore.Mvc;

namespace KartRiderMapDoc.Controllers
{
    public class GameController(GameService gameService) : Controller
    {

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
            foreach (var t in tracks)
            {
                    if(t is not null && t.TrackScores is not null)
                        if (t.TrackScores is not null)
                            if (selectedTracks.Count == 0 || selectedTracks.Contains(t.TrackName))
                            {
                                showView.Tracks = showView.Tracks.Append(t);
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
        public IActionResult AddTrack(Track track, params string[] parm)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < parm.Length; i++)
                {
                    string? p = parm[i];
                    if (p is not null)
                    {
                        track.AppendGradeLevel((ScoreLev)i, p);
                    }
                }
                gameService.AddTrack(track);
            }
            //return RedirectToAction("AddTrack");
            return View("AddTrack",(gameService.GetAllTrack(), track));
        }
        [HttpPost]
        public IActionResult EditTrack([FromForm] int Id)
        {
            if (ModelState.IsValid)
            {
                var all = gameService.GetAllTrack();
                var track = all.FirstOrDefault(val => val.Id == Id);
                if(track is not null)
                {
                     return View("AddTrack", (all, track));
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DelTrack(int id)
        {
            gameService.DelTrack(id);
            return RedirectToAction("Index");
        }
    }
}
