using System.Collections.Generic;

namespace TOPMS.Models
{
    public class Status
    {
        public Status()
        {
            this.TransportRFQs = new List<TransportRFQ>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<TransportRFQ> TransportRFQs {get; set;}
    }
} 