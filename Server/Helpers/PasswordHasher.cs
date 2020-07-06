using DeliveryService.Shared.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Server.Helpers
{
    public class PasswordHasher
    {
        private RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        private int HashSize = 50;


        public HashedPassword HashPassword(string passwordToHash)
        {
            return new HashedPassword(GenerateHash(passwordToHash), GenerateSalt());
           
        }


        public bool VerifyPassword(string hashedPass,string dbPass,string salt)
        {
            return salt+hashedPass == salt+dbPass;
        }

        private string GenerateSalt()
        {
            byte[] bytes = new byte[HashSize];
            crypto.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        private string GenerateHash(string password)
        {
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            var bytesToHash = Encoding.UTF8.GetBytes(password);
            var hashedPass = hashAlg.ComputeHash(bytesToHash);
            return Convert.ToBase64String(hashedPass);
        }
    }
}
