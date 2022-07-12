#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlockCity;
using BlockCity.Data;

namespace BlockCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly DataContext _context;

        public RecordsController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Stat>>> GetTotalStats()
        //{

        //    var plas = _context.Stats.GroupBy(p => p.PlayerId).Select(g => new Stat
        //    {
        //        PlayerId = g.Key,
        //        GamesPlayed = g.Sum(g => g.GamesPlayed),
        //        Points = g.Max(t => t.Points),
        //        Rebounds = g.Max(t => t.Rebounds),
        //        Assists = g.Max(t => t.Assists),
        //        Steals = g.Max(t => t.Steals),
        //        Blocks = g.Max(t => t.Blocks),
        //        FeildGoalsAttempted = g.Max(t => t.FeildGoalsAttempted),
        //        FeildGoalsMade = g.Max(t => t.FeildGoalsMade),
        //        ThreePointersAttempted = g.Max(t => t.ThreePointersAttempted),
        //        ThreePointerMade = g.Max(t => t.ThreePointerMade),
        //        FreeThrowsAttempted = g.Max(t => t.FreeThrowsAttempted),
        //        FreeThrowsMade = g.Max(t => t.FreeThrowsMade)
        //    });

        //    return await plas.ToListAsync();
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Stat>>> GetTotalStats()
        //{

        //    var plas = _context.Stats;

        //    int maxPoints = plas.Max(p => p.Points);

        //    var NewStat = new Stat
        //    {
        //        PlayerId = 0,
        //        GamesPlayed = 0,
        //        Points = maxPoints,
        //        Rebounds = 0,
        //        Assists = 0,
        //        Steals = 0,
        //        Blocks = 0,
        //        FeildGoalsAttempted = 0,
        //        FeildGoalsMade = 0,
        //        ThreePointersAttempted = 0,
        //        ThreePointerMade = 0,
        //        FreeThrowsAttempted = 0,
        //        FreeThrowsMade = 0
        //    };

        //    return await NewStat.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stat>>> GetTotalStats()
        {
            var stat = _context.Stats;

            int maxPoints = stat.Max(p => p.Points);
            int maxAssists = stat.Max(p => p.Assists);
            int maxRebounds = stat.Max(p => p.Rebounds);
            int maxSteals = stat.Max(p => p.Steals);
            int maxBlocks = stat.Max(p => p.Blocks);
            int maxFeildGoalsAttempted = stat.Max(p => p.FeildGoalsAttempted);
            int maxFeildGoalsMade = stat.Max(p => p.FeildGoalsMade);
            int maxThreePointersAttempted = stat.Max(p => p.ThreePointersAttempted);
            int maxThreePointerMade = stat.Max(p => p.ThreePointerMade);
            int maxFreeThrowsAttempted = stat.Max(p => p.FreeThrowsAttempted);
            int maxFreeThrowsMade = stat.Max(p => p.FreeThrowsMade);
            int maxGamesPlayed = stat.Max(p => p.GamesPlayed);

            var plas = _context.Stats.Select(g => new Stat
            {
                GamesPlayed = maxGamesPlayed,
                Points = maxPoints,
                Rebounds = maxRebounds,
                Assists = maxAssists,
                Steals = maxSteals,
                Blocks = maxBlocks,
                FeildGoalsAttempted = maxFeildGoalsAttempted,
                FeildGoalsMade = maxFeildGoalsMade,
                ThreePointersAttempted = maxThreePointersAttempted,
                ThreePointerMade = maxThreePointerMade,
                FreeThrowsAttempted = maxFreeThrowsAttempted,
                FreeThrowsMade = maxFreeThrowsMade
            });

            return await plas.ToListAsync();
        }

        //GET: api/Players/5
        [HttpGet("{PlayerId}")]
        public async Task<ActionResult<IEnumerable<Stat>>> GetPlayerStats(int PlayerId)
        {
            var stat = _context.Stats;

            int maxPoints = stat.Max(p => p.Points);
            int maxAssists = stat.Max(p => p.Assists);
            int maxRebounds = stat.Max(p => p.Rebounds);
            int maxSteals = stat.Max(p => p.Steals);
            int maxBlocks = stat.Max(p => p.Blocks);
            int maxFeildGoalsAttempted = stat.Max(p => p.FeildGoalsAttempted);
            int maxFeildGoalsMade = stat.Max(p => p.FeildGoalsMade);
            int maxThreePointersAttempted = stat.Max(p => p.ThreePointersAttempted);
            int maxThreePointerMade = stat.Max(p => p.ThreePointerMade);
            int maxFreeThrowsAttempted = stat.Max(p => p.FreeThrowsAttempted);
            int maxFreeThrowsMade = stat.Max(p => p.FreeThrowsMade);
            int maxGamesPlayed = stat.Max(p => p.GamesPlayed);

            var plas = _context.Stats.Select(g => new Stat
            {
                GamesPlayed = maxGamesPlayed,
                Points = maxPoints,
                Rebounds = maxRebounds,
                Assists = maxAssists,
                Steals = maxSteals,
                Blocks = maxBlocks,
                FeildGoalsAttempted = maxFeildGoalsAttempted,
                FeildGoalsMade = maxFeildGoalsMade,
                ThreePointersAttempted = maxThreePointersAttempted,
                ThreePointerMade = maxThreePointerMade,
                FreeThrowsAttempted = maxFreeThrowsAttempted,
                FreeThrowsMade = maxFreeThrowsMade
            });

            return await plas.ToListAsync();
        }



    }
}
