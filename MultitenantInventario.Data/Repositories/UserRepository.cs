using Microsoft.EntityFrameworkCore;
using MultitenantInventario.Data.Context;
using MultitenantInventario.Domain.Entities;
using MultitenantInventario.Domain.Interfaces;

namespace MultitenantInventario.Data.Repositories
{
    public class UserRepository(OrganizationUserDbContext context) : IUserRepository
    {
        private readonly OrganizationUserDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindUserAsync(User user) => await _context.Users.Include(x => x.Organization).FirstOrDefaultAsync(x => x.Email.Contains(user.Email) && x.Password.Contains(user.Password));
    }
}
