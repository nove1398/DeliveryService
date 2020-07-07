using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int Quantity { get; set; }

        public decimal Tax { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public long AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public virtual ICollection<CartMenuItem> CartMenuItems { get; set; }
    }
}
