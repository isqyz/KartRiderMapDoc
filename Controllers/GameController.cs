using KartRiderMapDoc.Models;
using KartRiderMapDoc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;

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
            ViewBag.AllTracks = gameService.GetAllTrack();
  
            // 选中赛道，如果未选择则展示全部
            ViewBag.SelectedTracks = selectedTracks;
            //var filteredPlayers = gameService.GetAllPlayerScores()
            //    .Where(p => selectedTracks.Count == 0 || selectedTracks.Contains(p.TrackName??""))
            //    .OrderByDescending(p => p.Score);
            ShowViewModel showView = new()
            {
                Tracks = gameService.GetAllTrack().Where(p=> selectedTracks.Count == 0 || selectedTracks.Contains(p.TrackName??"")),
                PlayerScores = gameService.GetAllPlayerScores().Where(val=>val.TrackScores is not null && val.TrackScores.Count>0)
            };
            return View(showView);
        }

        public IActionResult Manage()
        {
            return View((play:new Player(), Tracks:gameService.GetAllTrack()));
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Player player)
        {
            gameService.AddPlayer(player);
            return RedirectToAction("Index");
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
