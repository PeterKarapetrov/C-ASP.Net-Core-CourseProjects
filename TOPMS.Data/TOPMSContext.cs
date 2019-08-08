using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Data
{
    public class TOPMSContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public TOPMSContext (DbContextOptions<TOPMSContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyTransport>()
                .HasKey(ct => new { ct.CompanyId, ct.TransportId });

            modelBuilder.Entity<CompanyTransport>()
                .HasOne(ct => ct.Company)
                .WithMany(c => c.CompanyTransports)
                .HasForeignKey(ct => ct.CompanyId);


            modelBuilder.Entity<CompanyTransport>()
                .HasOne(ct => ct.Transport)
                .WithMany(c => c.CompanyTransports)
                .HasForeignKey(ct => ct.TransportId);

            modelBuilder.Entity<CompanyService>()
                .HasKey(cs => new { cs.CompanyId, cs.ServiceId });

            modelBuilder.Entity<CompanyService>()
                .HasOne(cs => cs.Company)
                .WithMany(c => c.CompanyServices)
                .HasForeignKey(cs => cs.CompanyId);


            modelBuilder.Entity<CompanyService>()
                .HasOne(cs => cs.Service)
                .WithMany(c => c.CompanyServices)
                .HasForeignKey(cs => cs.ServiceId);

            modelBuilder.Entity<CompanyAreaOfService>()
                .HasKey(ca => new { ca.CompanyId, ca.AreaOfServiceId });

            modelBuilder.Entity<CompanyAreaOfService>()
                .HasOne(ca => ca.Company)
                .WithMany(c => c.CompanyAreaOfServices)
                .HasForeignKey(ca => ca.CompanyId);


            modelBuilder.Entity<CompanyAreaOfService>()
                .HasOne(ca => ca.AreaOfService)
                .WithMany(c => c.CompanyAreaOfServices)
                .HasForeignKey(ca => ca.AreaOfServiceId);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.AppUser) 
                .WithMany(u => u.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.Material)
                .WithMany(m => m.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.Transport)
                .WithMany(t => t.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.Service)
                .WithMany(s => s.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.Status)
                .WithMany(s => s.TransportRFQs);

            modelBuilder.Entity<TransportRFQ>()
                .HasMany(t => t.Offers)
                .WithOne(o => o.TransportRFQ);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.Order)
                .WithOne(o => o.TransportRFQ);

            modelBuilder.Entity<TransportRFQ>()
                .HasOne(t => t.Insurance)
                .WithOne(i => i.TransportRFQ);

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Company)
                .WithMany(c => c.AppUsers)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<AppUser>()
            //    .HasMany(u => u.TransportRFQs)
            //    .WithOne(t => t.AppUser)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<AppUser>()
            //    .HasMany(u => u.Offers)
            //    .WithOne(o => o.AppUser)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<AppUser>()
            //    .HasMany(u => u.Orders)
            //    .WithOne(o => o.AppUser)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<AppUser>()
            //    .HasMany(u => u.Insurances)
            //    .WithOne(i => i.AppUser)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<AreaOfService>()
            //    .HasMany(a => a.CompanyAreaOfServices)
            //    .WithOne(c => c.AreaOfService)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Company>()
            //    .HasMany(a => a.CompanyAreaOfServices)
            //    .WithOne(c => c.Company)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Company>()
            //    .HasMany(c => c.CompanyTransports)
            //    .WithOne(t => t.Company)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Company>()
            //    .HasMany(c => c.CompanyServices)
            //    .WithOne(s => s.Company)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Company>()
            //    .HasMany(c => c.Loadings)
            //    .WithOne(l => l.From)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Company>()
            //    .HasMany(c => c.Deliveries)
            //    .WithOne(d => d.To)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Service>()
            //    .HasMany(s => s.CompanyServices)
            //    .WithOne(c => c.Service)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Transport>()
            //    .HasMany(t => t.CompanyTransports)
            //    .WithOne(c => c.Transport)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Transport>()
            //   .HasMany(t => t.TransportRFQs)
            //   .WithOne(tr => tr.Transport)
            //   .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Material>()
            //    .HasMany(u => u.TransportRFQs)
            //    .WithOne(m => m.Material)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Insurance>()
            //    .HasOne(i => i.TransportRFQ)
            //    .WithOne(t => t.Insurance)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Service>()
            //    .HasMany(s => s.TransportRFQs)
            //    .WithOne(t => t.Service)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Status>()
            //    .HasMany(s => s.TransportRFQs)
            //    .WithOne(t => t.Status)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Offer>()
            //    .HasOne(o => o.TransportRFQ)
            //    .WithMany(t => t.Offers)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.TransportRFQ)
            //    .WithOne(t => t.Order)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

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
