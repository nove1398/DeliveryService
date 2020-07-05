using DeliveryService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeliveryService.Server.Services
{
    public interface ITokenService
    {
        public string GenerateToken(AppUser user);
        public string ValidateToken(string token);
    }


    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(AppUser user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, "Test")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(5);

            var token = new JwtSecurityToken(
                _config["JwtIssuer"],
                _config["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
