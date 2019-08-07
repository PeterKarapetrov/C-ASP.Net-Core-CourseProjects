using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Offer
    {
        public string Id { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        [Required]
        public AppUser AppUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ValidTill { get; set; }

        [Required]
        public string TransportRFQId {get; set;}

        [Required]
        public TransportRFQ TransportRFQ { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string LoadingTime { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string DeliveryTime { get; set; }

        [Required]
        public decimal PriceOffered { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9/-.,]", ErrorMessage = "Please use /-., numbers and latin alphabet letters only")]
        public string Comments { get; set; }
    }
}