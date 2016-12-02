using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vintagerie.Models;

namespace Vintagerie.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;


        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<Notification> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .Select(u => u.Notification)
                .ToList();
            return notifications;
        }
    }
}
