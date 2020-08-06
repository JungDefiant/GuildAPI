using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameGuilds> GameGuilds { get; set; }
        public List<GameManagers> GameManagers { get; set; }
    }
}
