using YouPost.Areas.Identity.Data;

namespace YouPost.Repositories.Interface
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();
        ApplicationUser GetUser(Guid id);
        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
