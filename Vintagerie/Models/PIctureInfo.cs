using System;

namespace Vintagerie.Models
{
    public class PictureInfo
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public int OrderNumber { get; set; }

        public string ImageName { get; set; }

        public bool IsFeautured { get; set; }

        public DateTime DateAdded { get; set; }
    }
}