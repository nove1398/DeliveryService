using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public virtual ICollection<CartMenuItem> CartMenuItems { get; set; }
    }
}
