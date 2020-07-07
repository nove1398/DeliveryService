using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class AppUserReview
    {
        public long AppUserId { get; set; }
        public int ReviewId { get; set; }

        public Review Review { get; set; }
        public AppUser AppUser { get; set; }
    }
}
