using Microsoft.EntityFrameworkCore;
using MultitenantInventario.Data.Context;
using MultitenantInventario.Domain.Entities;
using MultitenantInventario.Domain.Interfaces;

namespace MultitenantInventario.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string slugtenant, int? manufactureTypeId)
        {

            if (manufactureTypeId is null) return await _context.Products
                .Where(p => p.SlugTenant == slugtenant).ToListAsync();

            return await _context.Products
                .Where(p => p.SlugTenant == slugtenant && p.ManufactureTypeId == manufactureTypeId).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId, string slugtenant)
        {
            return await _context.Products
                .Where(p => p.Id == productId && p.SlugTenant == slugtenant)
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddProductAsync(Product product, string slugtenant)
        {
            product.SlugTenant = slugtenant;
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateProductAsync(Product product, string slugtenant)
        {
            var existingProduct = await _context.Products
                .Where(p => p.Id == product.Id && p.SlugTenant == slugtenant)
                .FirstOrDefaultAsync();

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;

            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(int productId, string slugtenant)
        {
            var productToDelete = await _context.Products
                .Where(p => p.Id == productId && p.SlugTenant == slugtenant)
                .FirstOrDefaultAsync();

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }
    }
}
