using System.Collections.Generic;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class MyProductsViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<PictureInfo> Picture { get; set; }
        public ApplicationUser Users { get; set; }
    }
}