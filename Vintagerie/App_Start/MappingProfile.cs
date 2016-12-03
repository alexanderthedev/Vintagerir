using AutoMapper;
using Vintagerie.Controllers.Api;
using Vintagerie.Models;

namespace Vintagerie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notification, NotificationDto>();
                cfg.CreateMap<ApplicationUser, ApplicationUserDto>();
            });

            IMapper mapper = config.CreateMapper();
        }
    }
}