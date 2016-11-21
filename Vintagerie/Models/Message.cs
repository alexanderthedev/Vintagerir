using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vintagerie.Models
{
    public class Message
    {
        public ApplicationUser Sender { get; set; }
        [Key]
        [Column(Order = 1)]
        public string SenderId { get; set; }
        public ApplicationUser Receiver { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ReceiverId { get; set; }
        public MessageRoom MessageRoom { get; set; }
        public Guid MessageRoomId { get; set; }
        public DateTime TimeSent { get; set; }

        public string Content { get; set; } 
    }
}