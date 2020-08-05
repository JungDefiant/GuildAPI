using GuildAPI.Data;
using GuildAPI.Models.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;

namespace GuildAPI.Models.Services
{
    public class GamesService : IGames
    {
        private GuildAPIDbContext _context;

        public GamesService(GuildAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adds to the game db
        /// </summary>
        /// <param name="games"></param>
        /// <returns>returns created game</returns>
        public async Task<Games> Create(Games games)
        {
            _context.Entry(games).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return games;
        }

        /// <summary>
        /// gets all games from db
        /// </summary>
        /// <returns>successfullly returns all games</returns>
        public async Task<List<Games>> GetGames()
        {
            List<Games> result = await _context.Games.ToListAsync();
            return result;
        }

        /// <summary>
        /// get specific game from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns selected game</returns>
        public async Task<Games> GetGame(int id)
        {
            Games result = await _context.Games.FindAsync(id);
            return result;
        }

        /// <summary>
        /// updates games db
        /// </summary>
        /// <param name="game"></param>
        /// <returns>successfully updated db</returns>
        public async Task<Games> Update(Games game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return game;
        }

        /// <summary>
        /// deletes a specific game from the games table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>task of completion</returns>
        public async Task Delete(int id)
        {
            Games games = await GetGame(id);
            _context.Entry(games).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// adds a guild to a game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="guildId"></param>
        /// <returns>succesfully added guild to game</returns>
        public async Task AddGameGuild(int gameId, int guildId)
        {
            GameGuilds gameGuilds = new GameGuilds()
            {
                GameId = gameId,
                GuildId = guildId,
            };

            _context.Entry(gameGuilds).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// /removes guild from the game db table
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="guildId"></param>
        /// <returns>task of completion</returns>
        public async Task RemoveGameGuild( int gameId, int guildId)
        {
            var result = await _context.GameGuilds.FirstOrDefaultAsync(x => x.GameId == gameId && x.GuildId == guildId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// adds a manager to a game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task AddGameManager(int gameId, string userId)
        {
            GameManagers gameManagers = new GameManagers()
            {
                GameId = gameId,
                UserId = userId,
            };

            _context.Entry(gameManagers).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// removes manager from game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task RemoveGameManager(int gameId, string userId)
        {
            var result = await _context.GameManagers.FirstOrDefaultAsync(x => x.GameId == gameId && x.UserId == userId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
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
