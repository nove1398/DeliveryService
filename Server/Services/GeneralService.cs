using DeliveryService.Server.Data;
using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Server.Services
{
    public interface IGeneralService
    {
        Task<List<ServiceType>> GetAllServiceTypes();
        Task<List<Parish>> GetAllParishes();
        Task<Address> AddNewAddress(Address address);
    }


    public class GeneralService : IGeneralService
    {

        private readonly DeliveryContext _context;


        public GeneralService(DeliveryContext context)
        {
            _context = context;
        }

        public async Task<Address> AddNewAddress(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public async Task<List<Parish>> GetAllParishes()
        {
            return await _context.Parishes.AsNoTracking().ToListAsync();
        }

        public async Task<List<ServiceType>> GetAllServiceTypes()
        {
            return await _context.ServiceTypes.AsNoTracking().ToListAsync();
        }
    }
}
