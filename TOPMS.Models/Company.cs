using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Company
    {
        public Company()
        {
            this.AppUsers = new List<AppUser>();
            this.CompanyTransports = new List<CompanyTransport>();
            this.CompanyServices = new List<CompanyService>();
            this.CompanyAreaOfServices = new List<CompanyAreaOfService>();
            this.Loadings = new List<TransportRFQ>();
            this.Deliveries = new List<TransportRFQ>();
        }

        public string Id { get; set; }

        public CompanyType CompanyType { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use numbers and latin alphabet letters only")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Please use latin alphabet letters only")]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Please use latin alphabet letters only")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use latin alphabet letters only")]
        public string ZIPCode { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use latin alphabet letters only")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Please use latin alphabet letters only")]
        public string ContactPerson { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        [Phone]
        public string ContactPhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use numbers and latin alphabet letters only")]
        public string WorkingTime { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9]", ErrorMessage = "Please use numbers and latin alphabet letters only")]
        public string SpecialRequirements { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

        public ICollection<CompanyTransport> CompanyTransports { get; set; }

        public ICollection<CompanyService> CompanyServices { get; set; }

        public ICollection<CompanyAreaOfService> CompanyAreaOfServices { get; set; }

        [InverseProperty("From")]
        public ICollection<TransportRFQ> Loadings { get; set; }

        [InverseProperty("To")]
        public ICollection<TransportRFQ> Deliveries { get; set; }
    }
}