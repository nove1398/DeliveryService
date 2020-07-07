using DeliveryService.Models;
using DeliveryService.Server.Helpers;
using DeliveryService.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DeliveryService.Server.Data
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // JOINS M > - - - - < M
            builder.Entity<AppUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.AppRoleId, e.AppUserId });
                entity.HasOne(aur => aur.AppUser).WithMany(au => au.AppUserRoles).HasForeignKey(aur => aur.AppUserId);
                entity.HasOne(aur => aur.AppRole).WithMany(au => au.AppUserRoles).HasForeignKey(aur => aur.AppRoleId);
            });
            builder.Entity<AppUserFavourite>(entity =>
            {
                entity.HasKey(e => new { e.AppUserId, e.FavouriteId });
                entity.HasOne(aur => aur.Favourite).WithMany(au => au.AppUserFavourites).HasForeignKey(aur => aur.FavouriteId);
                entity.HasOne(aur => aur.AppUser).WithMany(au => au.AppUserFavourites).HasForeignKey(aur => aur.AppUserId);
            });
            builder.Entity<AppUserOrder>(entity =>
            {
                entity.HasKey(e => new { e.AppUserId, e.OrderId });
                entity.HasOne(aur => aur.AppUser).WithMany(au => au.AppUserOrders).HasForeignKey(aur => aur.AppUserId);
                entity.HasOne(aur => aur.Order).WithMany(au => au.AppUserOrders).HasForeignKey(aur => aur.OrderId);
            });
            builder.Entity<AppUserReview>(entity =>
            {
                entity.HasKey(e => new { e.AppUserId, e.ReviewId });
                entity.HasOne(aur => aur.AppUser).WithMany(au => au.AppUserReviews).HasForeignKey(aur => aur.AppUserId);
                entity.HasOne(aur => aur.Review).WithMany(au => au.AppUserReviews).HasForeignKey(aur => aur.ReviewId);
            });
            builder.Entity<CartMenuItem>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.MenuItemId });
                entity.HasOne(aur => aur.Cart).WithMany(au => au.CartMenuItems).HasForeignKey(aur => aur.CartId);
                entity.HasOne(aur => aur.MenuItem).WithMany(au => au.CartMenuItems).HasForeignKey(aur => aur.MenuItemId);
            });
            builder.Entity<OrderMenuItem>(entity =>
            {
                entity.HasKey(e => new { e.MenuItemId, e.OrderId });
                entity.HasOne(aur => aur.Order).WithMany(au => au.OrderMenuItems).HasForeignKey(aur => aur.OrderId);
                entity.HasOne(aur => aur.MenuItem).WithMany(au => au.OrderMenuItems).HasForeignKey(aur => aur.MenuItemId);
            });
            builder.Entity<CategoryMenuItem>(entity =>
            {
                entity.HasKey(e => new { e.MenuItemId, e.CategoryId });
                entity.HasOne(aur => aur.Category).WithMany(au => au.CategoryMenuItems).HasForeignKey(aur => aur.CategoryId);
                entity.HasOne(aur => aur.MenuItem).WithMany(au => au.CategoryMenuItems).HasForeignKey(aur => aur.MenuItemId);
            });
            builder.Entity<MenuItemTag>(entity =>
            {
                entity.HasKey(e => new { e.MenuItemId, e.TagId });
                entity.HasOne(aur => aur.MenuItem).WithMany(au => au.MenuItemTags).HasForeignKey(aur => aur.MenuItemId);
                entity.HasOne(aur => aur.Tag).WithMany(au => au.MenuItemTags).HasForeignKey(aur => aur.TagId);
            });

            //AppUser
            var hasher = new PasswordHasher();
            var creds = hasher.HashPassword("password");
            var user = new AppUser();
            user.AppUserId = 1;
            user.Sex = AppUser.Gender.Male;
            user.FirstName = "evon";
            user.LastName = "franklin";
            user.IsActive = true;
            user.BetaCode = "gPOOLderZ";
            user.Biography = "Hi, i'm new";
            user.Contact = "18762782795";
            user.CreatedAt = DateTime.Now;
            user.Email = "nove1398@yahoo.com";
            user.DateOfBirth = new DateTime(1989, 11, 28);
            user.Nickname = "nove";
            user.Salt = creds.Salt;
            user.HashedPassword = creds.HashedPass;

            builder.Entity<AppUser>(entity =>
            {
                entity.HasData(user);
                entity.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(a => a.UpdatedAt).IsRequired(false);
                entity.Property(a => a.DateOfBirth).IsRequired(false);
                
                entity.HasMany(au => au.Reviews).WithOne(r => r.AppUser).HasForeignKey(r => r.AppUserId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(au => au.Addresses).WithOne(a => a.AppUser).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(au => au.Reviews).WithOne(a => a.AppUser).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.NoAction);

            });

            //Address
            var address = new Address() { AddressId = 1, AddressLine1 = "merrivale apartments", AddressLine2 = "13 merrivale close", Parish = "Kingston", AppUserId = 1 };
            builder.Entity<Address>(entity =>
            {
                entity.HasData(address);
            });

            //Audit
            builder.Entity<Audit>(entity =>
            {
                entity.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
            });

            // Cart 
            builder.Entity<Cart>(entity =>
            {
                entity.Property(c => c.Tax).HasColumnType("decimal(5,2)");
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(c => c.UpdatedAt).IsRequired(false);

                entity.HasOne(c => c.AppUser).WithOne().HasForeignKey<Cart>(c => c.AppUserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            });

            // Roles
            var roleList = new List<AppRoles>() {
                new AppRoles { AppRolesId = 1, Description="Admin for app", Name ="Admin" },
                new AppRoles { AppRolesId = 2, Description="Customer making an order", Name ="Customer" },
                new AppRoles { AppRolesId = 3, Description="Courier delivery", Name ="Rider" },
                new AppRoles { AppRolesId = 4, Description="Store user managing the store account", Name ="Store" },
                new AppRoles { AppRolesId = 4, Description="Base account, no value or moral. No contribution to the community", Name ="User" }
            };
            builder.Entity<AppRoles>(entity =>
            {
                entity.HasData(roleList);

            });

            //Category
            builder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(c => c.UpdatedAt).IsRequired(false);
            });

            // Favourite
            builder.Entity<Favourite>(entity =>
            {
                entity.Property(f => f.Title).IsRequired().HasMaxLength(100);

            });

            // MenuItem
            builder.Entity<MenuItem>(entity =>
            {
                entity.Property(mi => mi.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(mi => mi.Name).IsRequired();
                entity.Property(mi => mi.Price).HasColumnType("decimal(10,2)");
                entity.Property(mi => mi.Tax).HasColumnType("decimal(10,2)");

                entity.HasOne(mi => mi.Store).WithMany(s => s.MenuItems).HasForeignKey(s => s.StoreId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(mi => mi.Reviews).WithOne(s => s.MenuItem).HasForeignKey(s => s.MenuItemId).IsRequired().OnDelete(DeleteBehavior.ClientSetNull);
            });

            //Tag
            builder.Entity<Tag>(entity =>
            {
                entity.Property(t => t.Name).IsRequired();
            });

            //Order
            builder.Entity<Order>(entity =>
            {
                entity.Property(o => o.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(o => o.UpdatedAt).IsRequired(false);
                entity.Property(o => o.EstimatedDeliveryTime).IsRequired(false);
                entity.Property(o => o.DeliveredAt).IsRequired(false);
                entity.Property(o => o.FinalPrice).HasColumnType("decimal(10,2)");
                entity.Property(o => o.Discount).HasColumnType("decimal(10,2)");

                entity.HasOne(o => o.OrderStatus).WithMany(os => os.Orders).HasForeignKey(o => o.OrderStatusId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            //Password Reset
            builder.Entity<PasswordReset>(entity =>
            {
                entity.Property(pr => pr.Email).IsRequired();
                entity.Property(pr => pr.PasswordResetId).IsRequired();
            });

            //Review
            builder.Entity<Review>(entity =>
            {
                entity.Property(pr => pr.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(pr => pr.Rating);
                entity.Property(pr => pr.Details).HasMaxLength(600);
            });

            //Rider
            builder.Entity<Rider>(entity =>
            {
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(c => c.UpdatedAt).IsRequired(false);

                entity.HasOne(r => r.RiderDetails).WithMany(r => r.Riders).HasForeignKey(r => r.RiderDetailsId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(r => r.AppUser).WithOne(r => r.Rider).IsRequired(false).HasForeignKey<AppUser>(au => au.RiderId).OnDelete(DeleteBehavior.SetNull);
            });

            //RiderDetails
            builder.Entity<RiderDetails>(entity =>
            {

            });

            //ServiceType
            builder.Entity<ServiceType>(entity =>
            {
                entity.HasMany(st => st.Stores).WithOne(s => s.ServiceType).IsRequired(false).HasForeignKey(s => s.ServiceTypeId).OnDelete(DeleteBehavior.SetNull);
            });

            //Store
            builder.Entity<Store>(entity =>
            {
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(c => c.UpdatedAt).IsRequired(false);
                entity.Property(o => o.DeliveryFee).HasColumnType("decimal(10,2)");
                entity.Property(o => o.Commission).HasColumnType("decimal(10,2)");

                entity.HasOne(s => s.Address).WithMany(a => a.Stores).IsRequired().HasForeignKey(s => s.AddressId).OnDelete(DeleteBehavior.ClientSetNull);

            });
        }


        public DbSet<Address> Address { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRoles> AppRoles { get; set; }
        public DbSet<AppUserFavourite> AppUserFavourites { get; set; }
        public DbSet<AppUserOrder> AppUserOrders { get; set; }
        public DbSet<AppUserReview> AppUserReviews { get; set; }
        public DbSet<AppUserRoles> AppUserRoles { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartMenuItem> CartMenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryMenuItem> CategoryMenuItems { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemTag> MenuItemTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rider> Riiders { get; set; }
        public DbSet<RiderDetails> RiderDetails { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
