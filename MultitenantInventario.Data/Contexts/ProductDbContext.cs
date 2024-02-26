using Microsoft.EntityFrameworkCore;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Data.Context
{
    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ManufactureType> ManufactureTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Type = "Nuevo" },
                new Status { Id = 2, Type = "Defectuoso" }
                );

            modelBuilder.Entity<ManufactureType>().HasData(
                new ManufactureType { Id = 1, Type = "Elaborado a mano" },
                new ManufactureType { Id = 2, Type = "Elaborado a mano y máquina" }
                );
        }
    }
}
