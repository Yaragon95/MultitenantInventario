using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product, string slugtenant);
        Task<int> DeleteProductAsync(int productId, string slugtenant);
        Task<IEnumerable<Product>> GetAllProductsAsync(string slugtenant);
        Task<Product> GetProductByIdAsync(int productId, string slugtenant);
        Task<int> UpdateProductAsync(Product product, string slugtenant);
    }
}
