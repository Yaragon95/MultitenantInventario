using MultitenantInventario.Application.Interfaces;
using MultitenantInventario.Domain.Entities;
using MultitenantInventario.Domain.Interfaces;

namespace MultitenantInventario.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(string organizationId)
        {
            return await _productRepository.GetAllProductsAsync(organizationId);
        }

        public async Task<Product> GetProductByIdAsync(int productId, string organizationId)
        {
            return await _productRepository.GetProductByIdAsync(productId, organizationId);
        }

        public async Task<int> AddProductAsync(Product product, string organizationId)
        {
            // Puedes realizar validaciones o ajustes aquí antes de agregar el producto
            return await _productRepository.AddProductAsync(product, organizationId);
        }

        public async Task<int> UpdateProductAsync(Product product, string organizationId)
        {
            // Puedes realizar validaciones o ajustes aquí antes de actualizar el producto
            return await _productRepository.UpdateProductAsync(product, organizationId);
        }

        public async Task<int> DeleteProductAsync(int productId, string organizationId)
        {
            return await _productRepository.DeleteProductAsync(productId, organizationId);
        }
    }
}
