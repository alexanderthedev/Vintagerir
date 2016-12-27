using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vintagerie.Models;
using Vintagerie.ViewModels;

namespace Vintagerie.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Messages
        public ActionResult MyMessages()
        {
            var myId = User.Identity.GetUserId();
            

            return View();
        }

        [Authorize]
        public ActionResult MessageRoom(string id)
        {

            var myId = User.Identity.GetUserId();

            var allMessage = _context.Messages
                .Include(m => m.Receiver)
                .Include(m => m.Sender)
                .Where(m => (m.ReceiverId == id || m.SenderId == id)
                            && (m.ReceiverId == myId || m.SenderId == myId)).ToList();
           
            var viewModel = new MessagesViewModel()
            {
                ReceiverId = id,
                ListOfMessages = allMessage
            };
            

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult SendMessage(MessagesViewModel message)
        {
            var myId = User.Identity.GetUserId();

            var newMessage = new Message
            {
                Id =  Guid.NewGuid(),
                Content = message.SingleMessage.Content,
                SenderId = myId,
                ReceiverId = message.ReceiverId,
                TimeSent = DateTime.Now
                
            };

            _context.Messages.Add(newMessage);

            
            var notification = new Notification(NotificationType.NewMessage, myId);

            var receiver = _context.Users.Single(u => u.Id == message.ReceiverId);

            receiver.Notify(notification);

           

            _context.SaveChanges();

            return RedirectToAction("MessageRoom",new {id = message.ReceiverId});
        }
    }
}