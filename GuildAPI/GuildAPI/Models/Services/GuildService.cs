using GuildAPI.Data;
using GuildAPI.Models.DTOs;
using GuildAPI.Models.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.Services
{
    public class GuildService : IGuilds
    {
        private GuildAPIDbContext _context;
        public GuildService(GuildAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new guild and adds it to the Guilds database table
        /// </summary>
        /// <param name="guild">Guild object to be added</param>
        /// <returns>Created Guild</returns>
        public async Task<Guilds> Create(Guilds guild)
        {
            _context.Entry(guild).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return guild;
        }

        /// <summary>
        /// Deletes a specific guild from the Guilds database table
        /// </summary>
        /// <param name="id">Unique ID of the targeted guild</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Guilds guild = await _context.Guilds.FindAsync(id);
            _context.Entry(guild).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific guild from the Guilds database table
        /// </summary>
        /// <param name="id">Unique ID of the targeted guild</param>
        /// <returns>Targeted guild object</returns>
        public async Task<GuildDTO> GetGuild(int id)
        {
            Guilds guild = await _context.Guilds.FindAsync(id);
            List<GameGuilds> gameGuilds = await _context.GameGuilds.Where(x => x.GuildId == id).ToListAsync();
            List<Games> games = new List<Games>();
            foreach (var item in gameGuilds)
            {
                games.Add(await new GamesService(_context).GetGame(item.GameId));
            }
            GuildDTO dto = new GuildDTO()
            {
                Name = guild.Name,
                Games = games
            };
            return dto;
        }

        /// <summary>
        /// Gets a list of all the guilds in the in Guilds database table
        /// </summary>
        /// <returns></returns>
        public async Task<List<GuildDTO>> GetGuilds()
        {
            var list = await _context.Guilds.ToListAsync();
            List<GuildDTO> guilds = new List<GuildDTO>();
            foreach (var item in list)
            {
                guilds.Add(await GetGuild(item.Id));
            }
            return guilds;
        }

        /// <summary>
        /// Updates a specific guild from the Guilds database table
        /// </summary>
        /// <param name="guild">The guild object with ID that will be updated to current ID'd object</param>
        /// <returns>Updated object</returns>
        public async Task<Guilds> Update(Guilds guild)
        {
            _context.Entry(guild).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return guild;
        }

        /// <summary>
        /// Verifies that a Manager (user) of a game has access to a specific game
        /// </summary>
        /// <param name="userId">ID of user (with manager role)</param>
        /// <param name="gameId">ID of game</param>
        /// <returns>True if they have access; False if denied access</returns>
        public async Task<bool> VerifyManager(string userId, int gameId) =>
            await _context.GameManagers.AnyAsync(x => x.UserId == userId && x.GameId == gameId);
    }
}
