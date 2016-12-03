using System;
using Vintagerie.Models;

namespace Vintagerie.Dtos
{
    public class NotificationDto
    {
        public DateTime DateCreate { get; private set; }
        public NotificationType Type { get; private set; }
        public ApplicationUserDto Creator { get; set; }

    }
}