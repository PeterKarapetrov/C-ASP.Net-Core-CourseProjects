using System.ComponentModel.DataAnnotations.Schema;

namespace TOPMS.Models
{
    public class Order
    {
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}