using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
        [Table("AppUser")]
        public class AppUser : IdentityUser
        {

            public AppUser() : base()
            {
                this.Offers = new List<Offer>();
                this.Orders = new List<Order>();
                this.Insurances = new List<Insurance>();
                this.TransportRFQs = new List<TransportRFQ>(); 
            }

            //public virtual ICollection<UserRole> UserRoles { get; set; }

            [ForeignKey("Company")]
            public string CompanyId { get; set; }

            public Company Company { get; set; }

            public ICollection<Offer> Offers { get; set; }

            public ICollection<Order> Orders { get; set; }

            public ICollection<Insurance> Insurances { get; set; }

            public ICollection<TransportRFQ> TransportRFQs { get; set; }
        }
}
