﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
    [Table("AppRole")]
    public class AppRole : IdentityRole
    {
        [Required]
        public string Descrition { get; set; }

        //public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
