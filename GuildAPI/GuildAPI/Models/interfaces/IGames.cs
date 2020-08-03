using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.interfaces
{
    interface IGames
    {
        Task<Games> Create(Games amenity);
        Task<List<Games>> GetGames();
        Task<Games> GetGame(int id);
        Task<Games> Update(Games amenity);
        Task Delete(int id);

    }
}
