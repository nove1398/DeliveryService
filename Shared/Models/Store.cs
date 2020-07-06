using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class Store
    {
        [Key]
        public long StoreId { get; set; }

        public string Name { get; set; }

        public int Contact { get; set; }

        public decimal Commission { get; set; }

        public decimal DeliveryFee { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public long? AddressId { get; set; }
        public Address Address { get; set; }

        public ServiceType ServiceType { get; set; }
        public int? ServiceTypeId { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<StoreCategory> StoreCategories { get; set; }
    }
}
