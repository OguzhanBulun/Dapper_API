using Dapper;
using Dapper_API.Models.DapperContext;
using Dapper_API.Models.Dtos.CategoryDtos;

namespace Dapper_API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string sql = "SELECT * FROM Category ";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultCategoryDto>(sql);
                return result.ToList();
            }

        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string sql = "INSERT INTO Category (CategoryName,CategoryStatus) VALUES (@name,@status)";

            var parameters = new DynamicParameters();

            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string sql = "DELETE FROM Category WHERE CategoryId = @id";

            var parameters = new DynamicParameters();

            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string sql = "UPDATE Category SET CategoryName = @name, CategoryStatus = @status WHERE CategoryId = @id";

            var parameters = new DynamicParameters();
            parameters.Add("@id", categoryDto.CategoryId);
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", categoryDto.CategoryStatus);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(int id)
        {
            string sql = "SELECT * FROM Category WHERE CategoryId = @id";

            var parameters = new DynamicParameters();

            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetCategoryByIdDto>(sql, parameters);
                return result;
            }
        }
    }
}
