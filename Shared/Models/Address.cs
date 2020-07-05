using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Address
    {
        [Key]
        public long AddressId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Province { get; set; }

        public string ZipCode { get; set; }


        public ICollection<Store> Stores { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
