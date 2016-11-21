using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using Vintagerie.Models;

namespace Vintagerie.Controllers
{
    public class MessagesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Messages
        public ActionResult Index()
        {
            return View("MyMessages");
        }

        public ActionResult MessageRoom(string id)
        {

            var myId = User.Identity.GetUserId();

            var ourMessageRoom = _context.MessageRooms.SingleOrDefault(r => (r.UserAId == myId || r.UserBId == myId) && (r.UserAId == id || r.UserBId == id));

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


            var allMessagesOfRoom = _context.Messages.Where(m => m.MessageRoomId == ourMessageRoom.Id).ToList();



            return View(allMessagesOfRoom);

        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            var myId = User.Identity.GetUserId();

           var addMessage = new Message
           {
               MessageRoomId = message.MessageRoomId,
               Content = message.Content,
               SenderId = myId,
               ReceiverId =  message.ReceiverId,
               TimeSent = DateTime.Now
           };

            _context.Messages.Add(addMessage);
            _context.SaveChanges();

            return RedirectToAction("MessageRoom");
        }
    }
}