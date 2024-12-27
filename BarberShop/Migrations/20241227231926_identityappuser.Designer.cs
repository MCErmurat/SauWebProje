﻿// <auto-generated />
using System;
using BarberShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarberShop.Migrations
{
    [DbContext(typeof(BarberContext))]
    [Migration("20241227231926_identityappuser")]
    partial class identityappuser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BarberShop.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BarberShop.Models.Appointments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("HizmetId")
                        .HasColumnType("int");

                    b.Property<bool>("Onayli")
                        .HasColumnType("bit");

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Tarih")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("HizmetId");

                    b.HasIndex("PersonelId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("BarberShop.Models.Hizmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("BarberShop.Models.HizmetSecimViewModel", b =>
                {
                    b.Property<int>("HizmetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetId"));

                    b.Property<int?>("PersonelEkleViewModelPersonelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Ucret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HizmetId");

                    b.HasIndex("PersonelEkleViewModelPersonelId");

                    b.ToTable("HizmetSecimViewModel");
                });

            modelBuilder.Entity("BarberShop.Models.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelID"));

                    b.Property<string>("PersonelAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PersonelDurum")
                        .HasColumnType("bit");

                    b.Property<string>("PersonelSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelID");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("BarberShop.Models.PersonelEkleViewModel", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelId"));

                    b.Property<string>("PersonelAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PersonelDurum")
                        .HasColumnType("bit");

                    b.Property<string>("PersonelSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelId");

                    b.ToTable("PersonelEkleViewModel");
                });

            modelBuilder.Entity("BarberShop.Models.PersonelHizmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HizmetId")
                        .HasColumnType("int");

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Ucret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("HizmetId");

                    b.HasIndex("PersonelId");

                    b.ToTable("PersonelHizmet");
                });

            modelBuilder.Entity("BarberShop.Models.PersonelTakvim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Dolu")
                        .HasColumnType("bit");

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Saat")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Tarih")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("PersonelTakvim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BarberShop.Models.Appointments", b =>
                {
                    b.HasOne("BarberShop.Models.Hizmet", "Hizmet")
                        .WithMany("Appointments")
                        .HasForeignKey("HizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Personel", "Personel")
                        .WithMany("Appointments")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hizmet");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("BarberShop.Models.HizmetSecimViewModel", b =>
                {
                    b.HasOne("BarberShop.Models.PersonelEkleViewModel", null)
                        .WithMany("Hizmetler")
                        .HasForeignKey("PersonelEkleViewModelPersonelId");
                });

            modelBuilder.Entity("BarberShop.Models.PersonelHizmet", b =>
                {
                    b.HasOne("BarberShop.Models.Hizmet", "Hizmet")
                        .WithMany("PersonelHizmetler")
                        .HasForeignKey("HizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Personel", "Personel")
                        .WithMany("PersonelHizmetler")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hizmet");

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("BarberShop.Models.PersonelTakvim", b =>
                {
                    b.HasOne("BarberShop.Models.Personel", "personel")
                        .WithMany("PersonelTakvimler")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BarberShop.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BarberShop.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BarberShop.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BarberShop.Models.Hizmet", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PersonelHizmetler");
                });

            modelBuilder.Entity("BarberShop.Models.Personel", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PersonelHizmetler");

                    b.Navigation("PersonelTakvimler");
                });

            modelBuilder.Entity("BarberShop.Models.PersonelEkleViewModel", b =>
                {
                    b.Navigation("Hizmetler");
                });
#pragma warning restore 612, 618
        }
    }
}
