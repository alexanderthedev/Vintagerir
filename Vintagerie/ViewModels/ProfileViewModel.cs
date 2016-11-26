using Vintagerie.Models;

namespace Vintagerie.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public Picture ProfilePicture { get; set; }
    }
}