using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class CartMenuItem
    {
        public int CartId { get; set; }
        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }
        public Cart Cart { get; set; }
    }
}
