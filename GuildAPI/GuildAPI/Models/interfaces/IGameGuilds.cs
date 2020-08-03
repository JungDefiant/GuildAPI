using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.interfaces
{
    interface IGameGuilds
    {
        Task<GameGuilds> Create(GameGuilds amenity);
        Task<List<GameGuilds>> GetAllGameGuilds();
        Task<GameGuilds> GetGameGuild(int id);
        Task<GameGuilds> Update(Games amenity);
        Task Delete(int id);
    }
}
