using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Shared.Models
{
    /**
     * Food / Courier
     * */
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
