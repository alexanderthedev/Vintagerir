using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Text;
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
        [ValidateAntiForgeryToken]
        public ActionResult SaveOrEdit(ProductFormViewModel productViewModel)
        {

            if (!ModelState.IsValid)
            {
                productViewModel.ProductCategory = _context.ProductCategories.ToList();
                return View("Create", productViewModel);
            }

            var product = new Product
            {
                UserId = User.Identity.GetUserId(),
                TimeAdded = DateTime.Now,
                ProductName = productViewModel.Product.ProductName,
                ProductDescription = productViewModel.Product.ProductDescription,
                ProductPrice = productViewModel.Product.ProductPrice,
                ProductLikes = 0,
                ProductCategoryId = productViewModel.ProductCategoryId
            };

            _context.Products.Add(product);

            



            StringBuilder direCtorybuilder = new StringBuilder();

            var productDirectory = direCtorybuilder.Append("~/Content/images/").Append(User.Identity.GetUserId()).Append("/").Append(product.ProductName).ToString();

            if (!Directory.Exists(productDirectory))
            {
                Directory.CreateDirectory(Server.MapPath(productDirectory));
            }

            var orderNum = 0;
            foreach (var file in productViewModel.File)
            {
                var filename = Path.GetFileName(file.FileName);
                if (filename != null)
                {
                    var path = Path.Combine(Server.MapPath(productDirectory), filename);
                    file.SaveAs(path);
                }

                var image = new PictureInfo
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    UserId = product.UserId,
                    OrderNumber = orderNum,
                    ImageName = file.FileName,
                    IsFeautured = orderNum == 0 ?  true : false,
                     DateAdded = DateTime.Now
                };

                _context.PIctureInfos.Add(image);

                _context.SaveChanges();

              
                orderNum++;

            }
            
              


            return RedirectToAction("Index","Home");
        }


        public ActionResult AddImages()
        {
            return View();
        }

       /* [HttpPost]
        public ActionResult UploadImages(Picture picture)
        {

            foreach (var file in picture.Files) { 
                var filename = Path.GetFileName(file.FileName);
                if (filename != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), filename);
                    file.SaveAs(path);
                }
            }
               


            return RedirectToAction("Index","Home");
        }*/
    }
}