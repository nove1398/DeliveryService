using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Server.Extensions
{
    public static class RiderExtenions
    {
        public static Rider AllRiders(this DbSet<Rider> rider)
        {
            return new Rider();
        }
    }
}
