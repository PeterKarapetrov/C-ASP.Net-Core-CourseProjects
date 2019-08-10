using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TOPMS.Enums;

namespace TOPMS.Models.BindingModels.Offers
{
    public class OfferViewModel
    {
        public string Id { get; set; }

        public AppUser AppUser { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime ValidTill { get; set; }

        public string TransportRFQId { get; set; }

        [RegularExpression(@"[a-zA-z0-9\s-_\.,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        public string LoadingTime { get; set; }

        [RegularExpression(@"[a-zA-z0-9\s-_\.,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        public string DeliveryTime { get; set; }

        public decimal PriceOffered { get; set; }

        public Currency Currency { get; set; }

        [RegularExpression(@"[a-zA-z0-9\s-_\.,]*", ErrorMessage = "Please use numbers, latin alphabet letters, space, dot, dush and comma only")]
        public string Comments { get; set; }
    }
}
