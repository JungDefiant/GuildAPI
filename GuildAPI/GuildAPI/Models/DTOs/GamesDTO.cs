using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.DTOs
{
    public class GamesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GuildsDTO> Guilds { get; set; }
        //public List<GameManagers> GameManagers { get; set; }
    }
}
