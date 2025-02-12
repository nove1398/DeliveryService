﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class OrderMenuItem
    {
        public int MenuItemId { get; set; }
        public long OrderId { get; set; }

        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
