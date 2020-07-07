using DeliveryService.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class RiderDetails
    {
        [Key]
        public int RiderDetailsId { get; set; }

        [Required]
        public int TRN { get; set; }

        [Required]
        public string LicencePlate { get; set; }

        public string AssignedParish { get; set; } 

        [Required]
        public VehicleType Vehicle { get; set; }

        public virtual ICollection<Rider> Riders { get; set; }

        public enum VehicleType
        {
            Car,
            Bike,
            Bicycle,
            Taxi,
            Bus

        }
    }
}
