using DeliveryService.Shared.Models;
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

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<StoreCategory> StoreCategories { get; set; }
        public virtual ICollection<CategoryMenuItem> CategoryMenuItems { get; set; }
    }
}
