using DeliveryService.Server.Data;
using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Server.Services
{
    public interface IStoreService
    {
        Task<List<Store>> AllStoresAsync();
        Task<List<Store>> AllActiveStoresAsync();
        Task<List<Store>> AllInActiveStoresAsync();
        Task<List<Store>> StoresByParishASync(string parish);
    }

    public class StoreService : IStoreService
    {
        private readonly DeliveryContext _context;

        public StoreService(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> AllActiveStoresAsync()
        {
            return await _context.Stores.AsNoTracking().Where(s => s.IsActive).OrderBy(s => s.Name).ToListAsync();
        }

        public Task<List<Store>> AllInActiveStoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Store>> AllStoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Store>> StoresByParishASync(string parish)
        {
            throw new NotImplementedException();
        }
    }
}
