using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models.interfaces
{
    public interface IGuilds
    {
        /// <summary>
        /// Creates a new guild and adds it to the Guilds database table
        /// </summary>
        /// <param name="guild">Guild object to be added</param>
        /// <returns>Created Guild</returns>
        Task<Guilds> Create(Guilds guild);

        /// <summary>
        /// Gets a list of all the guilds in the in Guilds database table
        /// </summary>
        /// <returns></returns>
        Task<List<Guilds>> GetGuilds();

        /// <summary>
        /// Gets a specific guild from the Guilds database table
        /// </summary>
        /// <param name="id">Unique ID of the targeted guild</param>
        /// <returns>Targeted guild object</returns>
        Task<Guilds> GetGuild(int id);

        /// <summary>
        /// Updates a specific guild from the Guilds database table
        /// </summary>
        /// <param name="guild">The guild object with ID that will be updated to current ID'd object</param>
        /// <returns>Updated object</returns>
        Task<Guilds> Update(Guilds guild);

        /// <summary>
        /// Deletes a specific guild from the Guilds database table
        /// </summary>
        /// <param name="id">Unique ID of the targeted guild</param>
        /// <returns>Task of completion</returns>
        Task Delete(int id);
    }
}
