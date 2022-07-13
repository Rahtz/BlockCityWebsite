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
using System.Web.Http.Cors;

namespace BlockCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "https://blockcity.herokuapp.com", headers: "*", methods: "*")]
    public class TotalStatsController : ControllerBase
    {
        private readonly DataContext _context;

        public TotalStatsController(DataContext context)
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
                Points = g.Sum(t => t.Points),
                Rebounds = g.Sum(t => t.Rebounds),
                Assists = g.Sum(t => t.Assists),
                Steals = g.Sum(t => t.Steals),
                Blocks = g.Sum(t => t.Blocks),
                FeildGoalsAttempted = g.Sum(t => t.FeildGoalsAttempted),
                FeildGoalsMade = g.Sum(t => t.FeildGoalsMade),
                ThreePointersAttempted = g.Sum(t => t.ThreePointersAttempted),
                ThreePointerMade = g.Sum(t => t.ThreePointerMade),
                FreeThrowsAttempted = g.Sum(t => t.FreeThrowsAttempted),
                FreeThrowsMade = g.Sum(t => t.FreeThrowsMade)
            });

            return await plas.ToListAsync();
        }



        

        // GET: api/Players/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Stat>> GetTotalStatsPlayer(int id)
        //{
        //    var stat = await _context.Stats.FindAsync(id);

        //    if (stat == null)
        //    {
        //        return NotFound();
        //    }

        //    return stat;
        //}


    }
}
