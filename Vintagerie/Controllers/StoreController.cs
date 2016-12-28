using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vintagerie.Models;

namespace Vintagerie.Controllers
{
    public class StoreController : Controller
    {

        public readonly ApplicationDbContext Context;

        public StoreController()
        {
            Context = new ApplicationDbContext();
        }
        // GET: Store
        public ActionResult SingleStore(string id)
        {
            var findUser = Context.Users.Include(u => u.Products).Single(u => u.Slug == id);
            

            return View(findUser);
        }
    }
}