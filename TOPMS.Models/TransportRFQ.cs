using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class TransportRFQ
    {
        public TransportRFQ()
        {
            this.Offers = new List<Offer>();
            this.Date = DateTime.UtcNow.Date;
        }

        public string Id { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Company From { get; set; }

        public Company To { get; set; }

        public string MaterialId { get; set; }

        public Material Material { get; set; }

        [Required]
        public Packaging Packaging { get; set; }

        [Required]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Please use numbers only")]
        [Display(Name ="Qty")]
        public int NumberOfPackages { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-z0-9\s-_\.,\\]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        [Display(Name = "PackSize")]
        public string PackageDimention { get; set; }

        [Required]
        [RegularExpression(@"[0-9\.]*", ErrorMessage = "Please use numbers and dot only")]
        public double Volume { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Weight { get; set; }

        public string TransportId { get; set; }

        public Transport Transport { get; set; }

        public string ServiceId { get; set; }

        public Service Service { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "SRD")]
        public DateTime ShipmentReadyDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "RDD")]
        public DateTime RequestDeliveryDate { get; set; }

        public string StatusId { get; set; }

        public Status Status { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-z0-9\s-_\.,\\]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        public string SpecialRequirements { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string InsuranceId { get; set; }

        public Insurance Insurance { get; set; }

    }
}