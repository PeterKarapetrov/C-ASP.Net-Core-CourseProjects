using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public string ServiceId { get; set; }

        public Service Service { get; set; }
    }
}