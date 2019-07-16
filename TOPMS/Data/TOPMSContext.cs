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

        public DbSet<TOPMS.Models.User> Users { get; set; }

        public DbSet<TOPMS.Models.Role> Roles { get; set; }

        public DbSet<TOPMS.Models.UserRole> UserRole { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<TransportRFQ> TransportRFQs { get; set; }
    }
}
