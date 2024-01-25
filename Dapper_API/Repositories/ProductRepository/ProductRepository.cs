using Dapper;
using Dapper_API.Models.DapperContext;
using Dapper_API.Models.Dtos.ProductDtos;

namespace Dapper_API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var sql = "SELECT * FROM Product";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultProductDto>(sql);
                return result.ToList();
            }
        }
    }
}
