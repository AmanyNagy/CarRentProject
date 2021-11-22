﻿// <auto-generated />
using System;
using CarRent3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRent3.Migrations
{
    [DbContext(typeof(CarRentContext))]
    [Migration("20211118105124_inil")]
    partial class inil
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("CarRent3.Model.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Compny")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DailyRentPrice")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("Category");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarRent3.Model.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("ClinetId")
                        .HasColumnType("int");

                    b.Property<int?>("DeliverCity")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("CarId");

                    b.HasIndex("ClinetId");

                    b.HasIndex("DeliverCity");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("CarRent3.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CarRent3.Model.Clinet", b =>
                {
                    b.Property<int>("ClinetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Moblie")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinetId");

                    b.ToTable("Clinet");
                });

            modelBuilder.Entity("CarRent3.Model.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HistoryID")
                        .UseIdentityColumn();

                    b.Property<int>("CarUniqeId")
                        .HasColumnType("int");

                    b.Property<int>("DistanceTraveledInKilo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinshDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("HistoryId");

                    b.HasIndex("CarUniqeId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("CarRent3.Model.Inventory", b =>
                {
                    b.Property<int>("CarUniqeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateFinish")
                        .HasColumnType("date");

                    b.HasKey("CarUniqeId")
                        .HasName("PK__Inventor__D7B37B88824AD2A7");

                    b.HasIndex("CarId");

                    b.HasIndex("CityId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("CarRent3.Model.Location", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfCars")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId")
                        .HasName("PK__Location__F2D21B76D6F829FC");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CarRent3.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderFinshDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("OrderStartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("OrderSubmitDate")
                        .HasColumnType("date");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Statue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("CartId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarRent3.Model.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CardExpirDate")
                        .HasColumnType("date");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClinetId")
                        .HasColumnType("int");

                    b.Property<string>("NameCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("ClinetId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("CarRent3.Model.ViCarForCategorty", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Compny")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DailyRentPrice")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.ToView("vi_CarForCategorty");
                });

            modelBuilder.Entity("CarRent3.Model.Car", b =>
                {
                    b.HasOne("CarRent3.Model.Category", "CategoryNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("Category")
                        .HasConstraintName("FK__Car__Category__31EC6D26");

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("CarRent3.Model.Cart", b =>
                {
                    b.HasOne("CarRent3.Model.Car", "Car")
                        .WithMany("Carts")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__Cart__CarId__36B12243");

                    b.HasOne("CarRent3.Model.Clinet", "Clinet")
                        .WithMany("Carts")
                        .HasForeignKey("ClinetId")
                        .HasConstraintName("FK__Cart__ClinetId__37A5467C");

                    b.HasOne("CarRent3.Model.Location", "DeliverCityNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("DeliverCity")
                        .HasConstraintName("FK__Cart__DeliverCit__38996AB5");

                    b.Navigation("Car");

                    b.Navigation("Clinet");

                    b.Navigation("DeliverCityNavigation");
                });

            modelBuilder.Entity("CarRent3.Model.History", b =>
                {
                    b.HasOne("CarRent3.Model.Inventory", "CarUniqe")
                        .WithMany("Histories")
                        .HasForeignKey("CarUniqeId")
                        .HasConstraintName("FK__History__CarUniq__4222D4EF")
                        .IsRequired();

                    b.Navigation("CarUniqe");
                });

            modelBuilder.Entity("CarRent3.Model.Inventory", b =>
                {
                    b.HasOne("CarRent3.Model.Car", "Car")
                        .WithMany("Inventories")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__Inventory__CarId__3E52440B")
                        .IsRequired();

                    b.HasOne("CarRent3.Model.Location", "City")
                        .WithMany("Inventories")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Inventory__CityI__3F466844")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("City");
                });

            modelBuilder.Entity("CarRent3.Model.Order", b =>
                {
                    b.HasOne("CarRent3.Model.Cart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK__Orders__CartId__4BAC3F29")
                        .IsRequired();

                    b.HasOne("CarRent3.Model.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK__Orders__PaymentI__4CA06362")
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("CarRent3.Model.Payment", b =>
                {
                    b.HasOne("CarRent3.Model.Clinet", "Clinet")
                        .WithMany("Payments")
                        .HasForeignKey("ClinetId")
                        .HasConstraintName("FK__Payment__ClinetI__48CFD27E")
                        .IsRequired();

                    b.Navigation("Clinet");
                });

            modelBuilder.Entity("CarRent3.Model.Car", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("CarRent3.Model.Cart", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CarRent3.Model.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRent3.Model.Clinet", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CarRent3.Model.Inventory", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("CarRent3.Model.Location", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("CarRent3.Model.Payment", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}