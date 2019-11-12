using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        protected FootballBettingContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Connection);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);


            });

            builder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity.HasMany(t => t.Teams)
                 .WithOne(t => t.Town); //I dont know

                entity.HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);

            });

            builder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.PositionId);
            });

            builder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

                entity.HasOne(p => p.Posititon)
                .WithMany(pos => pos.Players)
                .HasForeignKey(p => p.PositionId);



            });

            builder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity.Property(t => t.Initials)
                .HasMaxLength(3)
                .IsRequired(true);

                entity.HasOne(c => c.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams)
                .HasForeignKey(c => c.PrimaryKitColorId);

                entity.HasOne(c => c.SecondaryKitColor)
            .WithMany(t => t.SecondaryKitTeams)
            .HasForeignKey(c => c.SecondaryKitColorId);

                entity.HasOne(t => t.Town)
                .WithMany(to => to.Teams)
                .HasForeignKey(t => t.TownId);

            });

            builder.Entity<Color>(entity =>
            {
                entity.HasKey(c => c.ColorId);

                entity.HasMany(c => c.PrimaryKitTeams)
                    .WithOne(t => t.PrimaryKitColor);

                entity.HasMany(c => c.SecondaryKitTeams)
             .WithOne(t => t.SecondaryKitColor);


            });

            builder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });

                entity.HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

                entity.HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);
            });

            builder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId);

                entity.HasOne(g => g.AwayTeam)
               .WithMany(t => t.AwayGames)
               .HasForeignKey(g => g.AwayTeamId);
            });

            builder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);

                entity
                .Property(b => b.Prediction)
                .IsRequired(true);

                entity.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
            });
        }
    }
}
