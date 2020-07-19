using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Shared.API
{
    public class AuthResponse
    {
        public string Error { get; set; }

        public bool Successfull { get; set; }

        public string Token { get; set; }
    }
}
