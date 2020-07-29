using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Shared.API
{
    public class ResponseModel <T>  where T : class, new()
    {
        public T Data { get; set; }

        public string StatusCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}
