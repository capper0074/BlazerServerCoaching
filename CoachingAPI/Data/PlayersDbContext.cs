using CoachingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CoachingAPI.Data
{
    public class PlayersDbContext(DbContextOptions<PlayersDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Map> Maps { get; set; }

        public DbSet<PlayerMatchStats> PlayerMatchStats { get; set; }
        public DbSet<TeamMatchStats> TeamMatchStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Membership>().ToTable("Membership");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Map>().ToTable("Map");

            modelBuilder.Entity<PlayerMatchStats>().ToTable("PlayerMatchStat");
            modelBuilder.Entity<TeamMatchStats>().ToTable("TeamMatchStat");

            // Configured identity columns
            modelBuilder.Entity<Player>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Team>().Property(t => t.Id).UseIdentityColumn();
            modelBuilder.Entity<Match>().Property(m => m.Id).UseIdentityColumn();

            // Define composite primary key for Membership
            modelBuilder.Entity<Membership>()
                .HasKey(m => new { m.PlayerId, m.TeamId });

            modelBuilder.Entity<PlayerMatchStats>()
                .HasKey(tms => new { tms.PlayerId, tms.MatchId });

            // Define foreign key for TeamMatchStats property in PlayerMatchStats
            modelBuilder.Entity<PlayerMatchStats>()
                .HasOne(pms => pms.TeamMatchStats)
                .WithMany()
                .HasForeignKey(pms => new { pms.TeamId, pms.MatchId })
                .OnDelete(DeleteBehavior.NoAction); // Keep the team match stats when a player's match stats is deleted

            modelBuilder.Entity<TeamMatchStats>()
                .HasKey(tms => new { tms.TeamId, tms.MatchId });

            // Define many-to-many relationship between Match and Team
            modelBuilder.Entity<Match>()
                .HasMany(m => m.Teams) // Match has many relationships to Team, via Teams property
                .WithMany(t => t.Matches); // Team has many relationships to Match, via Matches property

            // Define one-to-many relationship between Team and Match.Winner
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner) // Each Match has one winner
                .WithMany()// The teams don't keep track of what matches they've won, as they have no navigation properties
                .HasForeignKey(m => m.WinnerTeamId) // Specifies the foreign key property in Match
                .OnDelete(DeleteBehavior.NoAction); // Prevents deletion of a the winning team on match deletion

            modelBuilder.Entity<Match>()
                .HasMany(m => m.PlayerMatchStats)
                .WithOne(pps => pps.Match)
                .OnDelete(DeleteBehavior.Cascade); // Ensure that when a match is deleted, the associated PlayerMatchStats are also deleted

            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamMatchStats)
                .WithOne(tps => tps.Match)
                .OnDelete(DeleteBehavior.Cascade); // Ensure that when a match is deleted, the associated TeamMatchStats are also deleted

            base.OnModelCreating(modelBuilder);
        }
    }
}
