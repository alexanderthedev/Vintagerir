using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;
using Vintagerie.Models;


namespace Vintagerie.Controllers.Api
{

    [Authorize]
    public class PicturesInProductController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public PicturesInProductController()
        {
            _context = new ApplicationDbContext();
        }

        
        [HttpDelete]
        public IHttpActionResult DeletePicture(Guid id)
        {

            var currentUser = User.Identity.GetUserId();
            var picInDb = _context.PIctureInfos.Single(p => p.Id == id && p.User.Id == currentUser);

            _context.PIctureInfos.Remove(picInDb);
            _context.SaveChanges();

            StringBuilder direCtorybuilder = new StringBuilder();

            var productDirectory = direCtorybuilder.Append("~").Append(picInDb.Path).ToString();

            Directory.Delete(productDirectory, true);

            return Ok();

        }


    }

    
}
