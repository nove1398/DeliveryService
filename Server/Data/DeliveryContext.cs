using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DeliveryService.Server.Data
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // 
            builder.Entity<AppUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.AppRolesId, e.AppUserId });
            });

            // Roles
            var roleList = new List<AppRoles>() { 
                new AppRoles { AppRolesId =1, Description="", Name ="Admin" },
                new AppRoles { AppRolesId =2, Description="", Name ="Admin" },
                new AppRoles { AppRolesId =3, Description="", Name ="Admin" },
            };
            builder.Entity<AppRoles>(entity =>
            {
                entity.HasData(roleList);
            });
        }


        public DbSet<Address> Address { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
