namespace TOPMS.Models
{
    public class CompanyService
    {
        public CompanyService(string companyId, string serviceId)
        {
            this.CompanyId = companyId;
            this.ServiceId = serviceId;
        }

        public CompanyService()
        {

        }
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string ServiceId { get; set; }

        public Service Service { get; set; }
    }
}