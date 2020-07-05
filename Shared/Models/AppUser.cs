using DeliveryService.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class AppUser
    {
        [Key]
        public long AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Salt { get; set; }

        public string HashedPassword { get; set; }

        public int Contact { get; set; }

        public string BetaCode { get; set; }

        public string ResetCode { get; set; }

        public string Avatar { get; set; }

        public string Nickname { get; set; }

        public bool IsActive { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public long? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<AppUserRoles> AppUserRoles { get; set; }
        public virtual ICollection<AppUserOrder> AppUserOrders { get; set; }
        public virtual ICollection<AppUserFavourite> AppUserFavourites { get; set; }

        public enum Gender
        {
            Male,Female
        }
    }
}
