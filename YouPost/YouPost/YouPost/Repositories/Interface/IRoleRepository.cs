using YouPost.Areas.Identity.Data;

namespace YouPost.Repositories.Interface
{
    public interface IRoleRepository
    {
        ICollection<ApplicationRole> GetRoles();
    }
}
