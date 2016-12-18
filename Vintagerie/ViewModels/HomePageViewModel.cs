using System.Collections.Generic;
using System.Linq;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<PictureInfo> Picture { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public ILookup<int, LikeUserToProduct> Likes { get; set; }
        public ILookup<string, LovesUserToStore> Loves { get; set; }
        public IEnumerable<ApplicationUser> TopUsers { get; set; }
        public string CurrentCategoryTitle { get; set; }
    }

    
}