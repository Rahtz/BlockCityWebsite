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
    public class PlayerStatsController : ControllerBase
    {
        private readonly DataContext _context;

        public PlayerStatsController(DataContext context)
        {
            _context = context;
        }

        //GET: api/Players/5
        [HttpGet("{PlayerId}")]
        public async Task<ActionResult<Stat>> GetPlayerStats(int PlayerId)
        {
            var stat = await _context.Stats.FirstOrDefaultAsync(c => c.PlayerId == PlayerId);

            if (stat == null)
            {
                return NotFound();
            }

            return stat;
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Stat>> GetPlayerStats(int playerId)
        //{
        //    var db = await _context.Stats.FindAsync(playerId);

        //    return (from s in db
        //            where s.PlayerId == playerId
        //            select s).ToList();
        //}


    }
}
