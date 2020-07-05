using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class AppRoles
    {
        [Key]
        public int AppRolesId { get; set; }

        public string Name { get; set; }

        public ICollection<AppUserRoles> APpUserRoles { get; set; }
    }
}
