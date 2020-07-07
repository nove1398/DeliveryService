using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MenuItemTag> MenuItemTags { get; set; }


    }
}
