using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class PasswordReset
    {
        [Key]
        public int PasswordResetId { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
