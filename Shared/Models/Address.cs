using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class Address
    {
        [Key]
        public long AddressId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string Country { get; set; } = "Jamaica";
    
        [Required]
        public int ParishId { get; set; }
        public Parish Parish { get; set; }

        public int ZipCode { get; set; } = 876; 

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }

        
    }
}
