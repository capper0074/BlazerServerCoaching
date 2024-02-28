using CoachingAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
        public DbSet<GeneralStats> GeneralStats { get; set; }
        public DbSet<MapStats> MapStats { get; set; }
        public DbSet<PlayerPerformanceStats> PlayerPerformanceStats { get; set; }
        public DbSet<TeamPerformanceStats> TeamPerformanceStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Membership>().ToTable("Membership");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Map>().ToTable("Map");

            //modelBuilder.Entity<GeneralStats>()
            //    .HasKey(ps => ps.PlayerGuid);

            // Define composite primary key for PlayerMapStats
            modelBuilder.Entity<MapStats>()
                .HasKey(pms => new { pms.FK_GeneralStatsId, pms.FK_MapName });

            // Define composite primary key for Membership
            modelBuilder.Entity<Membership>()
                .HasKey(m => new { m.PlayerId, m.TeamName });

            modelBuilder.Entity<PlayerPerformanceStats>()
                .HasKey(pps => new { pps.FK_PlayerId, pps.FK_MatchId });

            modelBuilder.Entity<TeamPerformanceStats>()
                .HasKey(tps => new { tps.FK_TeamName, tps.FK_MatchId });

            // Define many-to-many relationship between Match and Team
            modelBuilder.Entity<Match>()
                .HasMany(m => m.Teams) // Match has many relationships to Team, via Teams property
                .WithMany(t => t.Matches); // Team has many relationships to Match, via Matches property

            // Define one-to-many relationship between Team and Match.Winner
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner) // Each Match has one winner
                .WithMany() // The teams don't keep track of what matches they've won, as they have no navigation properties
                .HasForeignKey(m => m.FK_WinnerTeamName); // Specifies the foreign key property in Match

            modelBuilder.Entity<Match>()
                .HasMany(m => m.PlayerPerformanceStats)
                .WithOne(pps => pps.RelatedMatch);

            modelBuilder.Entity<Match>()
                .HasMany(m => m.TeamPerformanceStats)
                .WithOne(tps => tps.RelatedMatch);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Stats)
                .WithOne();

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Stats)
                .WithOne();

            //modelBuilder.Entity<Team>()
            //    .HasOne(t => t.Stats)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
