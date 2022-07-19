using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class FlightBookingContext : DbContext
    {
        public FlightBookingContext()
        {
        }

        public FlightBookingContext(DbContextOptions<FlightBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBookDetail> TblBookDetails { get; set; }
        public virtual DbSet<TblFlight> TblFlights { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:flightbooking12.database.windows.net,1433;Initial Catalog=FlightBooking;Persist Security Info=False;User ID=vikram;Password=Patil@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblBookDetail>(entity =>
            {
                entity.ToTable("TblBookDetail");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblFlight>(entity =>
            {
                entity.ToTable("TblFlight");

                entity.Property(e => e.Airline).HasMaxLength(50);

                entity.Property(e => e.BussinessSeats).HasMaxLength(50);

                entity.Property(e => e.Days)
                    .HasMaxLength(50)
                    .HasColumnName("days");

                entity.Property(e => e.EndDateTime).HasMaxLength(50);

                entity.Property(e => e.FromPlace).HasMaxLength(50);

                entity.Property(e => e.Instrument).HasMaxLength(50);

                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Meal).HasColumnName("meal");

                entity.Property(e => e.NonBussinessSeats).HasMaxLength(50);

                entity.Property(e => e.StartDateTime).HasMaxLength(50);

                entity.Property(e => e.ToPlace).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("TblLogin");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsAdmin).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
