using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Order
    {
        public string Id { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [DataType(DataType.Date)]
        public DateTime LoadingDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliverTill { get; set; }


        public TransportRFQ TransportRFQ { get; set; }

        [Required]
        public decimal OrderAmount { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-z0-9\s-_\.,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        public string Comments { get; set; }
    }
}