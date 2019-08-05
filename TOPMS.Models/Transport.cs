using System;
using System.Collections.Generic;
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
        
        public string Name { get; set; }

        public ICollection<CompanyTransport> CompanyTransports { get; set; }

        public ICollection<TransportRFQ> TransportRFQs { get; set; }
    }
}
