using System.Linq;
using Vintagerie.Models;

namespace Vintagerie.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserInfo(string id)
        {
            var userInfo = _context.Users.Single(u => u.Id == id);

            return userInfo;
        }
    }
}