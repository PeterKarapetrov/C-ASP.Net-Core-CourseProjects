using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class ExchangeRate
    {
        public ExchangeRate()
        {
            this.ConvertToBGN = Currency.BGN;
        }
        public string Id { get; set; }

        public string ValidForMonth { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTill { get; set; }

        public Currency ConvertFrom { get; set; }

        public Currency ConvertToBGN { get; set; }

        public decimal ConvertRate { get; set; }

        public string Comments { get; set; }
    }
}
