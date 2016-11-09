using System.Collections.Generic;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public byte ProductCategoryId { get; set; }
        public IEnumerable<ProductCategory> ProductCategory { get; set; }

    }
}