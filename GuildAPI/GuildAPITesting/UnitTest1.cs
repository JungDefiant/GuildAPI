using GuildAPI.Data;
using GuildAPI.Models;
using GuildAPI.Models.DTOs;
using GuildAPI.Models.Services;
using GuildAPI.Models.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using static GuildAPI.Program;

namespace GuildAPITesting
{
    public class UnitTest1
    {
        [Fact]
        public async void CanCreateGameAndSaveToDatabase()
        {
            DbContextOptions<GuildAPIDbContext> options = new DbContextOptionsBuilder<GuildAPIDbContext>()
                .UseInMemoryDatabase("CanCreateGameAndSaveToDatabase")
                .Options;
            using GuildAPIDbContext context = new GuildAPIDbContext(options);
            GamesService service = new GamesService(context);
            GamesDTO dto = new GamesDTO() { Name = "Bryants Deluxe Game Edition" };
            Assert.Equal(0, context.Games.CountAsync().Result);
            var result = await service.Create(dto);
            var actual = context.Games.FindAsync(result.Id).Result;
            Assert.Equal(1, context.Games.CountAsync().Result);
           // Assert.IsType<Games>(actual);
            Assert.Equal(1, actual.Id);
            Assert.Equal("Bryants Deluxe Game Edition", actual.Name);

        }

        [Fact]
        public async void CanCreateUpdateAndSaveToDatabase()
        {
            DbContextOptions<GuildAPIDbContext> options = new DbContextOptionsBuilder<GuildAPIDbContext>()
                .UseInMemoryDatabase("CanCreateUpdateAndSaveToDatabase")
                .Options;
            using GuildAPIDbContext context = new GuildAPIDbContext(options);
            GamesService service = new GamesService(context);
            GamesDTO dto = new GamesDTO() { Name = "Bryants Deluxe Game Edition" };
            Assert.Equal(0, context.Games.CountAsync().Result);
            var result = await service.Create(dto);
            GamesDTO gamesDTO = new GamesDTO()
            {
                Id = 1,
                Name = "Legends of Lesley"
            };
            var update = service.Update(gamesDTO);
            Assert.Equal(1, context.Games.CountAsync().Result);
            // Assert.IsType<Games>(actual);
            Assert.Equal(1, update.Id);
            Assert.Equal("Legends of Lesley", update.Result.Name);

        }

        [Fact]
        public async void CanDeleteAndSaveToDatabase()
        {
            DbContextOptions<GuildAPIDbContext> options = new DbContextOptionsBuilder<GuildAPIDbContext>()
                .UseInMemoryDatabase("CanDeleteAndSaveToDatabase")
                .Options;
            using GuildAPIDbContext context = new GuildAPIDbContext(options);
            GamesService service = new GamesService(context);
            GamesDTO dto = new GamesDTO() { Name = "Bryants Deluxe Game Edition" };
            Assert.Equal(0, context.Games.CountAsync().Result);
            var result = await service.Create(dto);
            Assert.Equal(1, context.Games.CountAsync().Result);
            var delete = service.Delete(result.Id);
            Assert.Equal(0, context.Games.CountAsync().Result);
            // Assert.IsType<Games>(actual);
        }

        [Fact]
        public async void CanGetGameFromDatabase()
        {
            DbContextOptions<GuildAPIDbContext> options = new DbContextOptionsBuilder<GuildAPIDbContext>()
                .UseInMemoryDatabase("CanGetGameFromDatabase")
                .Options;
            using GuildAPIDbContext context = new GuildAPIDbContext(options);
            GamesService service = new GamesService(context);
            GamesDTO dto = new GamesDTO() { Name = "Bryants Deluxe Game Edition" };
            Assert.Equal(0, context.Games.CountAsync().Result);
            var result = await service.Create(dto);
            Assert.Equal(1, context.Games.CountAsync().Result);
            var get = service.GetGame(result.Id);
            Assert.Equal(1, get.Result.Id);
            Assert.IsType<GamesDTO>(get.Result);
            Assert.Equal("Bryants Deluxe Game Edition", get.Result.Name);

            // Assert.IsType<Games>(actual);
        }

        [Fact]
        public async void CanCreateGuildAndSaveToDatabase()
        {
            DbContextOptions<GuildAPIDbContext> options = new DbContextOptionsBuilder<GuildAPIDbContext>()
                .UseInMemoryDatabase("CanCreateGuildAndSaveToDatabase")
                .Options;
            using GuildAPIDbContext context = new GuildAPIDbContext(options);
            IGames _games;
            GamesService gameService = new GamesService(context);
            GamesDTO gamesDTO = new GamesDTO()
            {
                Name = "Odins Game"
            };
            var createdGame = gameService.Create(gamesDTO);
            GuildService guildService = new GuildService(context, gameService);
            Assert.Equal(1, context.Games.CountAsync().Result);
            GuildsDTO guild = new GuildsDTO()
            {
                Name = "Odin Slayers"
            };
            var creation = guildService.Create(guild);
            var association = gameService.AddGameGuild(createdGame.Result.Id, creation.Result.Id);
            var actual = context.Guilds.FindAsync(creation.Result.Id).Result;
            Assert.Equal(1, context.Guilds.CountAsync().Result);
            Assert.IsType<Guilds>(actual);
            Assert.Equal(1, actual.Id);
            Assert.Equal("Odin Slayers", actual.Name);

        }


    }
}
