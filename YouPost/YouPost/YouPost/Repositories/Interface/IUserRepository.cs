using YouPost.Areas.Identity.Data;

namespace YouPost.Repositories.Interface
{
    public interface IUserRepository
    {
        public ICollection<ApplicationUser> GetUsers();
        public ApplicationUser GetUser(Guid id);
        public ApplicationUser UpdateUser(ApplicationUser user);
        public ApplicationUser SearchByUsername(string username);

    }
}
