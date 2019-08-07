using System.ComponentModel.DataAnnotations;

namespace TOPMS.Models
{
    public class CompanyAreaOfService
    {
        public CompanyAreaOfService(string companyId, string areaOfServiceId)
        {
            this.CompanyId = companyId;
            this.AreaOfServiceId = areaOfServiceId;
        }

        public CompanyAreaOfService()
        {

        }
        [Required]
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public string AreaOfServiceId { get; set; }

        public AreaOfService AreaOfService { get; set; }
    }
}