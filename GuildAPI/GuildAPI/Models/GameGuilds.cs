using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class GameGuilds
    {
        public int GameId { get; set; }
        public int GuildId { get; set; }
        public Games Game { get; set; }
        public Guilds Guild { get; set; }
    }
}
