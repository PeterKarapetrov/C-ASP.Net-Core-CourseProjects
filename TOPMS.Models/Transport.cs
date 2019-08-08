using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
    public class Transport
    {
        public Transport()
        {
            this.CompanyTransports = new List<CompanyTransport>();
            this.TransportRFQs = new List<TransportRFQ>();
        }
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]*", ErrorMessage = "Please use and latin alphabet letters only")]
        public string Name { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        public ICollection<CompanyTransport> CompanyTransports { get; set; }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
