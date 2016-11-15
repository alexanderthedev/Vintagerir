using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using Vintagerie.Dtos;
using Vintagerie.Models;

namespace Vintagerie.Controllers.Api
{
    [Authorize]
    public class LikesController : ApiController
    {

       
        private readonly ApplicationDbContext _context;

        public LikesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Like(LikeDtio dto)
        {
            var userId = User.Identity.GetUserId();
            var likeExist = _context.Likes.SingleOrDefault(l => l.LikerId == userId && l.ProductLikedId == dto.PId);
            var findProduct = _context.Products.Single(p => p.Id == dto.PId);

            if (likeExist != null)
            {

                _context.Likes.Remove(likeExist);
                _context.SaveChanges();

                findProduct.ProductLikes--;
                _context.Products.AddOrUpdate(findProduct);
                _context.SaveChanges();

                return Ok();
            }



            var like = new LikeUserToProduct
            {
                ProductLikedId = dto.PId,
                LikerId = userId,
                DateAdded = DateTime.Now
            };

            _context.Likes.Add(like);
            _context.SaveChanges();

            findProduct.ProductLikes++;
            _context.Products.AddOrUpdate(findProduct);
            _context.SaveChanges();

            return Ok();

        }
    }
}
