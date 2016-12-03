using System;
using Vintagerie.Models;

namespace Vintagerie.Controllers.Api
{
    public class NotificationDto
    {
        public DateTime DateCreate { get; private set; }
        public NotificationType Type { get; private set; }
        public ApplicationUserDto Creator { get; set; }

    }
}