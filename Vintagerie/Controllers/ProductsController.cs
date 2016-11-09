using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using Vintagerie.Models;
using Vintagerie.ViewModels;

namespace Vintagerie.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                ProductCategory = _context.ProductCategories.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveOrEdit(ProductFormViewModel ProductViewModel)
        {
            var product = new Product
            {
                UserId = User.Identity.GetUserId(),
                TimeAdded = DateTime.Now,
                ProductName = ProductViewModel.Product.ProductName,
                ProductDescription = ProductViewModel.Product.ProductDescription,
                ProductPrice = ProductViewModel.Product.ProductPrice,
                ProductLikes = 0,
                ProductCategoryId = ProductViewModel.ProductCategoryId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}