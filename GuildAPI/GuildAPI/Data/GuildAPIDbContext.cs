using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace GuildAPI.Data
{
    public class GuildAPIDbContext : DbContext
    {
        public GuildAPIDbContext(DbContextOptions<GuildAPIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameGuilds>().HasKey(x => new { x.GameId, x.GuildId });


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

        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Guilds> Guilds { get; set; }
        public DbSet<GameGuilds> GameGuilds { get; set; }




    }
}

