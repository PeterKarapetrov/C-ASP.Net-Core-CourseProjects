﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
        [Table("User")]
        public class User : IdentityUser
        {

            public User() : base()
            {
                
            }

            public virtual ICollection<UserRole> UserRoles { get; set; }

            [ForeignKey("Company")]
            public string CompanyId { get; set; }

            public Company Company { get; set; }

            public ICollection<Offer> Offers { get; set; }

            public ICollection<Order> Orders { get; set; }

            public ICollection<Insurance> Insurances { get; set; }

            public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
