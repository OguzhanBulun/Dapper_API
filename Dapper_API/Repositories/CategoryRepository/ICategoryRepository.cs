using Dapper_API.Models.Dtos.CategoryDtos;

namespace Dapper_API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(int id);
    }
}
