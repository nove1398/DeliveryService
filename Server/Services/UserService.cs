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
    public interface IUserService
    {
        Task<bool> DeleteUser(long id);
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUser(string email);
        Task<AppUser> CreateUser(AppUser user);
        Task<AppUser> UpdateUser(AppUser updatedUser);
        Task<List<AppUser>> UsersByRole(int roleId);
        Task<List<AppUser>> SearchUsers(string needle);
        Task<List<UserViewModel>> UserRoles(int userId);
        Task<List<UserViewModel>> UsersNotOwners(string needle);
    }

    public class UserService : IUserService
    {
        private readonly DeliveryContext _context;

        public UserService(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<AppUser> CreateUser(AppUser user)
        {
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUser(string email)
        {
            return await _context.AppUsers
                .Include(x => x.AppUserRoles)
                .ThenInclude(x=>x.AppRole)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.AppUsers
                .AsNoTracking()
                .Include(x => x.AppUserRoles)
                .ThenInclude(y => y.AppRole)
                .Where(x => x.IsActive).ToListAsync();
        }

        public Task<List<AppUser>> SearchUsers(string needle)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> UpdateUser(AppUser updatedUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserViewModel>> UserRoles(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> UsersByRole(int roleId)
        {
            //return await _context.AppUserRoles.AsNoTracking().Where(x => x.AppUserId == roleId).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> UsersNotOwners(string needle)
        {
            //Users who are not assigned to store
            var setOfOwners = _context.AppUserStores.AsNoTracking().Select(x => x.AppUserId).ToHashSet();
            return await _context.AppUsers
                 .AsNoTracking()
                 .Where(user => !setOfOwners.Contains(user.AppUserId)  )
                 .Select(model => new UserViewModel {
                     UserId = model.AppUserId,
                      Address = model.Address,
                     Email = model.Email,
                     DateOfBirth = model.DateOfBirth,
                     FirstName = model.FirstName,
                     LastName = model.LastName, 
                     IsActive = model.IsActive, 
                     Nickname = model.Nickname, 
                     Photo = model.Photo, 
                     Roles = model.AppUserRoles.Where( roles => roles.AppUserId == model.AppUserId).Select(aur => aur.AppRole).ToList(), 
                     Sex = model.Sex
                 })
                 .ToListAsync();
        }
    }
}
