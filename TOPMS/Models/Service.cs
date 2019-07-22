using System;
using System.Collections.Generic;
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

        public string Name { get; set; }

        public ICollection<CompanyService> CompanyServices { get; set;  }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
