using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Insurance
    {
        public string Id { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string SendToEmail { get; set; }

        public TransportRFQ TransportRFQ { get; set; }

        public decimal OrderAmount { get; set; }

        public Currency Currency { get; set; }

        public string Comments { get; set; }
    }
}