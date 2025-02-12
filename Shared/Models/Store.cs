﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class Store
    {
        [Key]
        public long StoreId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        public decimal Commission { get; set; }

        public decimal DeliveryFee { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public long? AddressId { get; set; }
        [ValidateComplexType]
        public Address Address { get; set; }

        public int? ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<AppUserStore> AppUserStores { get; set; }
    }
}
