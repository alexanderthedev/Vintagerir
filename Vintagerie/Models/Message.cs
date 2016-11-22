using System;

namespace Vintagerie.Models
{
    public class Message
    {
        public Guid Id { get; set; }    
        public ApplicationUser Sender { get; set; }
        
        public string SenderId { get; set; }
        public ApplicationUser Receiver { get; set; }
       
        public string ReceiverId { get; set; }
        public MessageRoom MessageRoom { get; set; }
        public Guid MessageRoomId { get; set; }
        public DateTime TimeSent { get; set; }

        public string Content { get; set; } 
    }
}