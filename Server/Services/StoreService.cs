using DeliveryService.Server.Data;
using DeliveryService.Shared.Models;
using DeliveryService.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Server.Services
{
    public interface IStoreService
    {
        Task<List<StoreViewModel>> AllStoresAsync();
        Task<List<StoreViewModel>> AllActiveStoresAsync();
        Task<List<StoreViewModel>> AllInActiveStoresAsync();
        Task<List<StoreViewModel>> StoresByParishASync(string parish);
        Task<int> AddNewStore(Store newStore);
        Task<Store> FindStore(int id);
    }

    public class StoreService : IStoreService
    {
        private readonly DeliveryContext _context;

        public StoreService(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewStore(Store newStore)
        {
            _context.Stores.Add(newStore);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<StoreViewModel>> AllActiveStoresAsync()
        {
            return await _context.Stores.AsNoTracking()
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .Select(model => new StoreViewModel 
                {
                    StoreName = model.Name,
                     Contact = model.Contact,
                     Id = model.StoreId, 
                    IsActive = model.IsActive, 
                    OwnerNames = model.AppUserStores.Where(x => x.StoreId == model.StoreId ).Select(y => y.AppUser.GetFullName()).ToList(),
                    ServiceType = model.ServiceType.Name
                })
                .ToListAsync();
        }

        public Task<List<StoreViewModel>> AllInActiveStoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StoreViewModel>> AllStoresAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Store> FindStore(int id)
        {
            return await _context.Stores
                 .Where(s => s.StoreId == id)
                 .FirstOrDefaultAsync();
        }

        public Task<List<StoreViewModel>> StoresByParishASync(string parish)
        {
            throw new NotImplementedException();
        }
    }
}
