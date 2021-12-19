using System;
using HealthyToothsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class HealphyTeethContext : DbContext
    {
        public HealphyTeethContext()
        {
        }

        public HealphyTeethContext(DbContextOptions<HealphyTeethContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabinet> Cabinets { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientsVisit> ClientsVisits { get; set; }
        public virtual DbSet<Consumable> Consumables { get; set; }
        public virtual DbSet<ConsumableType> ConsumableTypes { get; set; }
        public virtual DbSet<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<SpentConsumablesForVisit> SpentConsumablesForVisits { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<VisitType> VisitTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<ConsumablesInStorage> ConsumablesInStorages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.ToTable("Cabinet");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientFullName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientsVisit>(entity =>
            {
                entity.HasKey(e => e.ClientVisitId);

                entity.ToTable("ClientsVisit");
                entity.Property(e => e.VisitDate).HasColumnType("datetime");

                entity.HasOne(d => d.VisitType)
                    .WithMany(p => p.ClientsVisits)
                    .HasForeignKey(d => d.VisitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientsVisit_VisitType");
            });

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.ToTable("Consumable");

                entity.Property(e => e.ConsumableName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConsumableType)
                    .WithMany(p => p.Consumables)
                    .HasForeignKey(d => d.ConsumableTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consumable_ConsumableType");
            });

            modelBuilder.Entity<ConsumableType>(entity =>
            {
                entity.ToTable("ConsumableType");

                entity.Property(e => e.ConsumableTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConsumablesInDelivery>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryId, e.ConsumableId });

                entity.ToTable("ConsumablesInDelivery");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.ConsumablesInDeliveries)
                    .HasForeignKey(d => d.ConsumableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsumablesInDelivery_Consumable");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.ConsumablesInDeliveries)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsumablesInDelivery_Delivery");
            });

            modelBuilder.Entity<ConsumablesInStorage>(entity =>
            {
                entity.HasKey(e => new { e.StorageId, e.ConsumableId });
            });
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.Property(e => e.DeliveryId).ValueGeneratedNever();

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_Supplier");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("Record");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Record_Client");
                entity.HasOne(d => d.Client)
                .WithMany(p => p.Records)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SpentConsumablesForVisit>(entity =>
            {
                entity.HasKey(e => new { e.СonsumableId, e.VisitId });

                entity.ToTable("SpentConsumablesForVisit");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.SpentConsumablesForVisits)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpentConsumablesForVisit_ClientsVisit");

                entity.HasOne(d => d.Сonsumable)
                    .WithMany(p => p.SpentConsumablesForVisits)
                    .HasForeignKey(d => d.СonsumableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpentConsumablesForVisit_Consumable");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VisitType>(entity =>
            {
                entity.ToTable("VisitType");

                entity.Property(e => e.VisitTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Role> Role { get; set; }
    }
}
