using GuildAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Controllers.Interfaces
{
    public interface IUserProvider
    {
        Task<string> GetUserID(string email);
    }
}
