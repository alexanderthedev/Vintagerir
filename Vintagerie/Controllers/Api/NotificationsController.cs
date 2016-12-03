using AutoMapper;
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
        private  ApplicationDbContext _context;


        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

       
        public IEnumerable<NotificationDto> GetNewNotifications()
        {

            

            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(n => n.UserId == userId)
                .Select(n => n.Notification)
                .Include(n => n.Creator)
                .ToList();

          
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notification, NotificationDto>();
                cfg.CreateMap<ApplicationUser, ApplicationUserDto>();
            });
            
            IMapper mapper = config.CreateMapper();
         

            return notifications.Select(mapper.Map<Notification, NotificationDto>);
        }
    }
}
