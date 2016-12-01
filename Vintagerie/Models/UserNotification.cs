using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vintagerie.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid NotificationId { get; set; }

        public ApplicationUser User { get; set; }
        public Notification Notification { get; set; }
        public bool IsRead { get; set; } 
    }
}