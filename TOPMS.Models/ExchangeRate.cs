using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime ValidTill { get; set; }

        public Currency ConvertFrom { get; set; }

        public Currency ConvertToBGN { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal ConvertRate { get; set; }

        public string Comments { get; set; }
    }
}
