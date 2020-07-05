using DeliveryService.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? EstimatedDeliveryTime { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public string Details { get; set; }

        public decimal Discount { get; set; }

        public decimal FinalPrice { get; set; }
        
        public int StatusId { get; set; }
        public virtual OrderStatus Status { get; set; }

        public bool IsPaid { get; set; }

        public bool IsAssigned { get; set; }

        public long AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<AppUserOrder> AppUserOrders { get; set; }
    }
}
