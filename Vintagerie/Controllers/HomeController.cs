using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vintagerie.Models;
using Vintagerie.ViewModels;

namespace Vintagerie.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.User)
                .Include(c => c.ProductCategory)
                .ToList().Take(4);

            var pictures = _context.PIctureInfos.Where(i => i.OrderNumber == 0).ToList();
            var users = _context.Users.ToList();
            var userId = User.Identity.GetUserId();
            var likesOfUser = _context.Likes.Where(l => l.LikerId == userId).ToList().ToLookup(l => l.ProductLikedId);
            var loveOfUser = _context.Loves.Where(l => l.LoverUserId == userId).ToList().ToLookup(l => l.LovedId);
            var topUsers = _context.Users.OrderByDescending(o => o.Loves).Take(4).ToList();


            var allProductsPictures =  new HomePageViewModel
            {
                Product = products,
                Picture = pictures,
                Users = users,
                Likes = likesOfUser,
                Loves = loveOfUser,
                TopUsers = topUsers

            };
            return View(allProductsPictures);
        }


        public ActionResult AllStores()
        {
            var currentUserId = User.Identity.GetUserId();
            var allUsers = _context.Users.ToList();
            var allLoves = _context.Loves.Where(l => l.LoverUserId == currentUserId).ToList();

            var allStoresLoves = new AllStoresViewModel
            {
                Stores = allUsers,
                Loves = allLoves
            };

            return View(allStoresLoves);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}