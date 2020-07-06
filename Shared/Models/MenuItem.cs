using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; } // decimal(12,2)

        public string Recipe { get; set; }

        public bool IsActive { get; set; }

        public decimal Tax { get; set; }

        public string Image { get; set; }

        public int? StoreId { get; set; }
        public Store Store { get; set; }

        public virtual ICollection<CartMenuItem> CartMenuItems { get; set; }
        public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }
        public virtual ICollection<CategoryMenuItem> CategoryMenuItems { get; set; }
    }
}
