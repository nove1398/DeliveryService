using DeliveryService.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Shared.Models
{
    public class AppUser
    {
        [Key]
        public long AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Salt { get; set; }

        public string HashedPassword { get; set; }

        public string Contact { get; set; }

        public string BetaCode { get; set; }

        public string Photo { get; set; }

        public string Nickname { get; set; }

        public bool IsActive { get; set; }

        public string Biography { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual Rider Rider { get; set; }

        public Store Store { get; set; }

        public long? AddressId { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<AppUserRoles> AppUserRoles { get; set; }
        public virtual ICollection<AppUserStore> AppUserStores { get; set; }
        public virtual ICollection<AppUserOrder> AppUserOrders { get; set; }
        public virtual ICollection<AppUserReview> AppUserReviews { get; set; }
        public virtual ICollection<AppUserFavourite> AppUserFavourites { get; set; }

        public enum Gender
        {
            Male,Female
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
