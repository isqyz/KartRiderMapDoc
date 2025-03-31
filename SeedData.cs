using KartRiderMapDoc.Db;

namespace KartRiderMapDoc
{
    internal class SeedData
    {
        internal static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope(); // 创建一个新的作用域
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>(); // 从作用域解析 DbContext
            // 如果数据库为空，则初始化数据
            if (!context.Tracks.Any())
            {
                context.Tracks.AddRange
                    (
                    new Models.Track { TrackName = "城镇高速公路" , Star = 2, Lev = "R" },
                    new Models.Track { TrackName = "城镇运河" , Star = 1, Lev = "R" }
                );
                context.SaveChanges();
            }
            if (!context.TrackScoreMarks.Any())
            {

            }
            //if (!context.Player.Any())
            //{
            //    context.Player.AddRange
            //        (
            //        new Models.Player { Level = Models.ScoreLev.娱乐, PlayerName = "土炮", Score = 98.60 },
            //        new Models.Player
            //        {
            //            Level = Models.ScoreLev.一线,
            //            PlayerName = "富贵",
            //            Score = 91.60,
            //        }
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}