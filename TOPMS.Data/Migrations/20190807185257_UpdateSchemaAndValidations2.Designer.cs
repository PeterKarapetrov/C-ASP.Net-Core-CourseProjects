﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TOPMS.Data;

namespace TOPMS.Migrations
{
    [DbContext(typeof(TOPMSContext))]
    [Migration("20190807185257_UpdateSchemaAndValidations2")]
    partial class UpdateSchemaAndValidations2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("TOPMS.Models.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Descrition")
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
                });

            modelBuilder.Entity("TOPMS.Models.AppUser", b =>
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

            modelBuilder.Entity("TOPMS.Models.AreaOfService", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AreaOfService");
                });

            modelBuilder.Entity("TOPMS.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("CompanyType");

                    b.Property<string>("ContactEmail")
                        .IsRequired();

                    b.Property<string>("ContactPerson")
                        .IsRequired();

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SpecialRequirements")
                        .IsRequired();

                    b.Property<string>("WorkingTime")
                        .IsRequired();

                    b.Property<string>("ZIPCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TOPMS.Models.CompanyAreaOfService", b =>
                {
                    b.Property<string>("CompanyId");

                    b.Property<string>("AreaOfServiceId");

                    b.HasKey("CompanyId", "AreaOfServiceId");

                    b.HasIndex("AreaOfServiceId");

                    b.ToTable("CompanyAreaOfServices");
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

            modelBuilder.Entity("TOPMS.Models.ExchangeRate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<int>("ConvertFrom");

                    b.Property<decimal>("ConvertRate")
                        .HasColumnType("decimal(18,5)");

                    b.Property<int>("ConvertToBGN");

                    b.Property<string>("ValidForMonth")
                        .IsRequired();

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTill");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("TOPMS.Models.Insurance", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppUserId");

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<int>("Currency");

                    b.Property<decimal>("OrderAmount");

                    b.Property<string>("SendToEmail")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("TOPMS.Models.Material", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Hazardus");

                    b.Property<string>("MaterialCode")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Packaging");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("TOPMS.Models.Offer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppUserId");

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<int>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<string>("DeliveryTime")
                        .IsRequired();

                    b.Property<string>("LoadingTime")
                        .IsRequired();

                    b.Property<decimal>("PriceOffered");

                    b.Property<string>("TransportRFQId");

                    b.Property<DateTime>("ValidTill");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("TransportRFQId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("TOPMS.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppUserId");

                    b.Property<string>("Comments")
                        .IsRequired();

                    b.Property<int>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DeliverTill");

                    b.Property<DateTime>("LoadingDate");

                    b.Property<decimal>("OrderAmount");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TOPMS.Models.Service", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("TOPMS.Models.Status", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TOPMS.Models.Transport", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("TOPMS.Models.TransportRFQ", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("FromId");

                    b.Property<string>("InsuranceId");

                    b.Property<string>("MaterialId");

                    b.Property<int>("NumberOfPackages");

                    b.Property<string>("OrderId");

                    b.Property<string>("PackageDimention")
                        .IsRequired();

                    b.Property<DateTime>("RequestDeliveryDate");

                    b.Property<string>("ServiceId");

                    b.Property<DateTime>("ShipmentReadyDate");

                    b.Property<string>("SpecialRequirements")
                        .IsRequired();

                    b.Property<string>("StatusId");

                    b.Property<string>("ToId");

                    b.Property<string>("TransportId");

                    b.Property<string>("Volume")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("FromId");

                    b.HasIndex("InsuranceId")
                        .IsUnique()
                        .HasFilter("[InsuranceId] IS NOT NULL");

                    b.HasIndex("MaterialId");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StatusId");

                    b.HasIndex("ToId");

                    b.HasIndex("TransportId");

                    b.ToTable("TransportRFQs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TOPMS.Models.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TOPMS.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TOPMS.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TOPMS.Models.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TOPMS.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TOPMS.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TOPMS.Models.AppUser", b =>
                {
                    b.HasOne("TOPMS.Models.Company", "Company")
                        .WithMany("AppUsers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.SetNull);
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
                    b.HasOne("TOPMS.Models.AppUser", "AppUser")
                        .WithMany("Insurances")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("TOPMS.Models.Offer", b =>
                {
                    b.HasOne("TOPMS.Models.AppUser", "AppUser")
                        .WithMany("Offers")
                        .HasForeignKey("AppUserId");

                    b.HasOne("TOPMS.Models.TransportRFQ", "TransportRFQ")
                        .WithMany("Offers")
                        .HasForeignKey("TransportRFQId");
                });

            modelBuilder.Entity("TOPMS.Models.Order", b =>
                {
                    b.HasOne("TOPMS.Models.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("TOPMS.Models.TransportRFQ", b =>
                {
                    b.HasOne("TOPMS.Models.AppUser", "AppUser")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("AppUserId");

                    b.HasOne("TOPMS.Models.Company", "From")
                        .WithMany("Loadings")
                        .HasForeignKey("FromId");

                    b.HasOne("TOPMS.Models.Insurance", "Insurance")
                        .WithOne("TransportRFQ")
                        .HasForeignKey("TOPMS.Models.TransportRFQ", "InsuranceId");

                    b.HasOne("TOPMS.Models.Material", "Material")
                        .WithMany("TransportRFQs")
                        .HasForeignKey("MaterialId");

                    b.HasOne("TOPMS.Models.Order", "Order")
                        .WithOne("TransportRFQ")
                        .HasForeignKey("TOPMS.Models.TransportRFQ", "OrderId");

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
                });
#pragma warning restore 612, 618
        }
    }
}
