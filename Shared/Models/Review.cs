using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Details { get; set; }

        public int Rating { get; set; }

        public int AppUserId { get; set; }

        public int MenuItemId { get; set; }

        public AppUser AppUser { get; set; }
        public MenuItem MenuItem { get; set; }


       
    }
}
