using DeliveryService.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Shared.Models
{
    public class RiderDetails
    {
        [Key]
        public int RiderDetailsId { get; set; }

        public int TRN { get; set; }

        public string LicencePlate { get; set; }

        public string AssignedParish { get; set; }

        public VehicleType Vehicle { get; set; }

         public AppUser.Gender Sex { get; set; }

        public int RiderId { get; set; }
        public Rider Rider { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

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
