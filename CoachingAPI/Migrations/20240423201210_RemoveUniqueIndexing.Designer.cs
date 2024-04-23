﻿// <auto-generated />
using System;
using CoachingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoachingAPI.Migrations
{
    [DbContext(typeof(PlayersDbContext))]
    [Migration("20240423201210_RemoveUniqueIndexing")]
    partial class RemoveUniqueIndexing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MapName")
                        .HasColumnType("int");

                    b.Property<int>("MatchPlatform")
                        .HasColumnType("int");

                    b.Property<int>("WinnerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MapName");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.Membership", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.PlayerMatchStats", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("Headshots")
                        .HasColumnType("int");

                    b.Property<double>("KDRatio")
                        .HasColumnType("float");

                    b.Property<double>("KRRatio")
                        .HasColumnType("float");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "MatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId", "MatchId")
                        .IsUnique();

                    b.HasIndex("TeamId", "MatchId");

                    b.ToTable("PlayerMatchStats", (string)null);
                });

            modelBuilder.Entity("CoachingAPI.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

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

                    b.HasKey("TeamId", "MatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId", "MatchId")
                        .IsUnique();

                    b.ToTable("TeamMatchStats", (string)null);
                });

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.Property<int>("MatchesId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("MatchesId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("MatchTeam");
                });

            modelBuilder.Entity("CoachingAPI.Models.Match", b =>
                {
                    b.HasOne("CoachingAPI.Models.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
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
                    b.HasOne("CoachingAPI.Models.Match", "Match")
                        .WithMany("PlayerMatchStats")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.TeamMatchStats", "TeamMatchStats")
                        .WithMany()
                        .HasForeignKey("TeamId", "MatchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");

                    b.Navigation("TeamMatchStats");
                });

            modelBuilder.Entity("CoachingAPI.Models.TeamMatchStats", b =>
                {
                    b.HasOne("CoachingAPI.Models.Match", "Match")
                        .WithOne("TeamMatchStats")
                        .HasForeignKey("CoachingAPI.Models.TeamMatchStats", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingAPI.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MatchTeam", b =>
                {
                    b.HasOne("CoachingAPI.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
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
