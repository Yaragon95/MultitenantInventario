using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindUserAsync(User user);
    }
}
