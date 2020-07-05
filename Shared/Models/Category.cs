using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }

        public string CateogryName { get; set; }
    }
}
