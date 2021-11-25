using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarRent3.Model
{
    public partial class CarRentdbContext : DbContext
    {
        public CarRentdbContext()
        {
        }

        public CarRentdbContext(DbContextOptions<CarRentdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Clinet> Clinets { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<VwDistinctCategory> VwDistinctCategories { get; set; }
        public virtual DbSet<VwDistinctModel> VwDistinctModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CarRentdb;User=SA;Password=Amani1419+;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.DailyRentPrice).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Clinet>(entity =>
            {
                entity.ToTable("Clinet");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.FinshDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.CarUniqe)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.CarUniqeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__History__CarUniq__300424B4");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.CarUniqeId)
                    .HasName("PK__Inventor__D7B37B889257756C");

                entity.ToTable("Inventory");

                entity.Property(e => e.AvalibleDate).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__CarId__403A8C7D");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__CityI__31EC6D26");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__Location__F2D21B762F0FA771");

                entity.ToTable("Location");

                entity.Property(e => e.CityName).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.OrderSubmitDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Orders_Car");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Orders_Location");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Orders_Clinet");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__PaymentI__4F7CD00D");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.CardExpirDate).HasColumnType("date");

                entity.Property(e => e.CardNumber).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PaymentType).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Payment_Clinet");
            });

            modelBuilder.Entity<VwDistinctCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_distinctCategories");
            });

            modelBuilder.Entity<VwDistinctModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_distinctModel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
