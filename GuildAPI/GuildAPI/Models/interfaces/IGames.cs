using GuildAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.interfaces
{
    public interface IGames
    {
        /// <summary>
        /// adds to the game db
        /// </summary>
        /// <param name="games"></param>
        /// <returns>returns created game</returns>
        Task<GamesDTO> Create(GamesDTO game);

        /// <summary>
        /// gets all games from db
        /// </summary>
        /// <returns>successfullly returns all games</returns>
        Task<List<GamesDTO>> GetGames();

        /// <summary>
        /// get specific game from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns selected game</returns>
        Task<GamesDTO> GetGame(int id);

        /// <summary>
        /// updates games db
        /// </summary>
        /// <param name="game"></param>
        /// <returns>successfully updated db</returns>
        Task<GamesDTO> Update(GamesDTO game);

        /// <summary>
        /// deletes a specific game from the games table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>task of completion</returns>
        Task Delete(int id);

        /// <summary>
        /// adds a guild to a game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="guildId"></param>
        /// <returns>succesfully added guild to game</returns>
        Task AddGameGuild(int gameId, int guildId);

        /// <summary>
        /// /removes guild from the game db table
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="guildId"></param>
        /// <returns>task of completion</returns>
        Task RemoveGameGuild(int gameId, int guildId);

        /// <summary>
        /// adds a manager to a game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddGameManager(int gameId, string userId);

        /// <summary>
        /// removes manager from game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task RemoveGameManager(int gameId, string userId);

        /// <summary>
        /// Verifies that a Manager (user) of a game has access to a specific game
        /// </summary>
        /// <param name="userId">ID of user (with manager role)</param>
        /// <param name="gameId">ID of game</param>
        /// <returns>True if they have access; False if denied access</returns>
        Task<bool> VerifyManager(string userId, int gameId);
    }
}
