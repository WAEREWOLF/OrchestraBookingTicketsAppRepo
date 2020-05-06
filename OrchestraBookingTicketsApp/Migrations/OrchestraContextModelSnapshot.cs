﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrchestraBookingTicketsApp.DataAccess;

namespace OrchestraBookingTicketsApp.Migrations
{
    [DbContext(typeof(OrchestraContext))]
    partial class OrchestraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Award", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("LeadArtistId");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("AwardId");

                    b.HasIndex("LeadArtistId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.BuildingFacilities", b =>
                {
                    b.Property<int>("BuildingFacilitiesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasAirConditioning");

                    b.Property<bool>("HasSmokingArea");

                    b.Property<int>("LocationId");

                    b.Property<int>("MaxSeats");

                    b.HasKey("BuildingFacilitiesId");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("BuildingFacilities");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("OrchestraId");

                    b.Property<string>("Type");

                    b.HasKey("InstrumentId");

                    b.HasIndex("OrchestraId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.LeadArtist", b =>
                {
                    b.Property<int>("LeadArtistId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<int>("OrchestraId");

                    b.HasKey("LeadArtistId");

                    b.HasIndex("OrchestraId")
                        .IsUnique();

                    b.ToTable("LeadArtists");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("OrchestraId");

                    b.HasKey("LocationId");

                    b.HasIndex("OrchestraId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Orchestra", b =>
                {
                    b.Property<int>("OrchestraId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("OrchestraHistoriesOrchestraHistoryId");

                    b.Property<int>("Price");

                    b.Property<string>("Title");

                    b.HasKey("OrchestraId");

                    b.HasIndex("OrchestraHistoriesOrchestraHistoryId");

                    b.ToTable("Orchestras");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.OrchestraHistory", b =>
                {
                    b.Property<int>("OrchestraHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Rating");

                    b.Property<int>("SeatNumber");

                    b.Property<string>("Status");

                    b.Property<int?>("UsersUserId");

                    b.HasKey("OrchestraHistoryId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("OrchestraHistories");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Award", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.LeadArtist", "Artists")
                        .WithMany("Awards")
                        .HasForeignKey("LeadArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.BuildingFacilities", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.Location", "Location")
                        .WithOne("BuildingFacilities")
                        .HasForeignKey("OrchestraBookingTicketsApp.Models.BuildingFacilities", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Instrument", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.Orchestra", "Orchestra")
                        .WithMany("Instruments")
                        .HasForeignKey("OrchestraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.LeadArtist", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.Orchestra", "Orchestra")
                        .WithOne("LeadArtist")
                        .HasForeignKey("OrchestraBookingTicketsApp.Models.LeadArtist", "OrchestraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Location", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.Orchestra", "Orchestra")
                        .WithMany("Locations")
                        .HasForeignKey("OrchestraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.Orchestra", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.OrchestraHistory", "OrchestraHistories")
                        .WithMany("Orchestras")
                        .HasForeignKey("OrchestraHistoriesOrchestraHistoryId");
                });

            modelBuilder.Entity("OrchestraBookingTicketsApp.Models.OrchestraHistory", b =>
                {
                    b.HasOne("OrchestraBookingTicketsApp.Models.User", "Users")
                        .WithMany("OrchestraHistories")
                        .HasForeignKey("UsersUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
