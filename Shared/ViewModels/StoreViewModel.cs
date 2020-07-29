using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.ViewModels
{
   public class StoreViewModel
    {
        public string StoreName { get; set; }

        public long Id { get; set; }

        public string Contact { get; set; }

        public bool IsActive { get; set; }

        public List<string> OwnerNames { get; set; }

        public string ServiceType { get; set; }

    }
}
