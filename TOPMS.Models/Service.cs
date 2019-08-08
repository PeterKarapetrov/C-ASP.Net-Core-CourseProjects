using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
    public class Service
    {
        public Service()
        {
            this.CompanyServices = new List<CompanyService>();
            this.TransportRFQs = new List<TransportRFQ>();
        }
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-z]*", ErrorMessage = "Please use latin alphabet letters only")]
        public string Name { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        public ICollection<CompanyService> CompanyServices { get; set;  }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
