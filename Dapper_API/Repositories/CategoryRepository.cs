using Dapper;
using Dapper_API.Models.DapperContext;
using Dapper_API.Models.Dtos.CategoryDtos;

namespace Dapper_API.Repositories
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

        public async void UpdateCategory(UpdateCategoryDto categoryDto, int id,bool status = true)
        {
            string sql = "UPDATE Category SET CategoryName = @name AND CategoryStatus = @status  WHERE CategoryId = @id";

            var parameters = new DynamicParameters();

            parameters.Add("@id", id);
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", status);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
