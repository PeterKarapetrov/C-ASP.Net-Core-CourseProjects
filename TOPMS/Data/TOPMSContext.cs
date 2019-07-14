using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TOPMS.Models;

namespace TOPMS.Models
{
    public class TOPMSContext : DbContext
    {
        public TOPMSContext (DbContextOptions<TOPMSContext> options)
            : base(options)
        {
        }

        public DbSet<TOPMS.Models.User> Users { get; set; }

        public DbSet<TOPMS.Models.Role> Roles { get; set; }

        public DbSet<TOPMS.Models.UserRole> UserRole { get; set; }


    }
}
