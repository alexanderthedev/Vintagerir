using System;

namespace Vintagerie.Models
{
    public class MessageRoom
    {
        public Guid Id { get; set; }
        public ApplicationUser UserA { get; set; }
        public string UserAId { get; set; }
        public ApplicationUser UserB { get; set; }
        public string UserBId { get; set; }
    }
}