using System;
using System.Collections.Generic;
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

        public string MaterialCode { get; set; }

        public string Name { get; set; }

        public Packaging Packaging { get; set; }

        public Hazard Hazardus { get; set; }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
