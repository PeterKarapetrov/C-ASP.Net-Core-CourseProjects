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

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string AreaOfServiceId { get; set; }

        public AreaOfService AreaOfService { get; set; }
    }
}