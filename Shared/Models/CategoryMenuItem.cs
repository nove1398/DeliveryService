using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class CategoryMenuItem
    {

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }

    }
}
