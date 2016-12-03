using AutoMapper;
using Vintagerie.Controllers.Api;
using Vintagerie.Models;

namespace Vintagerie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}