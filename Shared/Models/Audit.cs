using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class Audit
    {
        [Key]
        public long AuditId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
