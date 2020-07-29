using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class AppUserStore
    {
        public long AppUserId { get; set; }
        public long StoreId { get; set; }

        public Store Store { get; set; }
        public AppUser AppUser { get; set; }
    }
}
