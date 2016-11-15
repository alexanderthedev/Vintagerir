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
    public class LovesController : ApiController
    {
        private ApplicationDbContext _context;

        public LovesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Love(LoveDto dto)
        {
     

            var userId = User.Identity.GetUserId();
            var loveExist = _context.Loves.SingleOrDefault(l => l.LoverUserId == userId && l.LovedId == dto.Uid);
            var findStore = _context.Users.Single(p => p.Id == dto.Uid);

            if (loveExist != null)
            {

                _context.Loves.Remove(loveExist);
                _context.SaveChanges();

                findStore.Loves--;
                _context.Users.AddOrUpdate(findStore);
                _context.SaveChanges();

                return Ok();
            }



            var love = new LovesUserToStore
            {
                LovedId = dto.Uid,
                LoverUserId = userId,
                DateAdded = DateTime.Now
            };

            _context.Loves.Add(love);
            _context.SaveChanges();

            findStore.Loves++;
            _context.Users.AddOrUpdate(findStore);
            _context.SaveChanges();

            return Ok();

        }

    }
}
