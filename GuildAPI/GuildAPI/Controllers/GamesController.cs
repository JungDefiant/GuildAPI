﻿using System;
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
using GuildAPI.Controllers.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GuildAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGames _games;
        private readonly UserManager<ApplicationUser> _userManager;
        private GuildAPIDbContext _context;

        public GamesController(IGames games, UserManager<ApplicationUser> userManager, GuildAPIDbContext context)
        {
            _games = games;
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Games>>> GetGames()
        {
            return await _games.GetGames();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
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
        public async Task<ActionResult<Games>> PostGames(Games games)
        {
            await _games.Create(games);
            return CreatedAtAction("GetGames", new { id = games.Id }, games);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Games>> DeleteGames(int id)
        {
            await _games.Delete(id);
            return NoContent();
        }

        //POST: api/Games/5/Guilds/5
        [HttpPost("{gameId}/Guilds/{guildId}")]
        public async Task<ActionResult> PostGameGuilds(int gameId, int guildId)
        {
            var email = HttpContext.User.Claims.First(e => e.Type == "Email").Value;
            var userID = GetUserId(email);

            var gameManager = await _context.GameManagers.FindAsync(gameId, userID);
            if (gameManager != null)
            {
                await _games.AddGameGuild(gameId, guildId);
                return Ok();
            }
            return BadRequest();
        }

        //DELETE: api/Games/5
        [HttpDelete("{gameId}/Guilds/{guildId}")]
        public async Task<ActionResult> DeleteGameGuilds(int gameId, int guildId)
        {
            await _games.RemoveGameGuild(gameId, guildId);
            return NoContent();
        }

        public async Task<string> GetUserId(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                return user.Id;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
