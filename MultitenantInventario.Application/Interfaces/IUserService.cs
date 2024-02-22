using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> FindUserAsync(User user);
    }
}
