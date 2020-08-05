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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GuildAPI.Models.DTOs;

namespace GuildAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildsController : ControllerBase
    {
        private readonly IGuilds _guilds;
        private readonly IGames _games;
        private readonly UserManager<ApplicationUser> _userManager;

        public GuildsController(IGuilds guilds, IGames games, UserManager<ApplicationUser> userManager)
        {
            _guilds = guilds;
            _games = games;
            _userManager = userManager;
        }

        // GET: api/Guilds
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GuildsDTO>>> GetGuilds()
        {
            return await _guilds.GetGuilds();
        }

        // GET: api/Guilds/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GuildsDTO>> GetGuilds(int id)
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
        [Authorize(Policy = "Manager")]
        public async Task<IActionResult> PutGuilds(int id, GuildsDTO guilds)
        {
            if (id != guilds.Id)
            {
                return BadRequest();
            }
            await _guilds.Update(guilds);
            return NoContent();
        }

        // POST: api/Guilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Game/{gameId}")]
        [Authorize(Policy = "Manager")]
        public async Task<ActionResult<GuildsDTO>> PostGuilds(GuildsDTO guilds, int gameId)
        {
            var email = HttpContext.User.Claims.First(e => e.Type == "Email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            if (await _guilds.VerifyManager(user.Id, gameId) || roles.Contains("Administrator"))
            {
                await _guilds.Create(guilds);
                await _games.AddGameGuild(gameId, guilds.Id);
                return CreatedAtAction("GetGuilds", new { id = guilds.Id }, guilds);
            }
            return BadRequest("Manager does not have access");
        }

        // DELETE: api/Guilds/5
        [HttpDelete("{guildId}/Game/{gameId}")]
        [Authorize(Policy = "Manager")]
        public async Task<ActionResult<GuildsDTO>> DeleteGuilds(int guildId, int gameId)
        {
            var email = HttpContext.User.Claims.First(e => e.Type == "Email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            if (await _guilds.VerifyManager(user.Id, gameId) || roles.Contains("Administrator"))
            {
                await _games.RemoveGameGuild(gameId, guildId);
                await _guilds.Delete(guildId);
                return NoContent();
            }
            return BadRequest("Manager does not have access");
        }
    }
}
