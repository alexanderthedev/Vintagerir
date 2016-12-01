using System;

namespace Vintagerie.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public NotificationType Type { get; set; }

    }
}