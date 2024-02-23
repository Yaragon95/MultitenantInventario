using Microsoft.EntityFrameworkCore;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Data.Context
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ManufactureType> ManufactureTypes { get; set; }
    }
}
