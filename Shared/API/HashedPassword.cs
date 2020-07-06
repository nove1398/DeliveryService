using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.API
{
    public class HashedPassword
    {
        private string Password { get;  set; }

        public  string Salt { get;  private set; }

        public string HashedPass { get { return Salt + Password; } }

        public HashedPassword(string pass, string salt)
        {
            Password = pass;
            Salt = salt;
        }
    }
}
