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
        public PlayersAPIContext (DbContextOptions<PlayersAPIContext> options)
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
            modelBuilder.Entity<Player>()
                .HasOne(p => p.CurrentTeam)
                .WithMany(t => t.Players)  // Or Standins, depending on your desired relationship
                .HasForeignKey(p => p.CurrentTeamId);
        }

    }
}
