using DeliveryService.Models;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class Rider
    {
        [Key]
        public int RiderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TRN { get; set; }

        public bool IsAccountActive { get; set; }

        public string Avatar { get; set; }

        public string AssignedParish { get; set; }

        public AppUser.Gender Sex { get; set; }

        public bool IsAssigned { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }



        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
