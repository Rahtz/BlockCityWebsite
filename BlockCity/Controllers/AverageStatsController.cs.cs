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
    public class AverageStatsController : ControllerBase
    {
        private readonly DataContext _context;
        
        public AverageStatsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stat>>> GetTotalStats()
        {

            var plas = _context.Stats.GroupBy(p => p.PlayerId).Select(g => new Stat
            {
                PlayerId = g.Key,
                GamesPlayed = (int)g.Average(g => g.GamesPlayed),
                Points = (int)g.Average(t => t.Points),
                Rebounds = (int)g.Average(t => t.Rebounds),
                Assists = (int)g.Average(t => t.Assists),
                Steals = (int)g.Average(t => t.Steals),
                Blocks = (int)g.Average(t => t.Blocks),
                FeildGoalsAttempted = (int)g.Average(t => t.FeildGoalsAttempted),
                FeildGoalsMade = (int)g.Average(t => t.FeildGoalsMade),
                ThreePointersAttempted = (int)g.Average(t => t.ThreePointersAttempted),
                ThreePointerMade = (int)g.Average(t => t.ThreePointerMade),
                FreeThrowsAttempted = (int)g.Average(t => t.FreeThrowsAttempted),
                FreeThrowsMade = (int)g.Average(t => t.FreeThrowsMade)
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
