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

        public DbSet<PlayerMatchStats> PlayerMatchStats { get; set; }
        public DbSet<TeamMatchStats> TeamMatchStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Membership>().ToTable("Membership");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Map>().ToTable("Map");

            // Define composite primary key for Membership
            modelBuilder.Entity<Membership>()
                .HasKey(m => new { m.FKPlayerId, m.FKTeamId });

            modelBuilder.Entity<PlayerMatchStats>()
                .HasKey(tms => new { tms.FKPlayerId, tms.FKMatchId });

            // Define foreign key for TeamMatchStats property in PlayerMatchStats
            modelBuilder.Entity<PlayerMatchStats>()
                .HasOne(pms => pms.TeamMatchStats)
                .WithMany()
                .HasForeignKey(pms => new { pms.FKTeamId, pms.FKMatchId })
                .OnDelete(DeleteBehavior.NoAction); // Keep the team match stats when a player's match stats is deleted

            modelBuilder.Entity<TeamMatchStats>()
                .HasKey(tms => new { tms.FKTeamId, tms.FKMatchId });

            // Define many-to-many relationship between Match and Team
            modelBuilder.Entity<Match>()
                .HasMany(m => m.Teams) // Match has many relationships to Team, via Teams property
                .WithMany(t => t.Matches); // Team has many relationships to Match, via Matches property

            // Define one-to-many relationship between Team and Match.Winner
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner) // Each Match has one winner
                .WithMany()// The teams don't keep track of what matches they've won, as they have no navigation properties
                .HasForeignKey(m => m.FKTeamWinnerId) // Specifies the foreign key property in Match
                .OnDelete(DeleteBehavior.NoAction); // Prevents deletion of a the winning team on match deletion

            modelBuilder.Entity<Match>()
                .HasMany(m => m.PlayerMatchStats)
                .WithOne(pps => pps.Match)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamMatchStats)
                .WithOne(tps => tps.Match)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
