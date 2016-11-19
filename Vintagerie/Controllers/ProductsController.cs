using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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


            if (productViewModel.Product.Id == 0)
            {
                var product = new Product
                {
                    UserId = User.Identity.GetUserId(),
                    TimeAdded = DateTime.Now,
                    ProductName = productViewModel.Product.ProductName,
                    ProductDescription = productViewModel.Product.ProductDescription,
                    ProductPrice = productViewModel.Product.ProductPrice,
                    ProductLikes = 0,
                    ProductCategoryId = productViewModel.Product.ProductCategoryId,

                };
                _context.Products.Add(product);

                AddImages(productViewModel,product);
            }
            else
            {
                var findProduct = _context.Products.Single(p => p.Id == productViewModel.Product.Id);


                findProduct.ProductName = productViewModel.Product.ProductName;
                findProduct.ProductDescription = productViewModel.Product.ProductDescription;
                findProduct.ProductPrice = productViewModel.Product.ProductPrice;
                findProduct.ProductCategoryId = productViewModel.Product.ProductCategoryId;

                _context.SaveChanges();

                AddImages(productViewModel, findProduct);

            };
               
            

        


            return RedirectToAction("MyProducts","Products");
        }




        public void AddImages(ProductFormViewModel productViewModel,Product product)
        {
            StringBuilder direCtorybuilder = new StringBuilder();

            var userId = User.Identity.GetUserId();
            var usersStoreName = _context.Users.Single(user => user.Id == userId);
            var productDirectory = direCtorybuilder.Append("~/Content/images/").Append(usersStoreName.Name).Append("/").Append(product.ProductName).ToString();

            if (!Directory.Exists(productDirectory))
            {
                Directory.CreateDirectory(Server.MapPath(productDirectory));
            }

            var orderNum = 0;
            foreach (var file in productViewModel.File)
            {
                var filename = Path.GetFileName(file?.FileName);
                if (filename != null)
                {
                    var path = Path.Combine(Server.MapPath(productDirectory), filename);
                    file.SaveAs(path);

                    var imagePath = 
                        direCtorybuilder
                        .Append("/content/images/")
                        .Append(usersStoreName.Name)
                        .Append("/")
                        .Append(product.ProductName)
                        .Append("/")
                        .Append(file.FileName)
                        .ToString();

                    var image = new PictureInfo
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        UserId = product.UserId,
                        OrderNumber = orderNum,
                        ImageName = file.FileName,
                        IsFeautured = orderNum == 0 ? true : false,
                        DateAdded = DateTime.Now,
                        UserName = usersStoreName.Name,
                        ProductName = product.ProductName,
                        Path = imagePath
                    };

                    _context.PIctureInfos.Add(image);

                    _context.SaveChanges();
                }


                orderNum++;

            }
        }

       
        [Authorize]
        public ActionResult MyProducts()
        {

            
            var currentUserId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == currentUserId);
            var products = _context.Products.Where(m => m.UserId == currentUserId).Include(p => p.User).Include(c => c.ProductCategory).ToList();
            var pictures = _context.PIctureInfos.Where(m => m.UserId == currentUserId).ToList();

            var myProducts = new MyProductsViewModel
            {
                Product = products,
                Picture = pictures,
                Users = user
            };

            return View(myProducts);
        }

        public ActionResult EditProduct(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentProduct = _context.Products.Single(p => p.Id == id && p.UserId == currentUserId);
            var getPictures = _context.PIctureInfos
                .Where(i => i.ProductId == currentProduct.Id && i.UserId == currentUserId).ToList();

            var viewModel = new ProductFormViewModel
            {
                Product = currentProduct,
                ProductCategory = _context.ProductCategories.ToList(),
                PictureInfo = getPictures
            };


            return View("Create", viewModel);
        }
    }
}