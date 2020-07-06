using System;
using System.Collections.Generic;

namespace DeliveryService.Shared.Models
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

        public string DeliveryAddress { get; set; }

        public virtual ICollection<AppUserOrder> AppUserOrders { get; set; }
        public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}
