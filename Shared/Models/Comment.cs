﻿using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryService.Shared.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Details { get; set; }

        public bool IsPraise { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public long? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
