using Microsoft.EntityFrameworkCore;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Data.Context
{
    public class OrganizationUserDbContext(DbContextOptions<OrganizationUserDbContext> options) : DbContext(options)
    {
        public DbSet<Organization> Organizaciones { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
