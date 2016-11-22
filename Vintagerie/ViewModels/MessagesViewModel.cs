using System.Collections.Generic;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class MessagesViewModel
    {
        public IEnumerable<Message> ListOfMessages { get; set; }
        public Message SingleMessage { get; set; }
        public string ReceiverId { get; set; }  

    }
}