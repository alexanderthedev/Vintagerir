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
                var nameToLower = productViewModel.Product.ProductName.ToLower();
                var nameWithSpaces = nameToLower.Replace(" ", "-");
                var findInDb = _context.Products.Select(p => p.Slug).Contains(nameWithSpaces);

                var i = 1;
                while (findInDb)
                {
                    var newSlug = nameWithSpaces + "-" + i;
                    findInDb = _context.Products.Select(p => p.Slug).Contains(newSlug);
                    if (!findInDb)
                    {
                        nameWithSpaces = newSlug;
                    }    
                    i++;
                }


                var product = new Product
                {
                    UserId = User.Identity.GetUserId(),
                    TimeAdded = DateTime.Now,
                    ProductName = productViewModel.Product.ProductName,
                    ProductDescription = productViewModel.Product.ProductDescription,
                    ProductPrice = productViewModel.Product.ProductPrice,
                    ProductLikes = 0,
                    ProductCategoryId = productViewModel.Product.ProductCategoryId,
                    Slug = nameWithSpaces

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
               
            

        


            return RedirectToAction("MyProducts");
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
                    StringBuilder imageBuilder = new StringBuilder();

                    var imagePath =
                        imageBuilder
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


    
        public ActionResult DeleteProduct(int id)
        {

            var currentUser = User.Identity.GetUserId();

            var product = _context.Products.Include("User").Single(p => p.Id == id && p.User.Id == currentUser);
            var user = _context.Users.Single(u => u.Id == currentUser);

            DeleteFolder(product, user);
            _context.Products.Remove(product);
            _context.SaveChanges();

           

            return RedirectToAction("MyProducts");
        }


        public void DeleteFolder(Product product, ApplicationUser user)
        {
            StringBuilder direCtorybuilder = new StringBuilder();

            var productDirectory = direCtorybuilder.Append("~/content/images/").Append(user.Name).Append("/").Append(product.ProductName).ToString();

                Directory.Delete(Server.MapPath(productDirectory), true);
            
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

        public ActionResult Index()
        {
            
             var products = _context.Products
                .Include(p => p.User)
                .Include(c => c.ProductCategory)
                .ToList();
            
            var pictures = _context.PIctureInfos.Where(i => i.OrderNumber == 0).ToList();
            var users = _context.Users.ToList();
            var userId = User.Identity.GetUserId();
            var likesOfUser = _context.Likes.Where(l => l.LikerId == userId).ToList().ToLookup(l => l.ProductLikedId);


            var allProductsPictures = new HomePageViewModel
            {
                Product = products,
                Picture = pictures,
                Users = users,
                Likes = likesOfUser,
                CurrentCategoryTitle = "All products"
            };

            return View(allProductsPictures);
        }

        public ActionResult Category(int id)
        {
            
            var  products = _context.Products
                    .Include(p => p.User)
                    .Include(c => c.ProductCategory)
                    .Where(c => c.ProductCategoryId == id)
                    .ToList();

            var pictures = _context.PIctureInfos.Where(i => i.OrderNumber == 0).ToList();
            var users = _context.Users.ToList();
            var userId = User.Identity.GetUserId();
            var likesOfUser = _context.Likes.Where(l => l.LikerId == userId).ToList().ToLookup(l => l.ProductLikedId);

            var allProductsPictures = new HomePageViewModel
            {
                Product = products,
                Picture = pictures,
                Users = users,
                Likes = likesOfUser,
                CurrentCategoryTitle = _context.ProductCategories.Single(c => c.Id == id).Name

        };

            return View("index",allProductsPictures);
        }

        [HttpPost]
        public ActionResult Search(ProductsViewModel viewModel)
        {
            return RedirectToAction("Index", "Products", new {query = viewModel.SearchTerm});

        }


        public ActionResult SingleProduct(string slug)
        {
            var userId = User.Identity.GetUserId();
            var product = _context.Products.Include(i => i.User).Single(s => s.Slug == slug);
            var likeThis = _context.Likes.Select(l => l.LikerId).Contains(userId);
            var loveThisStre = _context.Loves.Select(l => l.LovedId).Contains(userId);
            var picturesOfProduct = _context.PIctureInfos.Where(p => p.Product.Slug == slug).ToList();

            var viewModel = new SingleProductViewModel
            {
                Product = product,
                LikeThisProduct = likeThis,
                LoveThisShop = loveThisStre,
                Pictures = picturesOfProduct
            };

            return View(viewModel);
        }
    }
}