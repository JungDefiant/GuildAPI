﻿// <auto-generated />
using System;
using GuildAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuildAPI.Migrations
{
    [DbContext(typeof(GuildAPIDbContext))]
    [Migration("20200803202622_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildAPI.Models.GameGuilds", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GuildId")
                        .HasColumnType("int");

                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<int?>("GuildsId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "GuildId");

                    b.HasIndex("GamesId");

                    b.HasIndex("GuildsId");

                    b.ToTable("GameGuilds");
                });

            modelBuilder.Entity("GuildAPI.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Guild Clashes 2"
                        },
                        new
                        {
                            Id = 2,
                            Name = "The World of NonCraft"
                        },
                        new
                        {
                            Id = 3,
                            Name = "City of Zeroes"
                        });
                });

            modelBuilder.Entity("GuildAPI.Models.Guilds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guilds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Guild of Average People"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BroForce"
                        },
                        new
                        {
                            Id = 3,
                            Name = ""
                        });
                });

            modelBuilder.Entity("GuildAPI.Models.GameGuilds", b =>
                {
                    b.HasOne("GuildAPI.Models.Games", "Games")
                        .WithMany("GameGuilds")
                        .HasForeignKey("GamesId");

                    b.HasOne("GuildAPI.Models.Guilds", "Guilds")
                        .WithMany("GameGuilds")
                        .HasForeignKey("GuildsId");
                });
#pragma warning restore 612, 618
        }
    }
}
