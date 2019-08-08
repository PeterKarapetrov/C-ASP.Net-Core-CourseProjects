using System.ComponentModel.DataAnnotations;
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

        [Required]
        [EmailAddress]
        public string SendToEmail { get; set; }

        public TransportRFQ TransportRFQ { get; set; }

        [Required]
        public decimal OrderAmount { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\s\.-_\\,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dash and comma only")]
        public string Comments { get; set; }
    }
}