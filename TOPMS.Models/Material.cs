using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Material
    {
        public Material()
        {
            this.TransportRFQs = new List<TransportRFQ>();
        }

        public string Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use numbers and latin alphabet letters only")]
        public string MaterialCode { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use numbers and latin alphabet letters only")]
        public string Name { get; set; }

        [Required]
        public Packaging Packaging { get; set; }

        [Required]
        public Hazard Hazardus { get; set; }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
