namespace TOPMS.Models
{
    public class CompanyTransport
    {
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string TransportId { get; set; }

        public Transport Transport { get; set; }
    }
}