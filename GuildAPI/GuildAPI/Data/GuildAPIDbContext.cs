using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GuildAPI.Data
{
    public class GuildAPIDbContext : IdentityDbContext<ApplicationUser>
    {
        public GuildAPIDbContext(DbContextOptions<GuildAPIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameGuilds>().HasKey(x => new { x.GameId, x.GuildId });
            modelBuilder.Entity<GameManagers>().HasKey(x => new { x.GameId, x.UserId });

            #region
            modelBuilder.Entity<Games>().HasData(

                new Games
                {
                    Id = 1,
                    Name = "Guild Clashes 2"
                },
                new Games
                {
                    Id = 2,
                    Name = "The World of NonCraft"
                },
                new Games
                {
                    Id = 3,
                    Name = "City of Zeroes"
                });

            modelBuilder.Entity<Guilds>().HasData(

                new Guilds
                {
                    Id = 1,
                    Name = "Guild of Average People"
                },
                new Guilds
                {
                    Id = 2,
                    Name = "BroForce"
                },
                new Guilds
                {
                    Id = 3,
                    Name = ""
                });
            #endregion
        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Guilds> Guilds { get; set; }
        public DbSet<GameGuilds> GameGuilds { get; set; }
        public DbSet<GameManagers> GameManagers { get; set; }
    }
}

