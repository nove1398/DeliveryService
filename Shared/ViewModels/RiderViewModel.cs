using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DeliveryService.Shared.Models.RiderDetails;

namespace DeliveryService.Shared.ViewModels
{
    public class RiderViewModel
    {
        public int Id { get; set; }

        public bool IsAccountActive { get; set; }

        public bool IsAvailable { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public long? AppUserId { get; set; }

        [Required]
        public int TRN { get; set; }

        [Required]
        public string LicencePlate { get; set; }

        public string AssignedParish { get; set; }

        [Required]
        public VehicleType Vehicle { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
