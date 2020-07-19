using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DeliveryService.Client.Handlers;
using Microsoft.AspNetCore.Components.Authorization;
using DeliveryService.Shared.Constants;

namespace DeliveryService.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(PolicyHandler.IsAdmin, PolicyHandler.IsAdminPolicy());
                config.AddPolicy(PolicyHandler.IsUser, PolicyHandler.IsUserPolicy());
            });

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<HttpHandler>();
            builder.Services.AddTransient<LocalStorageHandler>();
            var toke = await builder.Services.BuildServiceProvider().GetRequiredService<LocalStorageHandler>().GetItem<string>(Constants.JWTKey);
            builder.Services.AddHttpClient<HttpHandler>(
                 client => {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {toke}");
                });
            builder.Services.AddTransient<AuthStateHandler>();
            builder.Services.AddTransient<AuthenticationStateProvider>(provider => provider.GetRequiredService<AuthStateHandler>());
            await builder.Build().RunAsync();
        }
    }
}
