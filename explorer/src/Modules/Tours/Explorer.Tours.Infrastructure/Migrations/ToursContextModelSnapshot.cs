﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Explorer.Tours.Infrastructure.Migrations
{
    [DbContext(typeof(ToursContext))]
    partial class ToursContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tours")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EquipmentTour", b =>
                {
                    b.Property<long>("EquipmentListId")
                        .HasColumnType("bigint");

                    b.Property<long>("ToursId")
                        .HasColumnType("bigint");

                    b.HasKey("EquipmentListId", "ToursId");

                    b.HasIndex("ToursId");

                    b.ToTable("TourEquipment", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Campaign", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("AverageDifficulty")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Distance")
                        .HasColumnType("double precision");

                    b.Property<List<long>>("EquipmentIds")
                        .IsRequired()
                        .HasColumnType("bigint[]");

                    b.Property<List<long>>("KeyPointIds")
                        .IsRequired()
                        .HasColumnType("bigint[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<long>>("TourIds")
                        .IsRequired()
                        .HasColumnType("bigint[]");

                    b.Property<long>("TouristId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Campaigns", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Equipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipment", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Facility", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Facilities", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Preference", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("BoatRating")
                        .HasColumnType("integer");

                    b.Property<int>("CarRating")
                        .HasColumnType("integer");

                    b.Property<int>("CyclingRating")
                        .HasColumnType("integer");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("integer");

                    b.Property<List<string>>("SelectedTags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("WalkingRating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Preferences", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicFacilityNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("boolean");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderPicture")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("PublicFacilityNotifications", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicFacilityRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("FacilityId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId")
                        .IsUnique();

                    b.ToTable("PublicFacilityRequests", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicKeyPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<string>("LocationAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("PublicKeyPoints", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicKeyPointNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("boolean");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderPicture")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("PublicKeyPointNotifications", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicKeyPointRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("KeyPointId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("KeyPointId")
                        .IsUnique();

                    b.ToTable("PublicKeyPointRequests", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("CommentDate")
                        .HasColumnType("date");

                    b.Property<List<string>>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<long>("TourId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("TourVisitDate")
                        .HasColumnType("date");

                    b.Property<long>("TouristId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Reviews", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Subscriber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("LastTimeSent")
                        .HasColumnType("date");

                    b.Property<long>("TouristId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Subscribers", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.TourExecutionSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsCampaign")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastActivity")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("NextKeyPointId")
                        .HasColumnType("bigint");

                    b.Property<double>("Progress")
                        .HasColumnType("double precision");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("TourId")
                        .HasColumnType("bigint");

                    b.Property<long>("TouristId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TourExecutionSessions", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.TouristEquipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<List<int>>("EquipmentIds")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("TouristId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TouristEquipments", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.TouristPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<long>("TouristId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TouristPositions", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Tours.KeyPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasEncounter")
                        .HasColumnType("boolean");

                    b.Property<bool>("HaveSecret")
                        .HasColumnType("boolean");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsEncounterRequired")
                        .HasColumnType("boolean");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<string>("LocationAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Order")
                        .HasColumnType("bigint");

                    b.Property<KeyPointSecret>("Secret")
                        .HasColumnType("jsonb");

                    b.Property<long>("TourId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("KeyPoints", "tours");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Tours.Tour", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ArchiveDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<double>("Distance")
                        .HasColumnType("double precision");

                    b.Property<ICollection<TourDuration>>("Durations")
                        .HasColumnType("jsonb");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Tags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("Tours", "tours");
                });

            modelBuilder.Entity("EquipmentTour", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.Equipment", null)
                        .WithMany()
                        .HasForeignKey("EquipmentListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Explorer.Tours.Core.Domain.Tours.Tour", null)
                        .WithMany()
                        .HasForeignKey("ToursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicFacilityNotification", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.PublicFacilityRequest", null)
                        .WithOne()
                        .HasForeignKey("Explorer.Tours.Core.Domain.PublicFacilityNotification", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicFacilityRequest", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.Facility", null)
                        .WithOne()
                        .HasForeignKey("Explorer.Tours.Core.Domain.PublicFacilityRequest", "FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicKeyPointNotification", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.PublicKeyPointRequest", null)
                        .WithOne()
                        .HasForeignKey("Explorer.Tours.Core.Domain.PublicKeyPointNotification", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.PublicKeyPointRequest", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.Tours.KeyPoint", null)
                        .WithOne()
                        .HasForeignKey("Explorer.Tours.Core.Domain.PublicKeyPointRequest", "KeyPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Review", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.Tours.Tour", null)
                        .WithMany("Reviews")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Tours.KeyPoint", b =>
                {
                    b.HasOne("Explorer.Tours.Core.Domain.Tours.Tour", "Tour")
                        .WithMany("KeyPoints")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Explorer.Tours.Core.Domain.Tours.Tour", b =>
                {
                    b.Navigation("KeyPoints");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
