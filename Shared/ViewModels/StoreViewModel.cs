using DeliveryService.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.ViewModels
{
    public class Owner
    {
        public string Name { get; set; }
        public long Id { get; set; }

    }

   public class StoreViewModel
    {
        public string StoreName { get; set; }

        public long Id { get; set; }

        public string Contact { get; set; }

        public bool IsActive { get; set; }

        public decimal Commission { get; set; }

        public decimal DeliveryFee { get; set; }

        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public List<Owner> CurrentOwners { get; set; }

        public List<Owner> TempOwners { get; set; } = new List<Owner>();

        public virtual ServiceType ServiceType { get; set; }

        public List<Owner> GetStoreOwners()
        {
            List<Owner> ownerList = new List<Owner>();
            ownerList.AddRange(TempOwners);
            ownerList.AddRange(CurrentOwners);
            return ownerList;
        }

    }
}
