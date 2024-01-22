using Dapper_API.Models.Dtos.CategoryDtos;
using Dapper_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("ListCategories")]
        public async Task<IActionResult> ListCategories()
        {
            var categories = await _categoryRepository.GetAllCategoryAsync();

            return Ok(categories);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            _categoryRepository.CreateCategory(categoryDto);

            return Ok("Category created successfully.");
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);

            return Ok("Category deleted successfully.");
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto, int id, bool status)
        {
            _categoryRepository.UpdateCategory(categoryDto, id, status);

            return Ok("Category updated successfully.");
        }
    }
}
