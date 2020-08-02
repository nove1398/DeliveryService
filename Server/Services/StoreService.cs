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
        Task<List<StoreViewModel>> StoresByParishAsync(int parish);
        Task<int> AddNewStore(Store newStore);
        Task<StoreViewModel> FindStore(long id);
        Task<bool> UpdateStore(StoreViewModel model);
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
                    CurrentOwners = _context.AppUserStores
                                    .AsNoTracking()
                                    .Where(x => x.StoreId == model.StoreId)
                                    .Select(y => new Owner { Id = y.AppUser.AppUserId, Name = y.AppUser.GetFullName() }).ToList(),
                    ServiceType = model.ServiceType
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

        public async Task<StoreViewModel> FindStore(long id)
        {
            return await _context.Stores
                 .Where(s => s.StoreId == id)
                 .Select(model => new StoreViewModel
                 {
                     StoreName = model.Name,
                     Id = model.StoreId,
                     AddressId = model.AddressId,
                     Address = model.Address,
                     Contact = model.Contact,
                     Commission = model.Commission,
                     IsActive = model.IsActive,
                     DeliveryFee = model.DeliveryFee,
                     CurrentOwners = _context.AppUserStores
                                    .AsNoTracking()
                                    .Where(x => x.StoreId == model.StoreId)
                                    .Select(y => new Owner { Id = y.AppUser.AppUserId, Name = y.AppUser.GetFullName() }).ToList(),
                     ServiceType = model.ServiceType
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<List<StoreViewModel>> StoresByParishAsync(int parish)
        {
            return await _context.Stores
                .AsNoTracking()
                .Where(x => x.Address.ParishId == parish)
                .Select(store => new StoreViewModel 
                {
                    StoreName = store.Name,
                    Id = store.StoreId,
                    AddressId = store.AddressId,
                    Address = store.Address,
                    Contact = store.Contact,
                    Commission = store.Commission,
                    IsActive = store.IsActive,
                    DeliveryFee = store.DeliveryFee,
                    CurrentOwners = _context.AppUserStores
                                    .AsNoTracking()
                                    .Where(x => x.StoreId == store.StoreId)
                                    .Select(y => new Owner { Id = y.AppUser.AppUserId, Name = y.AppUser.GetFullName() })
                                    .ToList(),
                    ServiceType = store.ServiceType
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateStore(StoreViewModel model)
        {
            try
            {
                var currentStore = await _context.Stores.FirstOrDefaultAsync(s => s.StoreId == model.Id);

                currentStore.Name = model.StoreName;
                currentStore.Contact = model.Contact;
                currentStore.IsActive = model.IsActive;
                currentStore.DeliveryFee = model.DeliveryFee;
                currentStore.Address = model.Address; // might need to break out address in a separate query
                currentStore.ServiceType = model.ServiceType;
                currentStore.Commission = model.Commission;

                List<AppUserStore> updates = new List<AppUserStore>();
                foreach (var owner in model.GetStoreOwners())
                {
                    updates.Add(new AppUserStore { AppUserId = owner.Id, StoreId = currentStore.StoreId });
                }
                var query = _context.AppUserStores.Where(x => x.StoreId == currentStore.StoreId).ToList();
                _context.RemoveRange(query);
                _context.AppUserStores.AddRange(updates);
                await _context.SaveChangesAsync();

                return true;
            }catch(Exception message)
            {
                Console.WriteLine(message);
                return false;
            }
           
        }
    }
}
