using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; } // decimal(12,2)

        public string Recipe { get; set; }

        public bool IsActive { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
