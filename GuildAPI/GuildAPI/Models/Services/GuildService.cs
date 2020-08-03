using GuildAPI.Models.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.Services
{
    public class GuildService : IGuilds
    {
        private GuildAPIDbContext _context;
        public GuildService(GuildAPIDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new guild and adds it to the Guilds database table
        /// </summary>
        /// <param name="guild">Guild object to be added</param>
        /// <returns>Created Guild</returns>
        public async Task<Guilds> Create(Guilds guild)
        {
            _context.Entry(guild).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return guild;
        }

        /// <summary>
        /// Deletes a specific guild from the Guilds database table
        /// </summary>
        /// <param name="id">Unique ID of the targeted guild</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Guilds guild = await _context.Guilds.FindAsync(id);
            _context.Entry(guild).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific guild from the Guilds database table
        /// </summary>
        /// <param name="id">Unique ID of the targeted guild</param>
        /// <returns>Targeted guild object</returns>
        public async Task<Guilds> GetGuild(int id)
        {
            Guilds guild = await _context.Guilds.FindAsync(id);
            return guild;
        }

        /// <summary>
        /// Gets a list of all the guilds in the in Guilds database table
        /// </summary>
        /// <returns></returns>
        public async Task<List<Guilds>> GetGuilds()
        {
            var guilds = await _context.Guilds.ToListAsync();
            return guilds;
        }

        /// <summary>
        /// Updates a specific guild from the Guilds database table
        /// </summary>
        /// <param name="guild">The guild object with ID that will be updated to current ID'd object</param>
        /// <returns>Updated object</returns>
        public async Task<Guilds> Update(Guilds guild)
        {
            _context.Entry(guild).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return guild;
        }
    }
}
