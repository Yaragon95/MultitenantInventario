using MultitenantInventario.Application.Interfaces;
using MultitenantInventario.Domain.Entities;
using MultitenantInventario.Domain.Interfaces;

namespace MultitenantInventario.Application.Services
{
    public class UserService(IUserRepository userService) : IUserService
    {
        private readonly IUserRepository _userRepository = userService;
        public async Task<User> FindUserAsync(User user)
        {
            return await _userRepository.FindUserAsync(user);
        }
    }
}
