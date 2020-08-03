using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.interfaces
{
    interface IGames
    {
        Task<Games> Create(Games game);
        Task<List<Games>> GetGames();
        Task<Games> GetGame(int id);
        Task<Games> Update(Games game);
        Task Delete(int id);
        Task AddGameGuild(int gameId, int guildId);
        Task RemoveGameGuild(int gameId, int guildId);
        Task AddGameManager(int gamdeId, string UserId);
        Task RemoveGameManager(int gamId, string UserId);
    }
}
