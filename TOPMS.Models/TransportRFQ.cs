using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TOPMS.Models
{
    public class TransportRFQ
    {
        public TransportRFQ()
        {
            this.Offers = new List<Offer>();
        }

        public string Id { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        [Required]
        public AppUser AppUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public Company From { get; set; }

        public Company To { get; set; }

        public string MaterialId { get; set; }
        public Material Material { get; set; }

        [Required]
        [RegularExpression(@"[0-9]", ErrorMessage = "Please use numbers only")]
        public int NumberOfPackages { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string PackageDimention { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string Volume { get; set; }

        [Required]
        public string TransportId { get; set; }

        [Required]
        public Transport Transport { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [Required]
        public Service Service { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ShipmentReadyDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RequestDeliveryDate { get; set; }

        [Required]
        public string StatusId { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string SpecialRequirements { get; set; }

        [Required]
        public ICollection<Offer> Offers { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public string InsuranceId { get; set; }

        [Required]
        public Insurance Insurance { get; set; }

    }
}