using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingMe.Services
{
    public interface ICredentialService
    {
        public string HashPassword(string password);
    }
    public class CredentialService
    {
    }
}
