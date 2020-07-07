using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class AppUserOrder
    {
        public long AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
