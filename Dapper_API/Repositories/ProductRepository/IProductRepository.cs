using Dapper_API.Models.Dtos.ProductDtos;

namespace Dapper_API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategory>> ListProductWithCategory();
    }
}
