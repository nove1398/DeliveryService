﻿// <auto-generated />
using System;
using DeliveryService.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliveryService.Server.Migrations
{
    [DbContext(typeof(DeliveryContext))]
    [Migration("20200707064907_ChangedContactType")]
    partial class ChangedContactType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliveryService.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DeliveryService.Models.Favourite", b =>
                {
                    b.Property<int>("FavouriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("FavouriteId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppRoles", b =>
                {
                    b.Property<int>("AppRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppRolesId");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            AppRolesId = 1,
                            Description = "Admin for app",
                            Name = "Admin"
                        },
                        new
                        {
                            AppRolesId = 2,
                            Description = "Customer making an order",
                            Name = "Customer"
                        },
                        new
                        {
                            AppRolesId = 3,
                            Description = "Courier delivery",
                            Name = "Rider"
                        },
                        new
                        {
                            AppRolesId = 4,
                            Description = "Store user managing the store account",
                            Name = "Store"
                        });
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUser", b =>
                {
                    b.Property<long>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BetaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RiderId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AppUserId");

                    b.HasIndex("RiderId")
                        .IsUnique()
                        .HasFilter("[RiderId] IS NOT NULL");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserFavourite", b =>
                {
                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("FavouriteId")
                        .HasColumnType("int");

                    b.HasKey("AppUserId", "FavouriteId");

                    b.HasIndex("FavouriteId");

                    b.ToTable("AppUserFavourites");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserOrder", b =>
                {
                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("AppUserId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("AppUserOrders");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserReview", b =>
                {
                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("AppUserId", "ReviewId");

                    b.HasIndex("ReviewId");

                    b.ToTable("AppUserReviews");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserRoles", b =>
                {
                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.HasKey("AppRoleId", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Audit", b =>
                {
                    b.Property<long>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<long?>("AppUserId1")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("AuditId");

                    b.HasIndex("AppUserId1");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CartId");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.CartMenuItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.HasKey("CartId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("CartMenuItems");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.CategoryMenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("MenuItemId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryMenuItems");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Recipe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StoreId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("MenuItemId");

                    b.HasIndex("StoreId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.MenuItemTag", b =>
                {
                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("MenuItemTags");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeliveredAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime?>("EstimatedDeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.OrderMenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("MenuItemId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderMenuItems");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.PasswordReset", b =>
                {
                    b.Property<int>("PasswordResetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PasswordResetId");

                    b.ToTable("PasswordResets");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.Property<int?>("MenuItemId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Rider", b =>
                {
                    b.Property<int>("RiderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("RiderDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RiderId");

                    b.HasIndex("RiderDetailsId");

                    b.ToTable("Riiders");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.RiderDetails", b =>
                {
                    b.Property<int>("RiderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignedParish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TRN")
                        .HasColumnType("int");

                    b.Property<int>("Vehicle")
                        .HasColumnType("int");

                    b.HasKey("RiderDetailsId");

                    b.ToTable("RiderDetails");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Store", b =>
                {
                    b.Property<long>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Commission")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Contact")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<decimal>("DeliveryFee")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StoreId");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Address", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany("Addresses")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUser", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.Rider", "Rider")
                        .WithOne("AppUser")
                        .HasForeignKey("DeliveryService.Shared.Models.AppUser", "RiderId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserFavourite", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany("AppUserFavourites")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Models.Favourite", "Favourite")
                        .WithMany("AppUserFavourites")
                        .HasForeignKey("FavouriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserOrder", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany("AppUserOrders")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.Order", "Order")
                        .WithMany("AppUserOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserReview", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany("AppUserReviews")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.Review", "Review")
                        .WithMany("AppUserReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.AppUserRoles", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppRoles", "AppRole")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Audit", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId1");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Cart", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithOne()
                        .HasForeignKey("DeliveryService.Shared.Models.Cart", "AppUserId");
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.CartMenuItem", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.Cart", "Cart")
                        .WithMany("CartMenuItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.MenuItem", "MenuItem")
                        .WithMany("CartMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.CategoryMenuItem", b =>
                {
                    b.HasOne("DeliveryService.Models.Category", "Category")
                        .WithMany("CategoryMenuItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.MenuItem", "MenuItem")
                        .WithMany("CategoryMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.MenuItem", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.Store", "Store")
                        .WithMany("MenuItems")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.MenuItemTag", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.MenuItem", "MenuItem")
                        .WithMany("MenuItemTags")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.Tag", "Tag")
                        .WithMany("MenuItemTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Order", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.OrderMenuItem", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.MenuItem", "MenuItem")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Review", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithMany("Reviews")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.MenuItem", "MenuItem")
                        .WithMany("Reviews")
                        .HasForeignKey("MenuItemId")
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Rider", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.RiderDetails", "RiderDetails")
                        .WithMany("Riders")
                        .HasForeignKey("RiderDetailsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryService.Shared.Models.Store", b =>
                {
                    b.HasOne("DeliveryService.Shared.Models.Address", "Address")
                        .WithMany("Stores")
                        .HasForeignKey("AddressId")
                        .IsRequired();

                    b.HasOne("DeliveryService.Shared.Models.AppUser", "AppUser")
                        .WithOne("Store")
                        .HasForeignKey("DeliveryService.Shared.Models.Store", "AppUserId");

                    b.HasOne("DeliveryService.Shared.Models.ServiceType", "ServiceType")
                        .WithMany("Stores")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
