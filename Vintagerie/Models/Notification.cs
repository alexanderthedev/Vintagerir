using System;

namespace Vintagerie.Models
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public DateTime DateCreate { get; private set; }
        public NotificationType Type { get; private set; }
        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }


        public Notification()
        {
            
        }
        public Notification(NotificationType type, string myId)
        {
            Id = Guid.NewGuid();
            Type = type;
            DateCreate = DateTime.Now;
            CreatorId = myId;
        }
    }
}