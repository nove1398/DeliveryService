using DeliveryService.Shared.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DeliveryService.Models
{
    public class Favourite
    {
        [Key]
        public int FavouriteId { get; set; }

        public string Title { get; set; } 

        public FavouriteType Type { get; set; }

        public long ItemId { get; set; }

        public virtual ICollection<AppUserFavourite> AppUserFavourites { get; set; }

        public enum FavouriteType
        {
            OrderItem,
            Store
        }
    }
}
