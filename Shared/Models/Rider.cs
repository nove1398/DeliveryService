using DeliveryService.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class Rider
    {
        [Key]
        public int RiderId { get; set; }

        public bool IsAccountActive { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public long? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int RiderDetailsId { get; set; }
        public RiderDetails RiderDetails { get; set; }

    }
}
