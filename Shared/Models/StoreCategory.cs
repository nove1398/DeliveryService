using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class StoreCategory
    {
        public int StoreId { get; set; }
        public int CategoryId { get; set; }

        public Store Store { get; set; }
        public Category Category { get; set; }
    }
}
