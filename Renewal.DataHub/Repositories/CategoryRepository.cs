using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Data;
using Renewal.DataHub.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Renewal.DataHub.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Category>> GetAllCategoriesAsync(bool includeDeleted = false)
        {
            var query = _context.Categories.AsQueryable();
    
            if (!includeDeleted)
            {
                query = query.Where(c => c.IsActive == 1);
            }
    
            return await query.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.Now;
            category.IsActive = 1; // Default to active
            category.Suspend = 0;  // Default to not suspended
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            category.UpdatedDate = DateTime.Now;
            _context.Entry(category).State = EntityState.Modified;
            
            // Don't modify creation fields
            _context.Entry(category).Property(x => x.CreatedBy).IsModified = false;
            _context.Entry(category).Property(x => x.CreatedDate).IsModified = false;
            
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;
                
            // If already inactive, return success
            if (category.IsActive == 0)
                return true;

            // Soft delete
            category.IsActive = 0;
            category.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}