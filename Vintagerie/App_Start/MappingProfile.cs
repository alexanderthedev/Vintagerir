using AutoMapper;
using Vintagerie.Dtos;
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