using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vintagerie.Models
{
    public class LikeUserToProduct
    {
        public Product ProductLiked { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductLikedId { get; set; }

        public ApplicationUser Liker { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LikerId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}