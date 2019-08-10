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
        [RegularExpression(@"[a-zA-Z]*", ErrorMessage = "Please use and latin alphabet letters only")]
        [Display(Name = "Status")]
        public string Name { get; set; }

        public ICollection<TransportRFQ> TransportRFQs {get; set;}
    }
} 