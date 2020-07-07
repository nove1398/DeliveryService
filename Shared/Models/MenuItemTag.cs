using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class MenuItemTag
    {
        public int TagId { get; set; }
        public int MenuItemId { get; set; }

        public Tag Tag { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
