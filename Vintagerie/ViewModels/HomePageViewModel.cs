using System.Collections.Generic;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<PictureInfo> Picture { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<LikeUserToProduct> Likes { get; set; }
    }
}