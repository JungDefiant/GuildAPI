using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Guilds
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameGuilds GameGuilds { get; set; }

    }
}
