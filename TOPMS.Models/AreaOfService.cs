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
        [RegularExpression(@"[a-zA-Z0-9\s]*", ErrorMessage = "Please use numbers, latin alphabet letters and space only")]
        public string Name { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        public ICollection<CompanyAreaOfService> CompanyAreaOfServices { get; set; }
    }
}
