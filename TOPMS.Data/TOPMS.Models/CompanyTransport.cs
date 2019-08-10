using System.ComponentModel.DataAnnotations;

namespace TOPMS.Models
{
    public class CompanyTransport
    {
        public CompanyTransport(string companyId, string transportId)
        {
            this.CompanyId = companyId;
            this.TransportId = transportId;
        }

        public CompanyTransport()
        {

        }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string TransportId { get; set; }

        public Transport Transport { get; set; }
    }
}