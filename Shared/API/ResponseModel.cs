﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingMe.Models
{
    public class ResponseModel <T>  where T : class
    {
        public T Data { get; set; }

        public string StatusCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}
