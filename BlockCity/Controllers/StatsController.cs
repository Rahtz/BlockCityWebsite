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
    public class StatsController : ControllerBase
    {
        private readonly DataContext _context;

        public StatsController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Stat>>> GetTotStats()
        //{

        //    var plas = _context.Stats.GroupBy(p => p.PlayerId).Select(g => new Stat
        //    {
        //        PlayerId = g.Key,
        //        Points = g.Sum(t => t.Points),
        //        Rebounds = g.Sum(t => t.Rebounds),
        //        Assists = g.Sum(t => t.Assists),
        //        Steals = g.Sum(t => t.Steals),
        //        Blocks = g.Sum(t => t.Rebounds),
        //        FeildGoalsAttempted = g.Sum(t => t.FeildGoalsAttempted),
        //        FeildGoalsMade = g.Sum(t => t.FeildGoalsMade),
        //        ThreePointersAttempted = g.Sum(t => t.ThreePointersAttempted),
        //        ThreePointerMade = g.Sum(t => t.ThreePointerMade),
        //        FreeThrowsAttempted = g.Sum(t => t.FreeThrowsAttempted),
        //        FreeThrowsMade = g.Sum(t => t.FreeThrowsMade)
        //    });

        //    return await plas.ToListAsync();
        //}



        //GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stat>>> GetStats()
        {
            return await _context.Stats.ToListAsync();
        }

        // GET: api/Stats/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Stat>> GetStat(int id)
        //{
        //    var stat = await _context.Stats.FindAsync(id);

        //    if (stat == null)
        //    {
        //        return NotFound();
        //    }

        //    return stat;
        //}

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Stat>>> GetPlayerStat(int id)
        {
            //var stat = await _context.Stats.FindAsync(playerId);
            var stat = _context.Stats.Where(u => u.PlayerId == id);


            return await stat.ToListAsync();
        }

        // PUT: api/Stats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStat(int id, Stat stat)
        {
            if (id != stat.Id)
            {
                return BadRequest();
            }

            _context.Entry(stat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Stats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stat>> PostStat(Stat stat)
        {
            _context.Stats.Add(stat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStat", new { id = stat.Id }, stat);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStat(int id)
        {
            var stat = await _context.Stats.FindAsync(id);
            if (stat == null)
            {
                return NotFound();
            }

            _context.Stats.Remove(stat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatExists(int id)
        {
            return _context.Stats.Any(e => e.Id == id);
        }
    }
}
