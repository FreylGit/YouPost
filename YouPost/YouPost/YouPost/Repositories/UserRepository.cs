using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Repositories.Interface;

namespace YouPost.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser SearchByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => String.Equals(u.UserName.ToLower(), username.ToLower()));
            return user;
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
