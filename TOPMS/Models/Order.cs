﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using TOPMS.Enums;

namespace TOPMS.Models
{
    public class Order
    {
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }
        public DateTime Date { get; set; }

        public DateTime LoadingDate { get; set; }

        public DateTime DeliverTill { get; set; }

        public TransportRFQ TransportRFQ { get; set; }

        public decimal OrderAmount { get; set; }

        public Currency Currency { get; set; }

        public string Comments { get; set; }
    }
}