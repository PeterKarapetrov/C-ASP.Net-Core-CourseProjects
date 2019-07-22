using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Insurance
    {
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public string SendToEmail { get; set; }

        public TransportRFQ TransportRFQ { get; set; }

        public decimal OrderAmount { get; set; }

        public Currency Currency { get; set; }

        public string Comments { get; set; }
    }
}