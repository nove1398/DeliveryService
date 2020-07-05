using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Store
    {
        [Key]
        public long BusinessEntityId { get; set; }

        public string BusinessName { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }


    }
}
