using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class AppUserRoles
    {
        public int AppRolesId { get; set; }
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }
        public AppRoles AppRoles { get; set; }
    }
}
