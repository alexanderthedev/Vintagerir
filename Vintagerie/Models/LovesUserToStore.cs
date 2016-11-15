using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vintagerie.Models
{
    public class LovesUserToStore
    {
        public ApplicationUser Loved { get; set; }

        [Key]
        [Column(Order = 1)]
        public string LovedId { get; set; }

        public ApplicationUser LoverUser { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LoverUserId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}