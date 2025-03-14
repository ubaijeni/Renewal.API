using Renewal.DataHub.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.DataHub.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync(bool includeDeleted = false);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}