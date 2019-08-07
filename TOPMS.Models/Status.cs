using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TOPMS.Models
{
    public class Status
    {

        public Status()
        {
            this.TransportRFQs = new List<TransportRFQ>();
        }
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use and latin alphabet letters only")]
        public string Name { get; set; }

        public ICollection<TransportRFQ> TransportRFQs {get; set;}
    }
} 