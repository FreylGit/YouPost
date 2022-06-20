using YouPost.Areas.Identity.Data;
using YouPost.Data;
using YouPost.Repositories.Interface;

namespace YouPost.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<ApplicationRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
