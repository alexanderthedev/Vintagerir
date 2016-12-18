using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class SingleProductViewModel
    {
        public Product Product { get; set; }
        public bool LikeThisProduct { get; set; }
        public bool LoveThisShop { get; set; }
    }
}