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
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GuildAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGames _games;
        private readonly UserManager<ApplicationUser> _userManager;


        public GamesController(IGames games, UserManager<ApplicationUser> userManager)
        {
            _games = games;
            _userManager = userManager;
        }

        // GET: api/Games
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Games>>> GetGames()
        {
            return await _games.GetGames();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Games>> GetGame(int id)
        {
            var games = await _games.GetGame(id);

            if (games == null)
            {
                return NotFound();
            }

            return games;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> PutGames(int id, Games games)
        {
            if (id != games.Id)
            {
                return BadRequest();
            }

            await _games.Update(games);
            return Ok();
        }

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult<Games>> PostGames(Games games)
        {
            await _games.Create(games);
            return CreatedAtAction("GetGames", new { id = games.Id }, games);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult<Games>> DeleteGames(int id)
        {
            await _games.Delete(id);
            return NoContent();
        }

        //POST: api/Games/5/Guilds/5
        [HttpPost("{gameId}/Guilds/{guildId}")]
        [Authorize(Policy = "Manager")]
        public async Task<ActionResult> PostGameGuilds(int gameId, int guildId)
        {
            var email = HttpContext.User.Claims.First(e => e.Type == "Email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            if (await _games.VerifyManager(user.Id, gameId) || roles.Contains("Administrator"))
            {
                await _games.AddGameGuild(gameId, guildId);
                return Ok();
            }
            return BadRequest("Manager does not have access");
        }

        //DELETE: api/Games/5/Guilds/5
        [HttpDelete("{gameId}/Guilds/{guildId}")]
        [Authorize(Policy = "Manager")]
        public async Task<ActionResult> DeleteGameGuilds(int gameId, int guildId)
        {
            var email = HttpContext.User.Claims.First(e => e.Type == "Email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            if (await _games.VerifyManager(user.Id, gameId) || roles.Contains("Administrator"))
            {
                await _games.RemoveGameGuild(gameId, guildId);
                return NoContent();
            }
            return BadRequest("Manager does not have access");
        }

        ////POST: api/Games/5/GameManager/5
        [HttpPost("{gameId}/Manager/{userEmail}")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> AddGameManager(int gameId, string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            await _games.AddGameManager(gameId, user.Id);
            return Ok();
        }

        ////DELETE: api/Games/5/GameManager/5
        [HttpDelete("{gameId}/Manager/{userEmail}")]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> RemoveGameManager(int gameId, string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            await _games.RemoveGameManager(gameId, user.Id);
            return Ok();
        }
    }
}
