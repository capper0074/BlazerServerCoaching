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
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Map>().ToTable("Map");
            modelBuilder.Entity<PlayerStats>().ToTable("PlayerStatistics");
            modelBuilder.Entity<PlayerMapStats>().ToTable("PlayerMapStatistics");

            // Do something smart plz.

            modelBuilder.Entity<PlayerStats>()
                .HasKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerMapStats>()
                .HasKey(pms => new { pms.PlayerId, pms.MapName });

            modelBuilder.Entity<Membership>()
                .HasKey(m => new { m.PlayerId, m.TeamName });

            base.OnModelCreating(modelBuilder);
        }
    }
}
