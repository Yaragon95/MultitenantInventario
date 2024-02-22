using EdynamicsLog.Prueba.Api.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultitenantInventario.Application.Interfaces;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Api.Controllers
{
    [Route("{slugtenant}/api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IAuthenticationServices _authenticationServices;

        public ProductController(IProductService productService, IAuthenticationServices authenticationServices)
        {
            _productService = productService;
            _authenticationServices = authenticationServices;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllProducts()
        {
            // Recuperar el OrganizationId del token
            var organizationId = ObtenerOrganizationIdDesdeToken();

            var products = await _productService.GetAllProductsAsync(organizationId);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            // Recuperar el OrganizationId del token
            var organizationId = ObtenerOrganizationIdDesdeToken();

            var product = await _productService.GetProductByIdAsync(id, organizationId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var organizationId = ObtenerOrganizationIdDesdeToken();

            var productRequest = product.Adapt<Product>();
            productRequest.SlugTenant = organizationId;

            var response = await _productService.AddProductAsync(productRequest, organizationId);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            // Recuperar el OrganizationId del token
            var organizationId = ObtenerOrganizationIdDesdeToken();

            // Puedes realizar validaciones o ajustes aquí antes de actualizar el producto
            await _productService.UpdateProductAsync(product, organizationId);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Recuperar el OrganizationId del token
            var organizationId = ObtenerOrganizationIdDesdeToken();

            await _productService.DeleteProductAsync(id, organizationId);
            return NoContent();
        }

        // Otros métodos según tus necesidades

        private string ObtenerOrganizationIdDesdeToken()
        {
            var tenantsClaim = HttpContext.User.FindFirst("Tenant");

            if (tenantsClaim?.Value != null)
            {
                return tenantsClaim.Value;
            }

            // En caso de que no se pueda extraer el slugTenant, puedes devolver un valor predeterminado o lanzar una excepción según tus necesidades.
            return "defaultSlugTenant";
        }
    }
}
