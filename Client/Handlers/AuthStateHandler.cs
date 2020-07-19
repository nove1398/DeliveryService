using DeliveryService.Shared.Constants;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryService.Client.Handlers
{
    public class AuthStateHandler : AuthenticationStateProvider
    {
        private readonly LocalStorageHandler _localStorage;

        public AuthStateHandler(LocalStorageHandler localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await GetTokenAsync();
            var identity = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task SetTokenAsync(string token, DateTime expiry = default)
        {
            if (string.IsNullOrEmpty(token))
            {
                await _localStorage.RemoveItem(Constants.JWTKey);
                await _localStorage.RemoveItem(Constants.JWTExpiry);
            }
            else
            {
                await _localStorage.SetItem(Constants.JWTKey, token);
                await _localStorage.SetItem(Constants.JWTExpiry, expiry);
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private async Task<string> GetTokenAsync()
        {
            var expiry = await _localStorage.GetItem<string>(Constants.JWTExpiry);

            if (!string.IsNullOrEmpty(expiry) && DateTime.Parse(expiry) > DateTime.Now)
            {
                return await _localStorage.GetItem<string>(Constants.JWTKey);
            }
            else
            {
                await _localStorage.RemoveItem(Constants.JWTKey);
                await _localStorage.RemoveItem(Constants.JWTExpiry);
            }
            return null;
        }

        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
