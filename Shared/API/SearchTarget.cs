using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Shared.API
{
    public class SearchTarget
    {
        [System.ComponentModel.DataAnnotations.MinLength(3, ErrorMessage = "Minimum 3 characters")]
        public string searchString { get; set; }
    }
}
