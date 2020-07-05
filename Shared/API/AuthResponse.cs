using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingMe.Models
{
    public class AuthResponse
    {
        public string Error { get; set; }

        public bool Successfull { get; set; }

        public string Token { get; set; }
    }
}
