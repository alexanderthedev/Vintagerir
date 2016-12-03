using Microsoft.AspNet.Identity;
using System;
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
            var myRooms = _context.MessageRooms
                .Include("UserA")
                .Include("UserB")
                .Where(r => r.UserAId == myId || r.UserBId == myId)
                .ToList();

            return View(myRooms);
        }

        public ActionResult MessageRoom(string id)
        {

            var myId = User.Identity.GetUserId();

            var ourMessageRoom = 
                _context.MessageRooms
                .SingleOrDefault(r => (r.UserAId == myId || r.UserBId == myId) && (r.UserAId == id || r.UserBId == id));


           
            if (ourMessageRoom == null)
            {
                
                var createMessageRoom = new MessageRoom
                {
                    Id = Guid.NewGuid(),
                    UserAId = myId,
                    UserBId = id
                };
                _context.MessageRooms.Add(createMessageRoom);
                _context.SaveChanges();
            }

            var allMessage = _context.Messages
                .Include("Sender")
                .Include("Receiver")
                .Where(m => m.MessageRoomId == ourMessageRoom.Id )
                .OrderBy(m => m.TimeSent);
           
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
            var roomId =
                _context.MessageRooms.Single(
                    r =>
                        (r.UserAId == myId || r.UserBId == myId) &&
                        (r.UserAId == message.ReceiverId || r.UserBId == message.ReceiverId));

            var newMessage = new Message
            {
                Id = Guid.NewGuid(),
                Content = message.SingleMessage.Content,
                MessageRoomId = roomId.Id,
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