using ApplicationCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Infrastracture.Data
{
    public class CabsBookingDbContext : DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options) : base(options)
        {

        }

        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistories { get; set; }
        public DbSet<CabTypes>  CabTypes { get; set; }
        public DbSet<Places> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Places>().ToTable("Places");
            builder.Entity<CabTypes>().ToTable("CabTypes");
            builder.Entity<Bookings>().ToTable("Bookings");
            builder.Entity<BookingsHistory>(ConfigureBookingsHistory);
        }

        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistory> obj)
        {
            obj.ToTable("BookingsHistory");
            obj.Property(bh => bh.Charge).HasColumnType("decimal(19,4)");
        }

    }
}
