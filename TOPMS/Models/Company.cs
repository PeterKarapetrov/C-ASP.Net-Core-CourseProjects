using System.Collections.Generic;

namespace TOPMS.Models
{
    public class Company
    {
        public string Id { get; set; }

        public ICollection<User> Users { get; set; }
    }
}