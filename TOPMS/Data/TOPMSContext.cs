using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Models
{
    public class TOPMSContext : IdentityDbContext<TOPMS.Models.User>
    {
        public TOPMSContext (DbContextOptions<TOPMSContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompanyTransport>().HasKey(ct => new { ct.CompanyId, ct.TransportId });

            modelBuilder.Entity<CompanyTransport>()
                .HasOne<Company>(ct => ct.Company)
                .WithMany(c => c.CompanyTransports)
                .HasForeignKey(ct => ct.CompanyId);


            modelBuilder.Entity<CompanyTransport>()
                .HasOne<Transport>(ct => ct.Transport)
                .WithMany(c => c.CompanyTransports)
                .HasForeignKey(ct => ct.TransportId);

            modelBuilder.Entity<CompanyService>().HasKey(cs => new { cs.CompanyId, cs.ServiceId });

            modelBuilder.Entity<CompanyService>()
                .HasOne<Company>(cs => cs.Company)
                .WithMany(c => c.CompanyServices)
                .HasForeignKey(cs => cs.CompanyId);


            modelBuilder.Entity<CompanyService>()
                .HasOne<Service>(cs => cs.Service)
                .WithMany(c => c.CompanyServices)
                .HasForeignKey(cs => cs.ServiceId);

            modelBuilder.Entity<CompanyAreaOfService>().HasKey(ca => new { ca.CompanyId, ca.AreaOfServiceId });

            modelBuilder.Entity<CompanyAreaOfService>()
                .HasOne<Company>(ca => ca.Company)
                .WithMany(c => c.CompanyAreaOfServices)
                .HasForeignKey(ca => ca.CompanyId);


            modelBuilder.Entity<CompanyAreaOfService>()
                .HasOne<AreaOfService>(ca => ca.AreaOfService)
                .WithMany(c => c.CompanyAreaOfServices)
                .HasForeignKey(ca => ca.AreaOfServiceId);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne<User>(t => t.User) 
                .WithMany(u => u.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne<Material>(t => t.Material)
                .WithMany(m => m.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne<Transport>(t => t.Transport)
                .WithMany(t => t.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne<Service>(t => t.Service)
                .WithMany(t => t.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne<Status>(t => t.Status)
                .WithMany(t => t.TransportRFQs);

            modelBuilder.Entity<Offer>()
                .HasOne<TransportRFQ>(o => o.TransportRFQ)
                .WithMany(t => t.Offers);

            modelBuilder.Entity<Order>()
                .HasOne<TransportRFQ>(o => o.TransportRFQ)
                .WithOne(t => t.Order)
                .HasForeignKey<TransportRFQ>(t => t.OrderId);

            modelBuilder.Entity<Insurance>()
                .HasOne<TransportRFQ>(i => i.TransportRFQ)
                .WithOne(t => t.Insurance)
                .HasForeignKey<TransportRFQ>(t => t.InsuranceId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TOPMS.Models.User> AppUsers { get; set; }

        public DbSet<TOPMS.Models.Role> AppRoles { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<TransportRFQ> TransportRFQs { get; set; }

        public DbSet<Transport> Transports { get; set; }
        public DbSet<CompanyTransport> CompanyTransports { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }

        public DbSet<AreaOfService> AreaOfService { get; set; }

        public DbSet<CompanyAreaOfService> CompanyAreaOfServices { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public DbSet<Status> Status { get; set; }

    }
}
