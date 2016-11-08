using System;
using System.ComponentModel.DataAnnotations;

namespace Vintagerie.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required]
        public float ProductPrice { get; set; }

        public int ProductLikes { get; set; }

        public DateTime TimeAdde { get; set; }

        [Required]
        public ProductCategory Category { get; set; }
    }
}