using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DeliveryService.Server.Middleware
{
    public class ApiMiddleware : DelegatingHandler
    {
        public ApiMiddleware()
        {

        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellation)
        {

            return base.SendAsync(request, cancellation);
        }
    }
}
