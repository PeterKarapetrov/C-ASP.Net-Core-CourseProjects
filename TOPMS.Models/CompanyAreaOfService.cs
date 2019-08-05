namespace TOPMS.Models
{
    public class CompanyAreaOfService
    {
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public string AreaOfServiceId { get; set; }

        public AreaOfService AreaOfService { get; set; }
    }
}