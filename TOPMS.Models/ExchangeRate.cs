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

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\s\.-_\\,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dash and comma only")]
        public string ValidForMonth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ValidTill { get; set; }

        [Required]
        public Currency ConvertFrom { get; set; }

        [Required]
        public Currency ConvertToBGN { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,5)")]
        public decimal ConvertRate { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\s\.-_\\,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dash and comma only")]
        public string Comments { get; set; }
    }
}
