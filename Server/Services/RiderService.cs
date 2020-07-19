using DeliveryService.Server.Data;
using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Server.Services
{
    public interface IRiderService
    {
        Task<List<Rider>> AllRidersAsync();
    }


    public class RiderService : IRiderService
    {
        private readonly DeliveryContext _context;

        public RiderService(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<List<Rider>> AllRidersAsync()
        {
            return await _context.Riiders.AsNoTracking().Where(r => r.IsAccountActive).ToListAsync();
        }
    }
}
