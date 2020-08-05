using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.DTOs
{
    public class GuildDTO
    {
        public string Name { get; set; }
        public List<Games> Games { get; set; }
    }
}
