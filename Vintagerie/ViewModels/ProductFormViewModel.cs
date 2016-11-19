using System.Collections.Generic;
using System.Web;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class ProductFormViewModel
    {
       
        public Product Product { get; set; }

        public IEnumerable<PictureInfo> PictureInfo { get; set; }

        public byte ProductCategoryId { get; set; }

        public IEnumerable<HttpPostedFileBase> File { get; set; }

        public IEnumerable<ProductCategory> ProductCategory { get; set; }


    }
}