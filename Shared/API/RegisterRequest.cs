using DeliveryService.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using static DeliveryService.Shared.Models.AppUser;

namespace DeliveryService.Shared.API
{
    public class RegisterRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string NickName { get; set; }

        [RegularExpression(@"^[0-9-'\s]{1,14}$", ErrorMessage = "Alpha characters are not allowed.")]
        public string Contact { get; set; }

        [Required]
        public Gender Sex { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-40);

        [ValidateComplexType]
        public Address Address { get; set; } = new Address();

    }
}
