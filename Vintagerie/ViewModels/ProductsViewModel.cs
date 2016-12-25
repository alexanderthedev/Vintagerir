using System.Collections.Generic;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<PictureInfo> Pictures { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<LikeUserToProduct> MyLikes { get; set; }
    }

}