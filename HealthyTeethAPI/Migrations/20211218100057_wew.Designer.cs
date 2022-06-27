﻿// <auto-generated />
using System;
using HealthyTeethAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthyTeethAPI.Migrations
{
    [DbContext(typeof(HealphyTeethContext))]
    [Migration("20211218100057_wew")]
    partial class wew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthyTeethAPI.Data.Cabinet", b =>
                {
                    b.Property<int>("CabinetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CabinetNumber")
                        .HasColumnType("int");

                    b.HasKey("CabinetId");

                    b.ToTable("Cabinet");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFullName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("ClientGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ClientsVisit", b =>
                {
                    b.Property<int>("ClientVisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime");

                    b.Property<int>("VisitTypeId")
                        .HasColumnType("int");

                    b.HasKey("ClientVisitId");

                    b.HasIndex("VisitTypeId");

                    b.HasIndex(new[] { "RecordId" }, "IX_Record")
                        .IsUnique();

                    b.ToTable("ClientsVisit");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Consumable", b =>
                {
                    b.Property<int>("ConsumableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConsumableName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ConsumableTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ConsumableId");

                    b.HasIndex("ConsumableTypeId");

                    b.ToTable("Consumable");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ConsumableType", b =>
                {
                    b.Property<int>("ConsumableTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConsumableTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ConsumableTypeId");

                    b.ToTable("ConsumableType");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ConsumablesInDelivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("ConsumableId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("DeliveryId", "ConsumableId");

                    b.HasIndex("ConsumableId");

                    b.ToTable("ConsumablesInDelivery");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ConsumablesInStorage", b =>
                {
                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<int>("ConsumableId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("StorageId", "ConsumableId");

                    b.HasIndex("ConsumableId");

                    b.ToTable("ConsumablesInStorages");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("DeliveryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime");

                    b.HasKey("RecordId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.SpentConsumablesForVisit", b =>
                {
                    b.Property<int>("СonsumableId")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("СonsumableId", "VisitId");

                    b.HasIndex("VisitId");

                    b.ToTable("SpentConsumablesForVisit");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Storage", b =>
                {
                    b.Property<int>("StorageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StorageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StorageId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.VisitType", b =>
                {
                    b.Property<int>("VisitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VisitTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("VisitTypeId");

                    b.ToTable("VisitType");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Accountant", b =>
                {
                    b.HasBaseType("HealthyTeethAPI.Data.Employee");

                    b.ToTable("Accountant");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Administrator", b =>
                {
                    b.HasBaseType("HealthyTeethAPI.Data.Employee");

                    b.Property<string>("PersonalKey")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Doctor", b =>
                {
                    b.HasBaseType("HealthyTeethAPI.Data.Employee");

                    b.Property<int>("CabinetId")
                        .HasColumnType("int");

                    b.HasIndex("CabinetId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ClientsVisit", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Record", "Record")
                        .WithOne("ClientsVisit")
                        .HasForeignKey("HealthyTeethAPI.Data.ClientsVisit", "RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyTeethAPI.Data.VisitType", "VisitType")
                        .WithMany("ClientsVisits")
                        .HasForeignKey("VisitTypeId")
                        .HasConstraintName("FK_ClientsVisit_VisitType")
                        .IsRequired();

                    b.Navigation("Record");

                    b.Navigation("VisitType");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Consumable", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.ConsumableType", "ConsumableType")
                        .WithMany("Consumables")
                        .HasForeignKey("ConsumableTypeId")
                        .HasConstraintName("FK_Consumable_ConsumableType")
                        .IsRequired();

                    b.Navigation("ConsumableType");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ConsumablesInDelivery", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Consumable", "Consumable")
                        .WithMany("ConsumablesInDeliveries")
                        .HasForeignKey("ConsumableId")
                        .HasConstraintName("FK_ConsumablesInDelivery_Consumable")
                        .IsRequired();

                    b.HasOne("HealthyTeethAPI.Data.Delivery", "Delivery")
                        .WithMany("ConsumablesInDeliveries")
                        .HasForeignKey("DeliveryId")
                        .HasConstraintName("FK_ConsumablesInDelivery_Delivery")
                        .IsRequired();

                    b.Navigation("Consumable");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ConsumablesInStorage", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Consumable", "Consumable")
                        .WithMany("ConsumablesInStorages")
                        .HasForeignKey("ConsumableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyTeethAPI.Data.Storage", "Storage")
                        .WithMany("ConsumablesInStorages")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumable");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Delivery", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Supplier", "Supplier")
                        .WithMany("Deliveries")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_Delivery_Supplier")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Employee", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Record", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Client", "Client")
                        .WithMany("Records")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Record_Client")
                        .IsRequired();

                    b.HasOne("HealthyTeethAPI.Data.Doctor", "Doctor")
                        .WithMany("Records")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.SpentConsumablesForVisit", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.ClientsVisit", "Visit")
                        .WithMany("SpentConsumablesForVisits")
                        .HasForeignKey("VisitId")
                        .HasConstraintName("FK_SpentConsumablesForVisit_ClientsVisit")
                        .IsRequired();

                    b.HasOne("HealthyTeethAPI.Data.Consumable", "Сonsumable")
                        .WithMany("SpentConsumablesForVisits")
                        .HasForeignKey("СonsumableId")
                        .HasConstraintName("FK_SpentConsumablesForVisit_Consumable")
                        .IsRequired();

                    b.Navigation("Сonsumable");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Accountant", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Employee", null)
                        .WithOne()
                        .HasForeignKey("HealthyTeethAPI.Data.Accountant", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Administrator", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Employee", null)
                        .WithOne()
                        .HasForeignKey("HealthyTeethAPI.Data.Administrator", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Doctor", b =>
                {
                    b.HasOne("HealthyTeethAPI.Data.Cabinet", "Cabinet")
                        .WithMany("Doctors")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthyTeethAPI.Data.Employee", null)
                        .WithOne()
                        .HasForeignKey("HealthyTeethAPI.Data.Doctor", "EmployeeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Cabinet");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Cabinet", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Client", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ClientsVisit", b =>
                {
                    b.Navigation("SpentConsumablesForVisits");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Consumable", b =>
                {
                    b.Navigation("ConsumablesInDeliveries");

                    b.Navigation("ConsumablesInStorages");

                    b.Navigation("SpentConsumablesForVisits");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.ConsumableType", b =>
                {
                    b.Navigation("Consumables");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Delivery", b =>
                {
                    b.Navigation("ConsumablesInDeliveries");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Record", b =>
                {
                    b.Navigation("ClientsVisit");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Storage", b =>
                {
                    b.Navigation("ConsumablesInStorages");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Supplier", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.VisitType", b =>
                {
                    b.Navigation("ClientsVisits");
                });

            modelBuilder.Entity("HealthyTeethAPI.Data.Doctor", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
