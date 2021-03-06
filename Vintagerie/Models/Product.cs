﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vintagerie.Models
{
    public class Product
    {
        public int Id { get; set; }
       
        public ApplicationUser User { get; set; }
        
        public string UserId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public float ProductPrice { get; set; }


        public int ProductLikes { get; set; }

        public DateTime TimeAdded { get; set; }
      
        public ProductCategory ProductCategory { get; set; }

        [Required]
        public byte ProductCategoryId  { get; set; }

        public string Slug { get; set; }

        public ICollection<PictureInfo> Pictures { get; set; }

        public Product()
        {
            Pictures =  new Collection<PictureInfo>();
        } 
    }
}