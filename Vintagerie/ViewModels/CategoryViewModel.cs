using System.Collections.Generic;
using System.Linq;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<PictureInfo> Pictures { get; set; }
        public ILookup<int, LikeUserToProduct> Likes { get; set; }

    }
}