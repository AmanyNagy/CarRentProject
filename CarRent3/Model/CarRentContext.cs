using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarRent3.Model
{
    public partial class CarRentContext : DbContext
    {
        public CarRentContext()
        {
        }

        public CarRentContext(DbContextOptions<CarRentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Clinet> Clinets { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ViCarForCategorty> ViCarForCategorties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CarRent;User=SA;Password=Amani1419+;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Car__Category__31EC6D26");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Cart__CarId__36B12243");

                entity.HasOne(d => d.Clinet)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ClinetId)
                    .HasConstraintName("FK__Cart__ClinetId__37A5467C");

                entity.HasOne(d => d.DeliverCityNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.DeliverCity)
                    .HasConstraintName("FK__Cart__DeliverCit__38996AB5");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            modelBuilder.Entity<Clinet>(entity =>
            {
                entity.ToTable("Clinet");

                entity.Property(e => e.Name).IsRequired();
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
                    .HasConstraintName("FK__History__CarUniq__4222D4EF");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.CarUniqeId)
                    .HasName("PK__Inventor__D7B37B88824AD2A7");

                entity.ToTable("Inventory");

                entity.Property(e => e.DateFinish).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__CarId__3E52440B");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__CityI__3F466844");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__Location__F2D21B76D6F829FC");

                entity.ToTable("Location");

                entity.Property(e => e.CityName).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderFinshDate).HasColumnType("date");

                entity.Property(e => e.OrderStartDate).HasColumnType("date");

                entity.Property(e => e.OrderSubmitDate).HasColumnType("date");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__CartId__4BAC3F29");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__PaymentI__4CA06362");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.CardExpirDate).HasColumnType("date");

                entity.Property(e => e.NameCard).IsRequired();

                entity.Property(e => e.PaymentType).IsRequired();

                entity.HasOne(d => d.Clinet)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClinetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__ClinetI__48CFD27E");
            });

            modelBuilder.Entity<ViCarForCategorty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vi_CarForCategorty");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
