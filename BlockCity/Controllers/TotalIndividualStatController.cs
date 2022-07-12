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
    public class TotalIndividualStatController : ControllerBase
    {
        private readonly DataContext _context;

        public TotalIndividualStatController(DataContext context)
        {
            _context = context;
        }

                [HttpGet]
        public async Task<ActionResult<IEnumerable<Stat>>> GetTotalStats()
        {

            var plas = _context.Stats.GroupBy(p => p.PlayerId).Select(g => new Stat
            {
                PlayerId = g.Key,
                GamesPlayed = g.Sum(g => g.GamesPlayed),
                Points = g.Max(t => t.Points),
                Rebounds = g.Max(t => t.Rebounds),
                Assists = g.Max(t => t.Assists),
                Steals = g.Max(t => t.Steals),
                Blocks = g.Max(t => t.Blocks),
                FeildGoalsAttempted = g.Max(t => t.FeildGoalsAttempted),
                FeildGoalsMade = g.Max(t => t.FeildGoalsMade),
                ThreePointersAttempted = g.Max(t => t.ThreePointersAttempted),
                ThreePointerMade = g.Max(t => t.ThreePointerMade),
                FreeThrowsAttempted = g.Max(t => t.FreeThrowsAttempted),
                FreeThrowsMade = g.Max(t => t.FreeThrowsMade)
            });

            return await plas.ToListAsync();
        }

    }
}
