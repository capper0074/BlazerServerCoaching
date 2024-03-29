﻿// <auto-generated />
using System;
using BlazerServerCoaching.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazerServerCoaching.Migrations
{
    [DbContext(typeof(MatchDbContex))]
    [Migration("20231129115543_test10")]
    partial class test10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazerServerCoaching.Data.Models.Match", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("CTPistol")
                        .HasColumnType("bit");

                    b.Property<int?>("CTSideL")
                        .HasColumnType("int");

                    b.Property<int?>("CTSideW")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Maps")
                        .HasColumnType("int");

                    b.Property<string>("Oppenent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<bool?>("TPistol")
                        .HasColumnType("bit");

                    b.Property<int?>("TSideL")
                        .HasColumnType("int");

                    b.Property<int?>("TSideW")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Matchs");
                });
#pragma warning restore 612, 618
        }
    }
}
