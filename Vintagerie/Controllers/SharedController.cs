using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Vintagerie.Models;

namespace Vintagerie.Controllers
{
    public class SharedController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SharedController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult _Layout()
        {
            var currentId = User.Identity.GetUserId();

            var userInfo = _context.Users.Single(u => u.Id == currentId);

            return View(userInfo);
        }
    }
}