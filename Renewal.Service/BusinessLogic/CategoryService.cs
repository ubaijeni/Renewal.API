using Renewal.DataHub.Repositories;
using Renewal.Service.DTO;
using Renewal.Service.Interfaces;
using Renewal.Service.Mappings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renewal.Service.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync(bool includeDeleted = false)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync(includeDeleted);
            return categories.Select(CategoryMapper.ToDto).ToList();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return CategoryMapper.ToDto(category);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = CategoryMapper.ToEntity(createCategoryDto);
            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);
            return CategoryMapper.ToDto(createdCategory);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null)
                return null;

            CategoryMapper.UpdateEntityFromDto(existingCategory, updateCategoryDto);

            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(existingCategory);
            return CategoryMapper.ToDto(updatedCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}