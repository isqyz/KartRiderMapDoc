﻿// <auto-generated />
using System;
using KartRiderMapDoc.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KartRiderMapDoc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("KartRiderMapDoc.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AchievementId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("TrackName")
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.PlayerTrackAchievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AchievedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("AchievementId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUnlocked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TrackId");

                    b.ToTable("PlayerTrackAchievements");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lev")
                        .HasColumnType("TEXT");

                    b.Property<int>("Star")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TrackName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.TrackScoreMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackScoreMarks");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.PlayerTrackAchievement", b =>
                {
                    b.HasOne("KartRiderMapDoc.Models.Achievement", "Achievement")
                        .WithMany("PlayerTrackAchievements")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KartRiderMapDoc.Models.Player", "Player")
                        .WithMany("PlayerTrackAchievements")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KartRiderMapDoc.Models.Track", "Track")
                        .WithMany("PlayerTrackAchievements")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("Player");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.TrackScoreMark", b =>
                {
                    b.HasOne("KartRiderMapDoc.Models.Player", "Player")
                        .WithMany("TrackScores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KartRiderMapDoc.Models.Track", "Track")
                        .WithMany("TrackScores")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.Achievement", b =>
                {
                    b.Navigation("PlayerTrackAchievements");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.Player", b =>
                {
                    b.Navigation("PlayerTrackAchievements");

                    b.Navigation("TrackScores");
                });

            modelBuilder.Entity("KartRiderMapDoc.Models.Track", b =>
                {
                    b.Navigation("PlayerTrackAchievements");

                    b.Navigation("TrackScores");
                });
#pragma warning restore 612, 618
        }
    }
}
