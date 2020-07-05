using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        public string Name { get; set; }
    }
}
