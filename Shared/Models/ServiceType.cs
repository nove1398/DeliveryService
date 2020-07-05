using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
