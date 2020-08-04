using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuildAPI.Data;
using GuildAPI.Models;
using GuildAPI.Models.interfaces;

namespace GuildAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildsController : ControllerBase
    {
        private readonly IGuilds _guilds;

        public GuildsController(IGuilds guilds)
        {
            _guilds = guilds;
        }

        // GET: api/Guilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guilds>>> GetGuilds()
        {
            return await _guilds.GetGuilds();
        }

        // GET: api/Guilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guilds>> GetGuilds(int id)
        {
            var guilds = await _guilds.GetGuild(id);

            if (guilds == null)
            {
                return NotFound();
            }

            return guilds;
        }

        // PUT: api/Guilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuilds(int id, Guilds guilds)
        {
            if (id != guilds.Id)
            {
                return BadRequest();
            }
            await _guilds.Update(guilds);
            return NoContent();
        }

        // POST: api/Guilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Guilds>> PostGuilds(Guilds guilds)
        {
           await _guilds.Create(guilds);
           return CreatedAtAction("GetGuilds", new { id = guilds.Id }, guilds);
        }

        // DELETE: api/Guilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guilds>> DeleteGuilds(int id)
        {
            await _guilds.Delete(id);
            return NoContent();
        }


    }
}
