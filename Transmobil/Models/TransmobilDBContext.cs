using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Transmobil.Models
{
    public partial class TransmobilDBContext : DbContext
    {
        public TransmobilDBContext()
        {
        }

        public TransmobilDBContext(DbContextOptions<TransmobilDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Renter> Renters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TransmobilDB;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TransmobilDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.IdCar)
                    .HasName("PK__Koli__617AB8615B420322");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CostPerKm).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cars__IdCategory__2B3F6F97");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Categori__CBD74706D8AB7A48");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("PK__Contract__856E762C1FFDB336");

                entity.Property(e => e.RentDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdCar)
                    .HasConstraintName("FK__Contracts__IdCar__2C3393D0");

                entity.HasOne(d => d.IdRenterNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdRenter)
                    .HasConstraintName("FK__Dogovori__IdNaem__2C3393D0");
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.HasKey(e => e.IdRenter)
                    .HasName("PK__Naematel__5C4872351378BC08");

                entity.Property(e => e.IsCompany)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.RenterAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RenterName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
