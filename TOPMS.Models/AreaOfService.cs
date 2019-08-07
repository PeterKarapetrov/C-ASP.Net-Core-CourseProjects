using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
    public class AreaOfService
    {
        public AreaOfService()
        {
            this.CompanyAreaOfServices = new List<CompanyAreaOfService>();
        }
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Please use latin alphabet letters only")]
        public string Name { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        public ICollection<CompanyAreaOfService> CompanyAreaOfServices { get; set; }
    }
}
