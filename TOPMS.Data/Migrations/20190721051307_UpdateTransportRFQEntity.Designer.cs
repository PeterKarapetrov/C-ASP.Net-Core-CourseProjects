﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TOPMS.Data;
using TOPMS.Models;

namespace TOPMS.Migrations
{
    [DbContext(typeof(TOPMSContext))]
    [Migration("20190721051307_UpdateTransportRFQEntity")]
    partial class UpdateTransportRFQEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("TOPMS.Models.AreaOfService", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AreaOfService");
                });

            modelBuilder.Entity("TOPMS.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("ContactPhoneNumber");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("SpecialRequirements");

                    b.Property<string>("WorkingTime");

                    b.Property<string>("ZIPCode");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TOPMS.Models.CompanyAreaOfService", b =>
                {
                    b.Property<string>("CompanyId");

                    b.Property<string>("AreaOfServiceId");

                    b.HasKey("CompanyId", "AreaOfServiceId");

                    b.HasIndex("AreaOfServiceId");

                    b.ToTable("CompanyAreaOfService");
                });

            modelBuilder.Entity("TOPMS.Models.CompanyService", b =>
                {
                    b.Property<string>("CompanyId");

                    b.Property<string>("ServiceId");

                    b.HasKey("CompanyId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CompanyServices");
                });

            modelBuilder.Entity("TOPMS.Models.CompanyTransport", b =>
                {
                    b.Property<string>("CompanyId");

                    b.Property<string>("TransportId");

                    b.HasKey("CompanyId", "TransportId");

                    b.HasIndex("TransportId");

                    b.ToTable("CompanyTransports");
                });

            modelBuilder.Entity("TOPMS.Models.Insurance", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("TOPMS.Models.Material", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Hazardus");

                    b.Property<string>("MaterialCode");

                    b.Property<string>("Name");

                    b.Property<int>("Packaging");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("TOPMS.Models.Offer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("TOPMS.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TOPMS.Models.Service", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TOPMS.Models.Status", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TOPMS.Models.Transport", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("TOPMS.Models.TransportRFQ", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("FromId");

                    b.Property<string>("MaterialId");

                    b.Property<int>("NumberOfPackages");

                    b.Property<string>("PackageDimention");

                    b.Property<DateTime>("RequestDeliveryDate");

                    b.Property<string>("ServiceId");

                    b.Property<DateTime>("ShipmentReadyDate");

                    b.Property<string>("SpecialRequirements");

                    b.Property<string>("StatusId");

                    b.Property<string>("ToId");

                    b.Property<string>("TransportId");

                    b.Property<string>("UserId");

                    b.Property<string>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StatusId");

                    b.HasIndex("ToId");

                    b.HasIndex("TransportId");

                    b.HasIndex("UserId");

                    b.ToTable("TransportRFQs");
                });

            modelBuilder.Entity("TOPMS.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CompanyId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TOPMS.Models.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Descrition")
                        .IsRequired();

                    b.ToTable("Role");

                    b.HasDiscriminator().HasValue("Role");
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
                    b.HasOne("TOPMS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TOPMS.Models.User")
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

                    b.HasOne("TOPMS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TOPMS.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TOPMS.Models.CompanyAreaOfService", b =>
                {
                    b.HasOne("TOPMS.Models.AreaOfService", "AreaOfService")
                        .WithMany("CompanyAreaOfServices")
                        .HasForeignKey("AreaOfServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TOPMS.Models.Company", "Company")
                        .WithMany("CompanyAreaOfServices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TOPMS.Models.CompanyService", b =>
                {
                    b.HasOne("TOPMS.Models.Company", "Company")
                        .WithMany("CompanyServices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TOPMS.Models.Service", "Service")
                        .WithMany("CompanyServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TOPMS.Models.CompanyTransport", b =>
                {
                    b.HasOne("TOPMS.Models.Company", "Company")
                        .WithMany("CompanyTransports")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TOPMS.Models.Transport", "Transport")
                        .WithMany("CompanyTransports")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TOPMS.Models.Insurance", b =>
                {
                    b.HasOne("TOPMS.Models.User", "User")
                        .WithMany("Insurances")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TOPMS.Models.Offer", b =>
                {
                    b.HasOne("TOPMS.Models.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TOPMS.Models.Order", b =>
                {
                    b.HasOne("TOPMS.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TOPMS.Models.TransportRFQ", b =>
                {
                    b.HasOne("TOPMS.Models.Company", "From")
                        .WithMany("Loadings")
                        .HasForeignKey("FromId");

                    b.HasOne("TOPMS.Models.Material", "Material")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("MaterialId");

                    b.HasOne("TOPMS.Models.Service", "Service")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("ServiceId");

                    b.HasOne("TOPMS.Models.Status", "Status")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("StatusId");

                    b.HasOne("TOPMS.Models.Company", "To")
                        .WithMany("Deliveries")
                        .HasForeignKey("ToId");

                    b.HasOne("TOPMS.Models.Transport", "Transport")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("TransportId");

                    b.HasOne("TOPMS.Models.User", "User")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TOPMS.Models.User", b =>
                {
                    b.HasOne("TOPMS.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
