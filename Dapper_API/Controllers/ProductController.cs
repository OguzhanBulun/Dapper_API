using Dapper_API.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("ListProducts")]
        public async Task<IActionResult> ListProducts()
        {
            var products = await _productRepository.GetAllProductAsync();

            return Ok(products);
        }
    }
}
