using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Company
    {
        public Company()
        {
            this.Users = new List<User>();
            this.CompanyTransports = new List<CompanyTransport>();
            this.CompanyServices = new List<CompanyService>();
            this.CompanyAreaOfServices = new List<CompanyAreaOfService>();
            this.Loadings = new List<TransportRFQ>();
            this.Deliveries = new List<TransportRFQ>();
        }

        public string Id { get; set; }

        public CompanyType CompanyType { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ZIPCode { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string WorkingTime { get; set; }

        public string SpecialRequirements { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<CompanyTransport> CompanyTransports { get; set; }

        public ICollection<CompanyService> CompanyServices { get; set; }

        public ICollection<CompanyAreaOfService> CompanyAreaOfServices { get; set; }

        [InverseProperty("From")]
        public ICollection<TransportRFQ> Loadings { get; set; }

        [InverseProperty("To")]
        public ICollection<TransportRFQ> Deliveries { get; set; }
    }
}