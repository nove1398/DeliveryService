using DeliveryService.Server.Data;
using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Server.Services
{
    public interface IUserService
    {
        Task<bool> DeleteUser(int id);
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUser(string email);
        Task<AppUser> CreateUser(AppUser user);
        Task<AppUser> UpdateUser(AppUser updatedUser);
        Task<List<AppUser>> UsersByRole(int roleId);
    }

    public class UserService : IUserService
    {
        private readonly DeliveryContext _context;

        public UserService(DeliveryContext context)
        {
            _context = context;
        }

        public Task<AppUser> CreateUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUser(string email)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<List<AppUser>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> UpdateUser(AppUser updatedUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> UsersByRole(int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
