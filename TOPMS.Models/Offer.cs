using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Offer
    {
        public string Id { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime ValidTill { get; set; }

        public string TransportRFQId {get; set;}

        public TransportRFQ TransportRFQ { get; set; }

        public string LoadingTime { get; set; }

        public string DeliveryTime { get; set; }

        public decimal PriceOffered { get; set; }

        public Currency Currency { get; set; }

        public string Comments { get; set; }
    }
}