using System.Collections.Generic;
using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class AllStoresViewModel
    {
        public IEnumerable<ApplicationUser> Stores { get; set; }
        public IEnumerable<LovesUserToStore> Loves { get; set; }
    }
}