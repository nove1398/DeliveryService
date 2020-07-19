using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Client.Handlers
{
    public class PolicyHandler
    {
        public const string IsAdmin = "IsAdmin";
        public const string IsUser = "IsUser";
        public const string IsRider = "IsRider";
        public const string IsStore = "IsStore";
        public const string IsCustomer = "IsCustomer";

        public static AuthorizationPolicy IsAdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("Admin")
                                                   .Build();
        }

        public static AuthorizationPolicy IsUserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("User")
                                                   .Build();
        }

        public static AuthorizationPolicy IsStorePolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("Store")
                                                   .Build();
        }

        public static AuthorizationPolicy IsRiderPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("Rider")
                                                   .Build();
        }

        public static AuthorizationPolicy IsCustomerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("Customer")
                                                   .Build();
        }
    }
}
