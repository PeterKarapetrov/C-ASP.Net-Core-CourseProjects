using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Order
    {
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime LoadingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeliverTill { get; set; }

        public TransportRFQ TransportRFQ { get; set; }

        public decimal OrderAmount { get; set; }

        public Currency Currency { get; set; }

        public string Comments { get; set; }
    }
}