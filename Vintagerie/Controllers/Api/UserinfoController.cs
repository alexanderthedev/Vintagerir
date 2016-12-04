using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using Vintagerie.Models;

namespace Vintagerie.Controllers.Api
{
    [Authorize]
    public class UserinfoController : ApiController
    {
        public ApplicationDbContext _Context;

        public UserinfoController()
        {
            _Context = new ApplicationDbContext();
        }
        public string GetUserImage()
        {
            var myId = User.Identity.GetUserId();
            var imgUrl = _Context.Users.Single(u => u.Id == myId).PhotoProFileName;

            return imgUrl;
        }
    }
}
