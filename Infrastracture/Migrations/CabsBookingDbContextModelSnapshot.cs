﻿// <auto-generated />
using System;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastracture.Migrations
{
    [DbContext(typeof(CabsBookingDbContext))]
    partial class CabsBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Bookings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("CabTypesCabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("PlacesPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CabTypesCabTypeId");

                    b.HasIndex("PlacesPlaceId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ApplicationCore.BookingsHistory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("CabTypesCabTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Charge")
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("Comp_time")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("PlacesPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CabTypesCabTypeId");

                    b.HasIndex("PlacesPlaceId");

                    b.ToTable("BookingsHistory");
                });

            modelBuilder.Entity("ApplicationCore.CabTypes", b =>
                {
                    b.Property<int>("CabTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CabTypeName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CabTypeId");

                    b.ToTable("CabTypes");
                });

            modelBuilder.Entity("ApplicationCore.Places", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlaceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ApplicationCore.Bookings", b =>
                {
                    b.HasOne("ApplicationCore.CabTypes", "CabTypes")
                        .WithMany("Bookings")
                        .HasForeignKey("CabTypesCabTypeId");

                    b.HasOne("ApplicationCore.Places", "Places")
                        .WithMany("Bookings")
                        .HasForeignKey("PlacesPlaceId");

                    b.Navigation("CabTypes");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("ApplicationCore.BookingsHistory", b =>
                {
                    b.HasOne("ApplicationCore.CabTypes", "CabTypes")
                        .WithMany("BookingsHistory")
                        .HasForeignKey("CabTypesCabTypeId");

                    b.HasOne("ApplicationCore.Places", "Places")
                        .WithMany("BookingsHistory")
                        .HasForeignKey("PlacesPlaceId");

                    b.Navigation("CabTypes");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("ApplicationCore.CabTypes", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("BookingsHistory");
                });

            modelBuilder.Entity("ApplicationCore.Places", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("BookingsHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
