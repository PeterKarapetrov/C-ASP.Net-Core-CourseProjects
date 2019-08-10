using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.BindimgModels
{
    public class TransportRFQCreateModel
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string FromName { get; set; }

        [Required]
        public string ToName { get; set; }

        [Required]
        public string MaterialName { get; set; }

        [Required]
        public string Packaging { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public int NumberOfPackages { get; set; }

        public string PackageDimensions { get; set; }

        [Required]
        public double Volume { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string TransportRequired { get; set; }

        [Required]
        public string ServiceRequired {get; set;}

        [DataType(DataType.Date)]
        public DateTime ShipmentReadyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestDelieverDate { get; set; }

        [Required]
        public string Status { get; set; }
       
        public string SpecialRequirements { get; set; }

        public string OrderId { get; set; }

        public string InsuranceId { get; set; }

        public int Offers { get; set; }
    }
}
