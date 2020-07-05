using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class AppUserFavourite
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int FavouriteId { get; set; }
        public Favourite Favourite { get; set; }
    }
}
