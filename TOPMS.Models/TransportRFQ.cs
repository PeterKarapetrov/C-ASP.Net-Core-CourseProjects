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

        public AppUser AppUser { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public Company From { get; set; }

        public Company To { get; set; }

        public string MaterialId { get; set; }
        public Material Material { get; set; }

        public int NumberOfPackages { get; set; }

        public string PackageDimention { get; set; }

        public string Volume { get; set; }

        public string TransportId { get; set; }

        public Transport Transport { get; set; }

        public string ServiceId { get; set; }

        public Service Service { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShipmentReadyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestDeliveryDate { get; set; }

        public string StatusId { get; set; }

        public Status Status { get; set; }

        public string SpecialRequirements { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string InsuranceId { get; set; }

        public Insurance Insurance { get; set; }

    }
}