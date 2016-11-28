using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Principal;
using Vintagerie.Models;

namespace Vintagerie.Helpers
{
    public static class Extensions
    {
        public static ApplicationDbContext Context= new ApplicationDbContext();
    

        public static string GetStoreName(this IIdentity user)
        {
            var currentUser = user.GetUserId();

            var storeName = Context.Users.Single(u => u.Id == currentUser).Name ;
            return storeName;
        }

    }
}