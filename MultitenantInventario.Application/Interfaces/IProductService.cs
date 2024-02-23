using MultitenantInventario.Application.Dtos;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Application.Interfaces
{
    public interface IProductService
    {
        Task<int> AddProductAsync(ProductoDto product, string organizationId);
        Task<int> DeleteProductAsync(int productId, string organizationId);
        Task<IEnumerable<Product>> GetAllProductsAsync(string organizationId, int? manufacturyTypeId);
        Task<Product> GetProductByIdAsync(int productId, string organizationId);
        Task<int> UpdateProductAsync(Product product, string organizationId);
    }
}
