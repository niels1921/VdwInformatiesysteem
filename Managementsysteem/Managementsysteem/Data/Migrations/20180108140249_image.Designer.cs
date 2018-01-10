﻿// <auto-generated />
using Managementsysteem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Managementsysteem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180108140249_image")]
    partial class image
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Managementsysteem.Models.Afspraak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Afspraak_Id");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("Klant_Id");

                    b.Property<string>("Omschrijving")
                        .IsRequired();

                    b.Property<int>("Project_Id");

                    b.HasKey("Id");

                    b.HasIndex("Afspraak_Id");

                    b.HasIndex("Klant_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Afspraak");
                });

            modelBuilder.Entity("Managementsysteem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Image");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Managementsysteem.Models.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Afspraak_Id");

                    b.Property<string>("Contactpersoon");

                    b.Property<string>("Email");

                    b.Property<string>("Huisnummer");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Postcode");

                    b.Property<string>("Profiel_foto");

                    b.Property<int>("Project_Id");

                    b.Property<string>("Straatnaam");

                    b.Property<string>("Telefoon");

                    b.Property<string>("Woonplaats");

                    b.HasKey("Id");

                    b.ToTable("Klant");
                });

            modelBuilder.Entity("Managementsysteem.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Afspraak_Id");

                    b.Property<DateTime>("Deadline");

                    b.Property<int>("Klant_Id");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Omschrijving");

                    b.Property<int?>("Project_Id");

                    b.Property<DateTime>("Startdatum");

                    b.Property<string>("Status");

                    b.Property<int>("Taak_Id");

                    b.HasKey("Id");

                    b.HasIndex("Klant_Id");

                    b.HasIndex("Project_Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Managementsysteem.Models.Taak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<double>("GewerkteUren");

                    b.Property<string>("Image");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Omschrijving");

                    b.Property<int>("Project_Id");

                    b.Property<int?>("Taak_Id");

                    b.Property<string>("UserId");

                    b.Property<int>("User_id");

                    b.Property<double>("VerwachteUren");

                    b.HasKey("Id");

                    b.HasIndex("Project_Id");

                    b.HasIndex("Taak_Id");

                    b.HasIndex("UserId");

                    b.ToTable("Taak");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Managementsysteem.Models.Afspraak", b =>
                {
                    b.HasOne("Managementsysteem.Models.Klant")
                        .WithMany("Afspraken")
                        .HasForeignKey("Afspraak_Id");

                    b.HasOne("Managementsysteem.Models.Project")
                        .WithMany("Afspraken")
                        .HasForeignKey("Afspraak_Id");

                    b.HasOne("Managementsysteem.Models.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("Klant_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Managementsysteem.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Managementsysteem.Models.Project", b =>
                {
                    b.HasOne("Managementsysteem.Models.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("Klant_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Managementsysteem.Models.Klant")
                        .WithMany("Projecten")
                        .HasForeignKey("Project_Id");
                });

            modelBuilder.Entity("Managementsysteem.Models.Taak", b =>
                {
                    b.HasOne("Managementsysteem.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Managementsysteem.Models.Project")
                        .WithMany("Taken")
                        .HasForeignKey("Taak_Id");

                    b.HasOne("Managementsysteem.Models.ApplicationUser", "Werknemer")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Managementsysteem.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Managementsysteem.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Managementsysteem.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Managementsysteem.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
