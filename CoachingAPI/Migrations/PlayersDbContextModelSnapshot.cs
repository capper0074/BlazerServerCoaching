﻿// <auto-generated />
using System;
using CoachingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoachingAPI.Migrations
{
    [DbContext(typeof(PlayersDbContext))]
    partial class PlayersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoachingAPI.Models.Map", b =>
                {
                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.HasKey("Name");

                    b.ToTable("Map", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.Match", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_MapName")
                        .HasColumnType("int");

                    b.Property<Guid>("FK_WinnerTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MatchPlatform")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("FK_MapName");

                    b.HasIndex("FK_WinnerTeamId");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.Membership", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MembershipType")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Membership", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCoach")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.PlayerMatchStats", b =>
                {
                    b.Property<Guid>("FK_PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<Guid>("FK_TeamMatchStats_TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Headshots")
                        .HasColumnType("int");

                    b.Property<double>("KDRatio")
                        .HasColumnType("float");

                    b.Property<double>("KRRatio")
                        .HasColumnType("float");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.HasKey("FK_PlayerId", "FK_MatchId");

                    b.HasIndex("FK_MatchId", "FK_TeamMatchStats_TeamId");

                    b.ToTable("PlayerPerformanceStats");
                });

            modelBuilder.Entity("CoachingAPI.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMatchMaking")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.TeamMatchStats", b =>
                {
                    b.Property<Guid>("FK_TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_MatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CTPistolRoundWon")
                        .HasColumnType("int");

                    b.Property<int>("CTRoundsPlayed")
                        .HasColumnType("int");

                    b.Property<int>("CTRoundsWon")
                        .HasColumnType("int");

                    b.Property<int>("TPistolRoundWon")
                        .HasColumnType("int");

                    b.Property<int>("TRoundsPlayed")
                        .HasColumnType("int");

                    b.Property<int>("TRoundsWins")
                        .HasColumnType("int");

                    b.HasKey("FK_TeamId", "FK_MatchId");

                    b.HasIndex("FK_MatchId")
                        .IsUnique();

                    b.ToTable("TeamPerformanceStats");
                });

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.Property<Guid>("MatchesMatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MatchesMatchId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("MatchTeam");
                });

            modelBuilder.Entity("CoachingAPI.Models.Match", b =>
                {
                    b.HasOne("CoachingAPI.Models.Map", "Map")
                        .WithMany()
                        .HasForeignKey("FK_MapName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("FK_WinnerTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("CoachingAPI.Models.Membership", b =>
                {
                    b.HasOne("CoachingAPI.Models.Player", "Player")
                        .WithMany("Memberships")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Team", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("CoachingAPI.Models.PlayerMatchStats", b =>
                {
                    b.HasOne("CoachingAPI.Models.Match", "RelatedMatch")
                        .WithMany("PlayerMatchStats")
                        .HasForeignKey("FK_MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Player", "RelatedPlayer")
                        .WithMany()
                        .HasForeignKey("FK_PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.TeamMatchStats", "TeamMatchStats")
                        .WithMany()
                        .HasForeignKey("FK_MatchId", "FK_TeamMatchStats_TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedMatch");

                    b.Navigation("RelatedPlayer");

                    b.Navigation("TeamMatchStats");
                });

            modelBuilder.Entity("CoachingAPI.Models.TeamMatchStats", b =>
                {
                    b.HasOne("CoachingAPI.Models.Match", "RelatedMatch")
                        .WithOne("TeamMatchStats")
                        .HasForeignKey("CoachingAPI.Models.TeamMatchStats", "FK_MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Team", "RelatedTeam")
                        .WithMany()
                        .HasForeignKey("FK_TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedMatch");

                    b.Navigation("RelatedTeam");
                });

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.HasOne("CoachingAPI.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoachingAPI.Models.Match", b =>
                {
                    b.Navigation("PlayerMatchStats");

                    b.Navigation("TeamMatchStats");
                });

            modelBuilder.Entity("CoachingAPI.Models.Player", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("CoachingAPI.Models.Team", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
