using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.interfaces
{
    interface IGuilds
    {
        Task<Guilds> Create(Guilds amenity);
        Task<List<Guilds>> GetGuilds();
        Task<Guilds> GetGuild(int id);
        Task<Guilds> Update(Guilds amenity);
        Task Delete(int id);
    }
}
