using DeliveryService.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DeliveryService.Shared.Models.AppUser;

namespace DeliveryService.Shared.ViewModels
{
    public class UserViewModel
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public bool IsActive { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<AppRoles> Roles { get; set; }

        public Address Address { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
