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
    public interface IRiderService
    {
        Task<List<RiderViewModel>> AllRidersAsync();
        Task<List<RiderViewModel>> AllActiveRidersAsync();
        Task<List<RiderViewModel>> AllInActiveRidersAsync();
        Task<List<RiderViewModel>> AllRidersByParishAsync();
        Task<RiderViewModel> GetRiderAsync(int id);
        Task SaveNewRiderAsync(RiderViewModel rider);
        Task UpdateNewRiderAsync(RiderViewModel rider);
    }


    public class RiderService : IRiderService
    {
        private readonly DeliveryContext _context;

        public RiderService(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<List<RiderViewModel>> AllActiveRidersAsync()
        {
            return await _context.Riders
                 .AsNoTracking()
                 .Where(r => r.IsAccountActive)
                 .Select(
                 model => new RiderViewModel
                 {
                     AppUserId = model.AppUserId,
                     AssignedParish = model.RiderDetails.AssignedParish,
                     CreatedAt = model.CreatedAt,
                     Id = model.RiderId,
                     IsAccountActive = model.IsAccountActive,
                     IsAvailable = model.IsAvailable,
                     TRN = model.RiderDetails.TRN,
                     LicencePlate = model.RiderDetails.LicencePlate,
                     Vehicle = model.RiderDetails.Vehicle,
                     FirstName = model.AppUser.FirstName,
                     LastName = model.AppUser.LastName,
                     Email = model.AppUser.Email
                 }).ToListAsync();
        }

        public Task<List<RiderViewModel>> AllInActiveRidersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RiderViewModel>> AllRidersAsync()
        {
            return await _context.Riders
                .AsNoTracking()
                .Include(x => x.AppUser)
                .Select(
                model => new RiderViewModel {
                        AppUserId = model.AppUserId,
                        AssignedParish = model.RiderDetails.AssignedParish,
                        CreatedAt = model.CreatedAt,
                         Id = model.RiderId,
                         IsAccountActive = model.IsAccountActive,
                         IsAvailable = model.IsAvailable,
                         TRN = model.RiderDetails.TRN,
                         LicencePlate = model.RiderDetails.LicencePlate,
                         Vehicle = model.RiderDetails.Vehicle,
                        FirstName = model.AppUser.FirstName,
                        LastName = model.AppUser.LastName,
                        Email = model.AppUser.Email
                }).ToListAsync();
        }

        public Task<List<RiderViewModel>> AllRidersByParishAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RiderViewModel> GetRiderAsync(int id)
        {
            var rider = await _context.Riders
                                        .Where(x => x.RiderId == id)
                                        .Select(model => new RiderViewModel
                                        {
                                            Id = model.RiderId,
                                            CreatedAt = model.CreatedAt, 
                                            IsAvailable = model.IsAvailable, 
                                            Vehicle = model.RiderDetails.Vehicle,
                                            IsAccountActive = model.IsAccountActive, 
                                            LicencePlate = model.RiderDetails.LicencePlate,
                                            AssignedParish = model.RiderDetails.AssignedParish, 
                                            TRN = model.RiderDetails.TRN, AppUserId = model.AppUserId, 
                                            FirstName = model.AppUser.FirstName,
                                            LastName = model.AppUser.LastName,
                                            Email = model.AppUser.Email
                                        }).FirstOrDefaultAsync();
            return rider;
        }

        public async Task SaveNewRiderAsync(RiderViewModel model)
        {
            var rider = new Rider
            {
                IsAccountActive = true,
                IsAvailable = false, 
                AppUserId = model.AppUserId,
                CreatedAt = DateTime.Now, 
                RiderDetails = new RiderDetails { 
                                    AssignedParish = model.AssignedParish, 
                                    LicencePlate = model.LicencePlate, 
                                    TRN = model.TRN, 
                                    Vehicle = model.Vehicle
                }  
            };
            _context.Riders.Add(rider);
            await _context.SaveChangesAsync();
            var appUser = _context.AppUserRoles.Add(new AppUserRoles { AppRoleId = 3, AppUserId = model.AppUserId.Value });
            await _context.SaveChangesAsync();
        }

        public Task UpdateNewRiderAsync(RiderViewModel rider)
        {
            throw new NotImplementedException();
        }
    }
}
