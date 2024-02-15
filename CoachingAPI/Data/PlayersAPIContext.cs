using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoachingAPI.Models;

namespace CoachingAPI.Data
{
    public class PlayersAPIContext : DbContext
    {
        public PlayersAPIContext(DbContextOptions<PlayersAPIContext> options)
            : base(options)
        {


        }

        public DbSet<Player> Player { get; set; } = default!;
        public DbSet<Map> Map { get; set; } = default!;
        public DbSet<Match> Match { get; set; }
        public DbSet<PlayerMapStats> PlayerMapStats { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTeamHistory>()
                .HasOne(p => p.Player)
                .WithMany(p => p.TeamHistory)
                .HasForeignKey(p => p.PlayerId);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.CurrentTeam)
                .WithOne(t => t.Player)
                .HasForeignKey<Player>(p => p.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey(m => m.WinnerID)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
