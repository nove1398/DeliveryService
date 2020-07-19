using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.Constants
{
    public class Constants
    {
        public const string JWTKey = "JWTToke";
        public const string JWTExpiry = "JWTExpire";

        public static string[] Parishes = new string[]
        {
            "Portland","St. Thomas","St. Mary","Kingston","St. Andrew","St. Catherine","St. Ann","Clarendon",
            "Manchester","St. Elizabeth", "Trelawny","St. James","Westmoreland","Hanover"
        };
    }
}
