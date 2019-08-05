using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOPMS.Models
{
    public class AreaOfService
    {
        public AreaOfService()
        {
            this.CompanyAreaOfServices = new List<CompanyAreaOfService>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<CompanyAreaOfService> CompanyAreaOfServices { get; set; }
    }
}
