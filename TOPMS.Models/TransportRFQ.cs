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

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        [Required]
        public AppUser AppUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public Company From { get; set; }

        [Required]
        public Company To { get; set; }

        public string MaterialId { get; set; }

        [Required]
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

        public string TransportId { get; set; }

        [Required]
        public Transport Transport { get; set; }

        public string ServiceId { get; set; }

        [Required]
        public Service Service { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ShipmentReadyDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RequestDeliveryDate { get; set; }

        public string StatusId { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string SpecialRequirements { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string InsuranceId { get; set; }

        public Insurance Insurance { get; set; }

    }
}