namespace YouPost.Repositories.Interface
{
    public class IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
    }
}
