using CoachingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CoachingAPI.Data
{
    public class PlayersDbContext : DbContext
    {
        public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<PlayerMapStats> PlayerMapStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Membership>().ToTable("Membership");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Map>().ToTable("Map");
            modelBuilder.Entity<PlayerStats>().ToTable("PlayerStatistics");
            modelBuilder.Entity<PlayerMapStats>().ToTable("PlayerMapStatistics");

            modelBuilder.Entity<PlayerStats>()
                .HasKey(ps => ps.PlayerId);

            // Define composite primary key for PlayerMapStats
            modelBuilder.Entity<PlayerMapStats>()
                .HasKey(pms => new { pms.PlayerId, pms.MapName });

            // Define composite primary key for Membership
            modelBuilder.Entity<Membership>()
                .HasKey(m => new { m.PlayerId, m.TeamName });

            // Define many-to-many relationship between Match and Team
            modelBuilder.Entity<Match>()
                .HasMany(m => m.Teams) // Match has many relationships to Team, via Teams property
                .WithMany(t => t.Matches); // Team has many relationships to Match, via Matches property

            // Define one-to-many relationship between Team and Match.Winner
            modelBuilder.Entity<Team>()
                .HasMany(t => t.WonMatches) // Team has many relationships to Match, via WonMatches property
                .WithOne(m => m.Winner) // Match has a single relationship to Team, via Winner property
                .HasForeignKey(m => m.WinnerTeamName); // Specify the foreign key property in Match


            base.OnModelCreating(modelBuilder);
        }
    }
}
