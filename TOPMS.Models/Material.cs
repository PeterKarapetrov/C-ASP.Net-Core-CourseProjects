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
        [RegularExpression(@"[0-9]*", ErrorMessage = "Please use numbers only")]
        public string MaterialCode { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-z0-9\s-_\.,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        [Display(Name = "Material")]
        public string Name { get; set; }

        [Required]
        public Packaging Packaging { get; set; }

        [Required]
        public Hazard Hazardus { get; set; }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
