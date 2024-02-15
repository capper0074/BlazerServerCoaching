using CoachingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachingAPI.Data
{
    public class PlayersDbContext : DbContext
    {
        public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<PlayerMapStats> PlayerMapStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.CurrentTeam);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Standins)
                .WithOne(); // No corresponding navigation property

            modelBuilder.Entity<PlayerStats>()
                .HasKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerMapStats>()
                .HasKey(pms => new { pms.PlayerId, pms.MapName });

            base.OnModelCreating(modelBuilder);
        }
    }
}
